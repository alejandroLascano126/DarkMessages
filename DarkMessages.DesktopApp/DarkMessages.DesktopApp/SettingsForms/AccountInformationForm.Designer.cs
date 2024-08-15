namespace DarkMessages.DesktopApp
{
    partial class AccountInformationForm
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
            lblAccountInfo = new Label();
            SuspendLayout();
            // 
            // lblAccountInfo
            // 
            lblAccountInfo.AutoSize = true;
            lblAccountInfo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblAccountInfo.Location = new Point(45, 33);
            lblAccountInfo.Name = "lblAccountInfo";
            lblAccountInfo.Size = new Size(128, 25);
            lblAccountInfo.TabIndex = 1;
            lblAccountInfo.Text = "Account Info";
            // 
            // AccountInformationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(771, 544);
            Controls.Add(lblAccountInfo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AccountInformationForm";
            Text = "SetingsForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CreateGroupButton btnQuitSession;
        private Label lblAccountInfo;
    }
}