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
            SuspendLayout();
            // 
            // lblFriends
            // 
            lblFriends.AutoSize = true;
            lblFriends.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblFriends.Location = new Point(33, 16);
            lblFriends.Name = "lblFriends";
            lblFriends.Size = new Size(77, 25);
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
            panelUsers.Location = new Point(33, 102);
            panelUsers.Name = "panelUsers";
            panelUsers.Size = new Size(360, 496);
            panelUsers.TabIndex = 3;
            // 
            // txtSearchFriends
            // 
            txtSearchFriends.BackColor = SystemColors.GradientInactiveCaption;
            txtSearchFriends.BorderStyle = BorderStyle.FixedSingle;
            txtSearchFriends.Font = new Font("Segoe UI", 14F);
            txtSearchFriends.Location = new Point(33, 48);
            txtSearchFriends.Name = "txtSearchFriends";
            txtSearchFriends.Size = new Size(323, 32);
            txtSearchFriends.TabIndex = 4;
            txtSearchFriends.Click += txtSearchFriends_Click;
            txtSearchFriends.TextChanged += txtSearchFriends_TextChanged;
            // 
            // btnBackFriends
            // 
            btnBackFriends.BackColor = SystemColors.ActiveCaption;
            btnBackFriends.BackgroundImage = Properties.Resources.replay_10080194;
            btnBackFriends.BackgroundImageLayout = ImageLayout.Stretch;
            btnBackFriends.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            btnBackFriends.FlatAppearance.BorderSize = 0;
            btnBackFriends.FlatStyle = FlatStyle.Flat;
            btnBackFriends.Location = new Point(362, 49);
            btnBackFriends.Name = "btnBackFriends";
            btnBackFriends.Size = new Size(31, 31);
            btnBackFriends.TabIndex = 5;
            btnBackFriends.UseVisualStyleBackColor = false;
            btnBackFriends.Click += btnAtrasFriends_Click;
            // 
            // MainPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1174, 623);
            Controls.Add(btnBackFriends);
            Controls.Add(txtSearchFriends);
            Controls.Add(panelUsers);
            Controls.Add(panelChat);
            Controls.Add(lblFriends);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainPage";
            Text = "MainPage";
            Load += MainPage_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblFriends;
        private Panel panelChat;
        private Panel panelUsers;
        private TextBox txtSearchFriends;
        private Button btnBackFriends;
    }
}