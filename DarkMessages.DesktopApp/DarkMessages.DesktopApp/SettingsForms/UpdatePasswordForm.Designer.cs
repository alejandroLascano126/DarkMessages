namespace DarkMessages.DesktopApp
{
    partial class UpdatePasswordForm
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
            txtPassword = new TextBox();
            txtNewPassword = new TextBox();
            txtNewRePassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
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
            // txtPassword
            // 
            txtPassword.BackColor = SystemColors.InactiveCaption;
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 14F);
            txtPassword.Location = new Point(220, 188);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(314, 32);
            txtPassword.TabIndex = 12;
            // 
            // txtNewPassword
            // 
            txtNewPassword.BackColor = SystemColors.InactiveCaption;
            txtNewPassword.BorderStyle = BorderStyle.FixedSingle;
            txtNewPassword.Font = new Font("Segoe UI", 14F);
            txtNewPassword.Location = new Point(220, 251);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PasswordChar = '*';
            txtNewPassword.Size = new Size(314, 32);
            txtNewPassword.TabIndex = 13;
            // 
            // txtNewRePassword
            // 
            txtNewRePassword.BackColor = SystemColors.InactiveCaption;
            txtNewRePassword.BorderStyle = BorderStyle.FixedSingle;
            txtNewRePassword.Font = new Font("Segoe UI", 14F);
            txtNewRePassword.Location = new Point(220, 318);
            txtNewRePassword.Name = "txtNewRePassword";
            txtNewRePassword.PasswordChar = '*';
            txtNewRePassword.Size = new Size(314, 32);
            txtNewRePassword.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(332, 160);
            label1.Name = "label1";
            label1.Size = new Size(97, 25);
            label1.TabIndex = 15;
            label1.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label2.Location = new Point(279, 290);
            label2.Name = "label2";
            label2.Size = new Size(208, 25);
            label2.TabIndex = 16;
            label2.Text = "Repeat New Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label3.Location = new Point(307, 223);
            label3.Name = "label3";
            label3.Size = new Size(142, 25);
            label3.TabIndex = 17;
            label3.Text = "New Password";
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
            // UpdatePasswordForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(771, 544);
            Controls.Add(btnBack);
            Controls.Add(btnSaveInfo);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtNewRePassword);
            Controls.Add(txtNewPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblUpdPassword);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UpdatePasswordForm";
            Text = "SetingsForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CreateGroupButton btnQuitSession;
        private Label lblUpdPassword;
        private TextBox txtPassword;
        private TextBox txtNewPassword;
        private TextBox txtNewRePassword;
        private Label label1;
        private Label label2;
        private Label label3;
        private CreateGroupButton btnSaveInfo;
        private CreateGroupButton btnBack;
    }
}