using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ToastNotifications
{
    public partial class Notification : Form
    {
        //https://github.com/noxad/windows-toast-notifications

        private static readonly List<Notification> OpenNotifications = new List<Notification>();
        private bool _allowFocus;
        private readonly FormAnimator _animator;
        private IntPtr _currentForegroundWindow;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="body"></param>
        /// <param name="duration"></param>
        /// <param name="animation"></param>
        /// <param name="direction"></param>
        public Notification(string title, string body, int duration, FormAnimator.AnimationMethod animation, FormAnimator.AnimationDirection direction)
        {
            InitializeComponent();

            this.BackColor = Color.FromArgb(232, 249, 253);

            this.Load += Notification_Load;

            if (duration < 0)
                duration = int.MaxValue;
            else
                duration = duration * 1000;

            lifeTimer.Interval = duration;
            lblTitle.Text = title;
            lblbody.Text = body;

            _animator = new FormAnimator(this, animation, direction, 500);

            Region = Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, Width - 5, Height - 5, 20, 20));

            this.Activated += Notification_Activated;
            this.Shown += Notification_Shown;
            this.FormClosed += Notification_FormClosed;

            this.Click += (s, e) => Close();
            this.lblbody.Click += (s, e) => Close();
            this.lblTitle.Click += (s, e) => Close();

            this.lifeTimer.Tick += lifeTimer_Tick;
        }

        #region Methods
        /// <summary>
        /// Displays the form
        /// </summary>
        /// <remarks>
        /// Required to allow the form to determine the current foreground window before being displayed
        /// </remarks>
        public new void Show()
        {
            // Determine the current foreground window so it can be reactivated each time this form tries to get the focus
            _currentForegroundWindow = NativeMethods.GetForegroundWindow();

            base.Show();
        }

        #endregion // Methods


        #region Event Handlers
        private void Notification_Load(object sender, EventArgs e)
        {
            // Display the form just above the system tray.
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - Width,
                                      Screen.PrimaryScreen.WorkingArea.Height - Height);



            // Move each open form upwards to make room for this one
            foreach (Notification openForm in OpenNotifications)
            {
                openForm.Top -= Height;
            }

            OpenNotifications.Add(this);
            lifeTimer.Start();
        }

        private void Notification_Activated(object sender, EventArgs e)
        {
            // Prevent the form taking focus when it is initially shown
            if (!_allowFocus)
            {
                // Activate the window that previously had focus
                NativeMethods.SetForegroundWindow(_currentForegroundWindow);
            }
        }

        private void Notification_Shown(object sender, EventArgs e)
        {
            // Once the animation has completed the form can receive focus
            _allowFocus = true;

            // Close the form by sliding down.
            _animator.Duration = 0;
            _animator.Direction = FormAnimator.AnimationDirection.Down;
        }

        private void Notification_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Move down any open forms above this one
            foreach (Notification openForm in OpenNotifications)
            {
                if (openForm == this)
                {
                    // Remaining forms are below this one
                    break;
                }
                openForm.Top += Height;
            }

            OpenNotifications.Remove(this);
        }

        private void lifeTimer_Tick(object sender, EventArgs e)
        {
            Close();
        }

        public void NotificationClose()
        {
            base.Close();
        }

        #endregion // Event Handlers
    }
}
