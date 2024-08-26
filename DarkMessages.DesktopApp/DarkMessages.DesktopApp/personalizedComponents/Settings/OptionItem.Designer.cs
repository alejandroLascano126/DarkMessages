namespace DarkMessages.DesktopApp
{
    partial class OptionItem
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
            lblNotificationTitle = new Label();
            picboxNotificationItem = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picboxNotificationItem).BeginInit();
            SuspendLayout();
            // 
            // lblNotificationTitle
            // 
            lblNotificationTitle.AutoSize = true;
            lblNotificationTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNotificationTitle.Location = new Point(95, 12);
            lblNotificationTitle.Name = "lblNotificationTitle";
            lblNotificationTitle.Size = new Size(126, 19);
            lblNotificationTitle.TabIndex = 0;
            lblNotificationTitle.Text = "Update Password";
            // 
            // picboxNotificationItem
            // 
            picboxNotificationItem.Image = Properties.Resources.change_password_5_64;
            picboxNotificationItem.Location = new Point(13, 12);
            picboxNotificationItem.Name = "picboxNotificationItem";
            picboxNotificationItem.Size = new Size(38, 38);
            picboxNotificationItem.SizeMode = PictureBoxSizeMode.StretchImage;
            picboxNotificationItem.TabIndex = 1;
            picboxNotificationItem.TabStop = false;
            // 
            // OptionItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(picboxNotificationItem);
            Controls.Add(lblNotificationTitle);
            Name = "OptionItem";
            Size = new Size(638, 57);
            MouseClick += UserItem_MouseClick;
            MouseEnter += UserItem_MouseEnter;
            MouseLeave += UserItem_MouseLeave;
            ((System.ComponentModel.ISupportInitialize)picboxNotificationItem).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNotificationTitle;
        private PictureBox picboxNotificationItem;
    }
}