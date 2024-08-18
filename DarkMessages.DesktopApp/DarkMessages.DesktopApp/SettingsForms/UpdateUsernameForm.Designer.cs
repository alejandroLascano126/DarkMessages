namespace DarkMessages.DesktopApp
{
    partial class UpdateUsernameForm
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
            lblUpdPassword = new Label();
            txtUsername = new TextBox();
            label1 = new Label();
            btnSaveInfo = new CreateGroupButton();
            btnBack = new CreateGroupButton();
            SuspendLayout();
            // 
            // lblUpdPassword
            // 
            lblUpdPassword.AutoSize = true;
            lblUpdPassword.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblUpdPassword.Location = new Point(45, 33);
            lblUpdPassword.Name = "lblUpdPassword";
            lblUpdPassword.Size = new Size(167, 25);
            lblUpdPassword.TabIndex = 1;
            lblUpdPassword.Text = "Update Password";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = SystemColors.InactiveCaption;
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font = new Font("Segoe UI", 14F);
            txtUsername.Location = new Point(220, 257);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(314, 32);
            txtUsername.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(332, 229);
            label1.Name = "label1";
            label1.Size = new Size(101, 25);
            label1.TabIndex = 15;
            label1.Text = "Username";
            // 
            // btnSaveInfo
            // 
            btnSaveInfo.BackColor = Color.DodgerBlue;
            btnSaveInfo.FlatAppearance.BorderSize = 0;
            btnSaveInfo.FlatStyle = FlatStyle.Flat;
            btnSaveInfo.ForeColor = Color.White;
            btnSaveInfo.Location = new Point(579, 467);
            btnSaveInfo.Name = "btnSaveInfo";
            btnSaveInfo.Size = new Size(106, 35);
            btnSaveInfo.TabIndex = 18;
            btnSaveInfo.Text = "Save";
            btnSaveInfo.UseVisualStyleBackColor = false;
            btnSaveInfo.Click += btnSaveInfo_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.DodgerBlue;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(458, 467);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(106, 35);
            btnBack.TabIndex = 19;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // UpdateUsernameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(771, 544);
            Controls.Add(btnBack);
            Controls.Add(btnSaveInfo);
            Controls.Add(label1);
            Controls.Add(txtUsername);
            Controls.Add(lblUpdPassword);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UpdateUsernameForm";
            Text = "SetingsForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CreateGroupButton btnQuitSession;
        private Label lblUpdPassword;
        private TextBox txtUsername;
        private Label label1;
        private CreateGroupButton btnSaveInfo;
        private CreateGroupButton btnBack;
    }
}