using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToastNotifications;

namespace WindowToastNotification
{
    public partial class Main : Form
    {
        Notification toastNotification;

        public Main()
        {
            InitializeComponent();
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            

            string title = $" Running {Application.ProductName}...";
            string body = $" {this.Text} " + "\r\n";
            body += $" {Application.ProductVersion} ";
            int duration = -1;
            var animationMethod = FormAnimator.AnimationMethod.Slide;
            var animationDirection = FormAnimator.AnimationDirection.Up;
            toastNotification = new Notification(title, body, duration, animationMethod, animationDirection);
            toastNotification.Show();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            if (toastNotification != null)
            {
                toastNotification.NotificationClose();
                toastNotification.Dispose();
                toastNotification = null;
            }
        }
    }
}
