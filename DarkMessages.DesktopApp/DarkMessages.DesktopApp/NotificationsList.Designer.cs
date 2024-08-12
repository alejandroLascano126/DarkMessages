namespace DarkMessages.DesktopApp
{
    partial class NotificationsList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flpNotifications = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // flpNotifications
            // 
            flpNotifications.Location = new Point(0, 0);
            flpNotifications.Name = "flpNotifications";
            flpNotifications.Size = new Size(352, 450);
            flpNotifications.TabIndex = 0;
            flpNotifications.MouseWheel += FlpNotifications_MouseWheel;
            // 
            // NotificationsList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(352, 450);
            Controls.Add(flpNotifications);
            FormBorderStyle = FormBorderStyle.None;
            Name = "NotificationsList";
            Text = "NotificationsList";
            Load += NotificationsList_Load;
            ResumeLayout(false);
        }


        #endregion

        private FlowLayoutPanel flpNotifications;
    }
}