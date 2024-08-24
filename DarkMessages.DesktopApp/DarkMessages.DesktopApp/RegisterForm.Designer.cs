namespace DarkMessages.DesktopApp
{
    partial class RegisterForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            groupBox1 = new GroupBox();
            txtLastname = new TextBox();
            txtName = new TextBox();
            label7 = new Label();
            label6 = new Label();
            cbCountry = new ComboBox();
            cbLanguages = new ComboBox();
            btnBackRegister = new Button();
            btnRegisterUser = new Button();
            txtRemail = new TextBox();
            txtRpassword = new TextBox();
            txtRusername = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 82);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 0;
            label1.Text = "username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(251, 82);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 1;
            label2.Text = "password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(52, 126);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 2;
            label3.Text = "email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(52, 170);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 3;
            label4.Text = "languages";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(251, 170);
            label5.Name = "label5";
            label5.Size = new Size(48, 15);
            label5.TabIndex = 4;
            label5.Text = "country";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.None;
            groupBox1.AutoSize = true;
            groupBox1.Controls.Add(txtLastname);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(cbCountry);
            groupBox1.Controls.Add(cbLanguages);
            groupBox1.Controls.Add(btnBackRegister);
            groupBox1.Controls.Add(btnRegisterUser);
            groupBox1.Controls.Add(txtRemail);
            groupBox1.Controls.Add(txtRpassword);
            groupBox1.Controls.Add(txtRusername);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(362, 170);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(473, 271);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Register user";
            // 
            // txtLastname
            // 
            txtLastname.Location = new Point(251, 56);
            txtLastname.Name = "txtLastname";
            txtLastname.Size = new Size(171, 23);
            txtLastname.TabIndex = 17;
            // 
            // txtName
            // 
            txtName.Location = new Point(52, 56);
            txtName.Name = "txtName";
            txtName.Size = new Size(171, 23);
            txtName.TabIndex = 16;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(251, 38);
            label7.Name = "label7";
            label7.Size = new Size(55, 15);
            label7.TabIndex = 15;
            label7.Text = "lastname";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(52, 38);
            label6.Name = "label6";
            label6.Size = new Size(37, 15);
            label6.TabIndex = 14;
            label6.Text = "name";
            // 
            // cbCountry
            // 
            cbCountry.FormattingEnabled = true;
            cbCountry.Location = new Point(251, 188);
            cbCountry.Name = "cbCountry";
            cbCountry.Size = new Size(171, 23);
            cbCountry.TabIndex = 13;
            // 
            // cbLanguages
            // 
            cbLanguages.FormattingEnabled = true;
            cbLanguages.Location = new Point(52, 188);
            cbLanguages.Name = "cbLanguages";
            cbLanguages.Size = new Size(171, 23);
            cbLanguages.TabIndex = 12;
            // 
            // btnBackRegister
            // 
            btnBackRegister.BackColor = SystemColors.Info;
            btnBackRegister.Location = new Point(250, 226);
            btnBackRegister.Name = "btnBackRegister";
            btnBackRegister.Size = new Size(75, 23);
            btnBackRegister.TabIndex = 11;
            btnBackRegister.Text = "Back";
            btnBackRegister.UseVisualStyleBackColor = false;
            btnBackRegister.Click += btnBackRegister_Click;
            // 
            // btnRegisterUser
            // 
            btnRegisterUser.BackColor = SystemColors.Info;
            btnRegisterUser.Location = new Point(346, 226);
            btnRegisterUser.Name = "btnRegisterUser";
            btnRegisterUser.Size = new Size(75, 23);
            btnRegisterUser.TabIndex = 10;
            btnRegisterUser.Text = "Register";
            btnRegisterUser.UseVisualStyleBackColor = false;
            btnRegisterUser.Click += btnRegisterUser_Click;
            // 
            // txtRemail
            // 
            txtRemail.Location = new Point(52, 144);
            txtRemail.Name = "txtRemail";
            txtRemail.Size = new Size(370, 23);
            txtRemail.TabIndex = 7;
            // 
            // txtRpassword
            // 
            txtRpassword.Location = new Point(251, 100);
            txtRpassword.Name = "txtRpassword";
            txtRpassword.PasswordChar = '*';
            txtRpassword.Size = new Size(171, 23);
            txtRpassword.TabIndex = 6;
            // 
            // txtRusername
            // 
            txtRusername.Location = new Point(52, 100);
            txtRusername.Name = "txtRusername";
            txtRusername.Size = new Size(171, 23);
            txtRusername.TabIndex = 5;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1158, 612);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RegisterForm";
            Text = "RegisterForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private GroupBox groupBox1;
        private Button btnRegisterUser;
        private TextBox txtRemail;
        private TextBox txtRpassword;
        private TextBox txtRusername;
        private Button btnBackRegister;
        private ComboBox cbCountry;
        private ComboBox cbLanguages;
        private TextBox txtLastname;
        private TextBox txtName;
        private Label label7;
        private Label label6;
    }
}