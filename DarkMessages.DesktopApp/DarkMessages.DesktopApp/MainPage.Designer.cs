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
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblFriends
            // 
            lblFriends.AutoSize = true;
            lblFriends.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblFriends.Location = new Point(13, 81);
            lblFriends.Name = "lblFriends";
            lblFriends.Size = new Size(65, 21);
            lblFriends.TabIndex = 1;
            lblFriends.Text = "Friends";
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
            panelUsers.Location = new Point(33, 153);
            panelUsers.Name = "panelUsers";
            panelUsers.Size = new Size(360, 445);
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
            panel1.Controls.Add(txtSearchFriends);
            panel1.Controls.Add(lblUsername);
            panel1.Controls.Add(btnBackFriends);
            panel1.Controls.Add(lblFriends);
            panel1.Location = new Point(33, 48);
            panel1.Name = "panel1";
            panel1.Size = new Size(360, 107);
            panel1.TabIndex = 4;
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
    }
}