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
            btnLogin = new Button();
            btnRegister = new Button();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // txtUsernameLogin
            // 
            txtUsernameLogin.BackColor = SystemColors.HighlightText;
            txtUsernameLogin.Location = new Point(273, 84);
            txtUsernameLogin.Name = "txtUsernameLogin";
            txtUsernameLogin.Size = new Size(100, 23);
            txtUsernameLogin.TabIndex = 0;
            // 
            // txtPasswordLogin
            // 
            txtPasswordLogin.BackColor = SystemColors.HighlightText;
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
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.Info;
            btnLogin.Location = new Point(348, 221);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 23);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += button1_Click;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = SystemColors.Info;
            btnRegister.Location = new Point(255, 221);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(75, 23);
            btnRegister.TabIndex = 5;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtUsernameLogin);
            groupBox1.Controls.Add(btnRegister);
            groupBox1.Controls.Add(lblUsernameLogin);
            groupBox1.Controls.Add(btnLogin);
            groupBox1.Controls.Add(txtPasswordLogin);
            groupBox1.Controls.Add(lblPasswordLogin);
            groupBox1.Location = new Point(362, 179);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(458, 264);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Login";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
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
        private Button btnLogin;
        private Button btnRegister;
        private GroupBox groupBox1;
    }
}