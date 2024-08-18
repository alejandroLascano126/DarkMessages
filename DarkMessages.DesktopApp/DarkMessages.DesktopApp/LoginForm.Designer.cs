namespace DarkMessages.DesktopApp
{
    partial class LoginForm
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
            txtUsernameLogin = new TextBox();
            txtPasswordLogin = new TextBox();
            lblUsernameLogin = new Label();
            lblPasswordLogin = new Label();
            groupBox1 = new GroupBox();
            btnLogin = new CreateGroupButton();
            btnRegister = new CreateGroupButton();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // txtUsernameLogin
            // 
            txtUsernameLogin.BackColor = SystemColors.HighlightText;
            txtUsernameLogin.BorderStyle = BorderStyle.FixedSingle;
            txtUsernameLogin.Location = new Point(273, 84);
            txtUsernameLogin.Name = "txtUsernameLogin";
            txtUsernameLogin.Size = new Size(100, 23);
            txtUsernameLogin.TabIndex = 0;
            // 
            // txtPasswordLogin
            // 
            txtPasswordLogin.BackColor = SystemColors.HighlightText;
            txtPasswordLogin.BorderStyle = BorderStyle.FixedSingle;
            txtPasswordLogin.Location = new Point(273, 127);
            txtPasswordLogin.Name = "txtPasswordLogin";
            txtPasswordLogin.PasswordChar = '*';
            txtPasswordLogin.Size = new Size(100, 23);
            txtPasswordLogin.TabIndex = 1;
            // 
            // lblUsernameLogin
            // 
            lblUsernameLogin.AutoSize = true;
            lblUsernameLogin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUsernameLogin.Location = new Point(103, 87);
            lblUsernameLogin.Name = "lblUsernameLogin";
            lblUsernameLogin.Size = new Size(62, 15);
            lblUsernameLogin.TabIndex = 2;
            lblUsernameLogin.Text = "username";
            // 
            // lblPasswordLogin
            // 
            lblPasswordLogin.AutoSize = true;
            lblPasswordLogin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPasswordLogin.Location = new Point(106, 130);
            lblPasswordLogin.Name = "lblPasswordLogin";
            lblPasswordLogin.Size = new Size(59, 15);
            lblPasswordLogin.TabIndex = 3;
            lblPasswordLogin.Text = "password";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.GradientActiveCaption;
            groupBox1.Controls.Add(btnLogin);
            groupBox1.Controls.Add(txtUsernameLogin);
            groupBox1.Controls.Add(btnRegister);
            groupBox1.Controls.Add(lblUsernameLogin);
            groupBox1.Controls.Add(txtPasswordLogin);
            groupBox1.Controls.Add(lblPasswordLogin);
            groupBox1.Location = new Point(362, 179);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(458, 264);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Login";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.DodgerBlue;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(343, 218);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(79, 29);
            btnLogin.TabIndex = 12;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += button1_Click;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.DodgerBlue;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(246, 218);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(79, 29);
            btnRegister.TabIndex = 11;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(1156, 628);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            Text = "LoginForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtUsernameLogin;
        private TextBox txtPasswordLogin;
        private Label lblUsernameLogin;
        private Label lblPasswordLogin;
        private GroupBox groupBox1;
        private CreateGroupButton btnRegister;
        private CreateGroupButton btnLogin;
    }
}