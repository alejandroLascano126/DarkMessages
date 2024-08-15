namespace DarkMessages.DesktopApp
{
    partial class ProfileInformationForm
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
            lblProfileInfo = new Label();
            btnSaveInfo = new CreateGroupButton();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtName = new TextBox();
            txtLastname = new TextBox();
            txtEmail = new TextBox();
            cbCountries = new ComboBox();
            SuspendLayout();
            // 
            // lblProfileInfo
            // 
            lblProfileInfo.AutoSize = true;
            lblProfileInfo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblProfileInfo.Location = new Point(45, 33);
            lblProfileInfo.Name = "lblProfileInfo";
            lblProfileInfo.Size = new Size(113, 25);
            lblProfileInfo.TabIndex = 1;
            lblProfileInfo.Text = "Profile Info";
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
            btnSaveInfo.TabIndex = 3;
            btnSaveInfo.Text = "Save";
            btnSaveInfo.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(45, 84);
            label1.Name = "label1";
            label1.Size = new Size(64, 25);
            label1.TabIndex = 4;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label2.Location = new Point(45, 288);
            label2.Name = "label2";
            label2.Size = new Size(86, 25);
            label2.TabIndex = 5;
            label2.Text = "Country";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label3.Location = new Point(45, 188);
            label3.Name = "label3";
            label3.Size = new Size(59, 25);
            label3.TabIndex = 6;
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label4.Location = new Point(371, 84);
            label4.Name = "label4";
            label4.Size = new Size(104, 25);
            label4.TabIndex = 7;
            label4.Text = "Last Name";
            // 
            // txtName
            // 
            txtName.BackColor = SystemColors.InactiveCaption;
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Font = new Font("Segoe UI", 14F);
            txtName.Location = new Point(45, 128);
            txtName.Name = "txtName";
            txtName.Size = new Size(314, 32);
            txtName.TabIndex = 11;
            // 
            // txtLastname
            // 
            txtLastname.BackColor = SystemColors.InactiveCaption;
            txtLastname.BorderStyle = BorderStyle.FixedSingle;
            txtLastname.Font = new Font("Segoe UI", 14F);
            txtLastname.Location = new Point(371, 128);
            txtLastname.Name = "txtLastname";
            txtLastname.Size = new Size(314, 32);
            txtLastname.TabIndex = 12;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = SystemColors.InactiveCaption;
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 14F);
            txtEmail.Location = new Point(45, 236);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(640, 32);
            txtEmail.TabIndex = 13;
            // 
            // cbCountries
            // 
            cbCountries.BackColor = SystemColors.InactiveCaption;
            cbCountries.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCountries.Font = new Font("Segoe UI", 14F);
            cbCountries.FormattingEnabled = true;
            cbCountries.Location = new Point(45, 345);
            cbCountries.Name = "cbCountries";
            cbCountries.Size = new Size(230, 33);
            cbCountries.TabIndex = 14;
            // 
            // ProfileInformationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(771, 544);
            Controls.Add(cbCountries);
            Controls.Add(txtEmail);
            Controls.Add(txtLastname);
            Controls.Add(txtName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnSaveInfo);
            Controls.Add(lblProfileInfo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ProfileInformationForm";
            Text = "SetingsForm";
            Load += ProfileInformationForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CreateGroupButton btnSaveInfo;
        private Label lblProfileInfo;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtName;
        private TextBox txtLastname;
        private TextBox txtEmail;
        private ComboBox cbCountries;
    }
}