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
            panelChat = new Panel();
            panelUsers = new Panel();
            txtSearchFriends = new TextBox();
            btnSettings = new Button();
            lblUsername = new Label();
            panel1 = new Panel();
            btnContacts = new CreateGroupButton();
            btnCreateGroup = new CreateGroupButton();
            btnNotifications = new CreateGroupButton();
            btnChats = new CreateGroupButton();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelChat
            // 
            panelChat.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelChat.AutoSize = true;
            panelChat.Location = new Point(410, 24);
            panelChat.Name = "panelChat";
            panelChat.Size = new Size(733, 574);
            panelChat.TabIndex = 2;
            // 
            // panelUsers
            // 
            panelUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panelUsers.BackColor = SystemColors.InactiveCaption;
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
            txtSearchFriends.PlaceholderText = " Search";
            txtSearchFriends.Size = new Size(334, 32);
            txtSearchFriends.TabIndex = 4;
            txtSearchFriends.Click += txtSearchFriends_Click;
            txtSearchFriends.TextChanged += txtSearchFriends_TextChanged;
            // 
            // btnSettings
            // 
            btnSettings.BackColor = SystemColors.GradientInactiveCaption;
            btnSettings.BackgroundImage = Properties.Resources.more_options;
            btnSettings.BackgroundImageLayout = ImageLayout.Stretch;
            btnSettings.Cursor = Cursors.Hand;
            btnSettings.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnSettings.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Location = new Point(316, 9);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(31, 32);
            btnSettings.TabIndex = 5;
            btnSettings.UseVisualStyleBackColor = false;
            btnSettings.Click += btnSettings_Click;
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
            panel1.Controls.Add(btnContacts);
            panel1.Controls.Add(btnCreateGroup);
            panel1.Controls.Add(txtSearchFriends);
            panel1.Controls.Add(lblUsername);
            panel1.Controls.Add(btnNotifications);
            panel1.Controls.Add(btnSettings);
            panel1.Controls.Add(btnChats);
            panel1.Location = new Point(33, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(360, 140);
            panel1.TabIndex = 4;
            // 
            // btnContacts
            // 
            btnContacts.BackColor = Color.DodgerBlue;
            btnContacts.FlatAppearance.BorderSize = 0;
            btnContacts.FlatStyle = FlatStyle.Flat;
            btnContacts.ForeColor = Color.White;
            btnContacts.Location = new Point(98, 78);
            btnContacts.Name = "btnContacts";
            btnContacts.Size = new Size(79, 29);
            btnContacts.TabIndex = 8;
            btnContacts.Text = "Contacts";
            btnContacts.UseVisualStyleBackColor = false;
            btnContacts.Click += btnContacts_Click;
            // 
            // btnCreateGroup
            // 
            btnCreateGroup.BackColor = Color.DodgerBlue;
            btnCreateGroup.FlatAppearance.BorderSize = 0;
            btnCreateGroup.FlatStyle = FlatStyle.Flat;
            btnCreateGroup.ForeColor = Color.White;
            btnCreateGroup.Location = new Point(268, 78);
            btnCreateGroup.Name = "btnCreateGroup";
            btnCreateGroup.Size = new Size(79, 29);
            btnCreateGroup.TabIndex = 7;
            btnCreateGroup.Text = "New Group";
            btnCreateGroup.UseVisualStyleBackColor = false;
            btnCreateGroup.Click += btnCreateGroup_Click;
            // 
            // btnNotifications
            // 
            btnNotifications.BackColor = Color.DodgerBlue;
            btnNotifications.FlatAppearance.BorderSize = 0;
            btnNotifications.FlatStyle = FlatStyle.Flat;
            btnNotifications.ForeColor = Color.White;
            btnNotifications.Location = new Point(183, 78);
            btnNotifications.Name = "btnNotifications";
            btnNotifications.Size = new Size(79, 29);
            btnNotifications.TabIndex = 9;
            btnNotifications.Text = "News";
            btnNotifications.UseVisualStyleBackColor = false;
            btnNotifications.Click += btnNotifications_Click;
            // 
            // btnChats
            // 
            btnChats.BackColor = Color.DodgerBlue;
            btnChats.FlatAppearance.BorderSize = 0;
            btnChats.FlatStyle = FlatStyle.Flat;
            btnChats.ForeColor = Color.White;
            btnChats.Location = new Point(13, 78);
            btnChats.Name = "btnChats";
            btnChats.Size = new Size(79, 29);
            btnChats.TabIndex = 10;
            btnChats.Text = "Chats";
            btnChats.UseVisualStyleBackColor = false;
            btnChats.Click += btnChats_Click;
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
            PerformLayout();
        }

        #endregion
        private Panel panelChat;
        private Panel panelUsers;
        private TextBox txtSearchFriends;
        private Button btnSettings;
        private Label lblUsername;
        private Panel panel1;
        private CreateGroupButton btnCreateGroup;
        private CreateGroupButton btnContacts;
        private CreateGroupButton btnNotifications;
        private CreateGroupButton btnChats;
    }
}