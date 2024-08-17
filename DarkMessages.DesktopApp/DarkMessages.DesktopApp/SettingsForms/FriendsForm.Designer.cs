namespace DarkMessages.DesktopApp
{
    partial class FriendsForm
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
            lblFriends = new Label();
            SuspendLayout();
            // 
            // lblFriends
            // 
            lblFriends.AutoSize = true;
            lblFriends.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblFriends.Location = new Point(45, 33);
            lblFriends.Name = "lblFriends";
            lblFriends.Size = new Size(77, 25);
            lblFriends.TabIndex = 1;
            lblFriends.Text = "Friends";
            // 
            // FriendsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(771, 544);
            Controls.Add(lblFriends);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FriendsForm";
            Text = "SetingsForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CreateGroupButton btnQuitSession;
        private Label lblFriends;
    }
}