namespace WindowToastNotification
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnshow = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnshow
            // 
            this.btnshow.Location = new System.Drawing.Point(48, 51);
            this.btnshow.Name = "btnshow";
            this.btnshow.Size = new System.Drawing.Size(341, 34);
            this.btnshow.TabIndex = 0;
            this.btnshow.Text = " Show ToastNotification";
            this.btnshow.UseVisualStyleBackColor = true;
            this.btnshow.Click += new System.EventHandler(this.btnshow_Click);
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(48, 126);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(341, 34);
            this.btnclose.TabIndex = 1;
            this.btnclose.Text = " Close ToastNotification";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 286);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnshow);
            this.Name = "Main";
            this.Text = "Winform ToastNotification Test";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnshow;
        private System.Windows.Forms.Button btnclose;
    }
}

