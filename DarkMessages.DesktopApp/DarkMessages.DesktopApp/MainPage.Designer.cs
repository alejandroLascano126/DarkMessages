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
            flpItemsUser = new FlowLayoutPanel();
            lblFriends = new Label();
            panelChat = new Panel();
            SuspendLayout();
            // 
            // flpItemsUser
            // 
            flpItemsUser.AutoScroll = true;
            flpItemsUser.BackColor = SystemColors.GradientInactiveCaption;
            flpItemsUser.Location = new Point(32, 48);
            flpItemsUser.Name = "flpItemsUser";
            flpItemsUser.Size = new Size(360, 550);
            flpItemsUser.TabIndex = 0;
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
            // MainPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1174, 623);
            Controls.Add(panelChat);
            Controls.Add(lblFriends);
            Controls.Add(flpItemsUser);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainPage";
            Text = "MainPage";
            Load += MainPage_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flpItemsUser;
        private Label lblFriends;
        private Panel panelChat;
    }
}