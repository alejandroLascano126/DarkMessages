namespace DarkMessages.DesktopApp
{
    partial class MainPage
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
            panelChat = new Panel();
            panelUsers = new Panel();
            txtSearchFriends = new TextBox();
            btnBackFriends = new Button();
            lblUsername = new Label();
            panel1 = new Panel();
            btnSettings = new CreateGroupButton();
            btnNotifications = new CreateGroupButton();
            btnCreateGroup = new CreateGroupButton();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblFriends
            // 
            lblFriends.AutoSize = true;
            lblFriends.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblFriends.Location = new Point(13, 81);
            lblFriends.Name = "lblFriends";
            lblFriends.Size = new Size(52, 21);
            lblFriends.TabIndex = 1;
            lblFriends.Text = "Chats";
            // 
            // panelChat
            // 
            panelChat.Location = new Point(409, 48);
            panelChat.Name = "panelChat";
            panelChat.Size = new Size(734, 550);
            panelChat.TabIndex = 2;
            // 
            // panelUsers
            // 
            panelUsers.Location = new Point(33, 161);
            panelUsers.Name = "panelUsers";
            panelUsers.Size = new Size(360, 437);
            panelUsers.TabIndex = 3;
            // 
            // txtSearchFriends
            // 
            txtSearchFriends.BackColor = SystemColors.ControlLightLight;
            txtSearchFriends.BorderStyle = BorderStyle.FixedSingle;
            txtSearchFriends.Font = new Font("Segoe UI", 14F);
            txtSearchFriends.Location = new Point(13, 40);
            txtSearchFriends.Name = "txtSearchFriends";
            txtSearchFriends.Size = new Size(297, 32);
            txtSearchFriends.TabIndex = 4;
            txtSearchFriends.Click += txtSearchFriends_Click;
            txtSearchFriends.TextChanged += txtSearchFriends_TextChanged;
            // 
            // btnBackFriends
            // 
            btnBackFriends.BackColor = SystemColors.GradientInactiveCaption;
            btnBackFriends.BackgroundImage = Properties.Resources.replay_10080194;
            btnBackFriends.BackgroundImageLayout = ImageLayout.Stretch;
            btnBackFriends.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            btnBackFriends.FlatAppearance.BorderSize = 0;
            btnBackFriends.FlatStyle = FlatStyle.Flat;
            btnBackFriends.Location = new Point(316, 41);
            btnBackFriends.Name = "btnBackFriends";
            btnBackFriends.Size = new Size(31, 32);
            btnBackFriends.TabIndex = 5;
            btnBackFriends.UseVisualStyleBackColor = false;
            btnBackFriends.Click += btnAtrasFriends_Click;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblUsername.Location = new Point(13, 6);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(190, 30);
            lblUsername.TabIndex = 6;
            lblUsername.Text = "Nombre Apellido";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientInactiveCaption;
            panel1.Controls.Add(btnNotifications);
            panel1.Controls.Add(btnSettings);
            panel1.Controls.Add(btnCreateGroup);
            panel1.Controls.Add(txtSearchFriends);
            panel1.Controls.Add(lblUsername);
            panel1.Controls.Add(btnBackFriends);
            panel1.Controls.Add(lblFriends);
            panel1.Location = new Point(33, 48);
            panel1.Name = "panel1";
            panel1.Size = new Size(360, 116);
            panel1.TabIndex = 4;
            // 
            // btnSettings
            // 
            btnSettings.BackColor = Color.DodgerBlue;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.ForeColor = Color.White;
            btnSettings.Location = new Point(173, 79);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(84, 29);
            btnSettings.TabIndex = 8;
            btnSettings.Text = "Settings";
            btnSettings.UseVisualStyleBackColor = false;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnNotifications
            // 
            btnNotifications.BackColor = Color.DodgerBlue;
            btnNotifications.FlatAppearance.BorderSize = 0;
            btnNotifications.FlatStyle = FlatStyle.Flat;
            btnNotifications.ForeColor = Color.White;
            btnNotifications.Location = new Point(83, 79);
            btnNotifications.Name = "btnNotifications";
            btnNotifications.Size = new Size(84, 29);
            btnNotifications.TabIndex = 9;
            btnNotifications.Text = "News";
            btnNotifications.UseVisualStyleBackColor = false;
            btnNotifications.Click += btnNotifications_Click;
            // 
            // btnCreateGroup
            // 
            btnCreateGroup.BackColor = Color.DodgerBlue;
            btnCreateGroup.FlatAppearance.BorderSize = 0;
            btnCreateGroup.FlatStyle = FlatStyle.Flat;
            btnCreateGroup.ForeColor = Color.White;
            btnCreateGroup.Location = new Point(263, 79);
            btnCreateGroup.Name = "btnCreateGroup";
            btnCreateGroup.Size = new Size(84, 29);
            btnCreateGroup.TabIndex = 7;
            btnCreateGroup.Text = "New Group";
            btnCreateGroup.UseVisualStyleBackColor = false;
            btnCreateGroup.Click += btnCreateGroup_Click;
            // 
            // MainPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(1174, 623);
            Controls.Add(panel1);
            Controls.Add(panelUsers);
            Controls.Add(panelChat);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainPage";
            Text = "MainPage";
            Load += MainPage_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label lblFriends;
        private Panel panelChat;
        private Panel panelUsers;
        private TextBox txtSearchFriends;
        private Button btnBackFriends;
        private Label lblUsername;
        private Panel panel1;
        private CreateGroupButton btnCreateGroup;
        private CreateGroupButton btnSettings;
        private CreateGroupButton btnNotifications;
    }
}