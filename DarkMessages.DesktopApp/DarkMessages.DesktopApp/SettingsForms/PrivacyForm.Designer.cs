namespace DarkMessages.DesktopApp
{
    partial class PrivacyForm
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
            lblPrivacy = new Label();
            SuspendLayout();
            // 
            // lblPrivacy
            // 
            lblPrivacy.AutoSize = true;
            lblPrivacy.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblPrivacy.Location = new Point(45, 33);
            lblPrivacy.Name = "lblPrivacy";
            lblPrivacy.Size = new Size(76, 25);
            lblPrivacy.TabIndex = 1;
            lblPrivacy.Text = "Privacy";
            // 
            // PrivacyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(771, 544);
            Controls.Add(lblPrivacy);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PrivacyForm";
            Text = "SetingsForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CreateGroupButton btnQuitSession;
        private Label lblPrivacy;
    }
}