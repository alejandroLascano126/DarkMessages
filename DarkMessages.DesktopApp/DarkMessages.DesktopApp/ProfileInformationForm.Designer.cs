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
            label3 = new Label();
            label4 = new Label();
            txtName = new TextBox();
            txtLastname = new TextBox();
            txtEmail = new TextBox();
            label2 = new Label();
            btbUpdatePhoto = new CreateGroupButton();
            picBoxProfilePicture = new personalizedComponents.Settings.RoundedPictureBox();
            ((System.ComponentModel.ISupportInitialize)picBoxProfilePicture).BeginInit();
            SuspendLayout();
            // 
            // lblProfileInfo
            // 
            lblProfileInfo.Anchor = AnchorStyles.None;
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
            btnSaveInfo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSaveInfo.BackColor = Color.DodgerBlue;
            btnSaveInfo.FlatAppearance.BorderSize = 0;
            btnSaveInfo.FlatStyle = FlatStyle.Flat;
            btnSaveInfo.ForeColor = Color.White;
            btnSaveInfo.Location = new Point(579, 468);
            btnSaveInfo.Name = "btnSaveInfo";
            btnSaveInfo.Size = new Size(106, 35);
            btnSaveInfo.TabIndex = 3;
            btnSaveInfo.Text = "Save";
            btnSaveInfo.UseVisualStyleBackColor = false;
            btnSaveInfo.Click += btnSaveInfo_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(45, 269);
            label1.Name = "label1";
            label1.Size = new Size(64, 25);
            label1.TabIndex = 4;
            label1.Text = "Name";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label3.Location = new Point(45, 373);
            label3.Name = "label3";
            label3.Size = new Size(59, 25);
            label3.TabIndex = 6;
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label4.Location = new Point(371, 269);
            label4.Name = "label4";
            label4.Size = new Size(104, 25);
            label4.TabIndex = 7;
            label4.Text = "Last Name";
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.None;
            txtName.BackColor = SystemColors.InactiveCaption;
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Font = new Font("Segoe UI", 14F);
            txtName.Location = new Point(45, 313);
            txtName.Name = "txtName";
            txtName.Size = new Size(314, 32);
            txtName.TabIndex = 11;
            // 
            // txtLastname
            // 
            txtLastname.Anchor = AnchorStyles.None;
            txtLastname.BackColor = SystemColors.InactiveCaption;
            txtLastname.BorderStyle = BorderStyle.FixedSingle;
            txtLastname.Font = new Font("Segoe UI", 14F);
            txtLastname.Location = new Point(371, 313);
            txtLastname.Name = "txtLastname";
            txtLastname.Size = new Size(314, 32);
            txtLastname.TabIndex = 12;
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.None;
            txtEmail.BackColor = SystemColors.InactiveCaption;
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Enabled = false;
            txtEmail.Font = new Font("Segoe UI", 14F);
            txtEmail.Location = new Point(45, 421);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(640, 32);
            txtEmail.TabIndex = 13;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label2.Location = new Point(45, 69);
            label2.Name = "label2";
            label2.Size = new Size(66, 25);
            label2.TabIndex = 14;
            label2.Text = "Photo";
            // 
            // btbUpdatePhoto
            // 
            btbUpdatePhoto.Anchor = AnchorStyles.None;
            btbUpdatePhoto.BackColor = Color.RoyalBlue;
            btbUpdatePhoto.FlatAppearance.BorderSize = 0;
            btbUpdatePhoto.FlatStyle = FlatStyle.Flat;
            btbUpdatePhoto.ForeColor = Color.White;
            btbUpdatePhoto.Location = new Point(201, 220);
            btbUpdatePhoto.Name = "btbUpdatePhoto";
            btbUpdatePhoto.Size = new Size(76, 35);
            btbUpdatePhoto.TabIndex = 16;
            btbUpdatePhoto.Text = "Update";
            btbUpdatePhoto.UseVisualStyleBackColor = false;
            btbUpdatePhoto.Click += btbUpdatePhoto_Click;
            // 
            // picBoxProfilePicture
            // 
            picBoxProfilePicture.Anchor = AnchorStyles.None;
            picBoxProfilePicture.BackgroundImageLayout = ImageLayout.Stretch;
            picBoxProfilePicture.BorderStyle = BorderStyle.FixedSingle;
            picBoxProfilePicture.Image = Properties.Resources.user_solid;
            picBoxProfilePicture.Location = new Point(45, 105);
            picBoxProfilePicture.Name = "picBoxProfilePicture";
            picBoxProfilePicture.Size = new Size(150, 150);
            picBoxProfilePicture.SizeMode = PictureBoxSizeMode.StretchImage;
            picBoxProfilePicture.TabIndex = 17;
            picBoxProfilePicture.TabStop = false;
            // 
            // ProfileInformationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(771, 544);
            Controls.Add(picBoxProfilePicture);
            Controls.Add(btbUpdatePhoto);
            Controls.Add(label2);
            Controls.Add(txtEmail);
            Controls.Add(txtLastname);
            Controls.Add(txtName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(btnSaveInfo);
            Controls.Add(lblProfileInfo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ProfileInformationForm";
            Text = "SetingsForm";
            Load += ProfileInformationForm_Load;
            ((System.ComponentModel.ISupportInitialize)picBoxProfilePicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CreateGroupButton btnSaveInfo;
        private Label lblProfileInfo;
        private Label label1;
        private Label label3;
        private Label label4;
        private TextBox txtName;
        private TextBox txtLastname;
        private TextBox txtEmail;
        private Label label2;
        private CreateGroupButton btbUpdatePhoto;
        private personalizedComponents.Settings.RoundedPictureBox picBoxProfilePicture;
    }
}