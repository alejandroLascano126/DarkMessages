namespace DarkMessages.DesktopApp
{
    partial class ChatList
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
            SuspendLayout();
            // 
            // flpItemsUser
            // 
            flpItemsUser.BackColor = SystemColors.GradientInactiveCaption;
            flpItemsUser.Location = new Point(0, 0);
            flpItemsUser.Name = "flpItemsUser";
            flpItemsUser.Size = new Size(348, 450);
            flpItemsUser.TabIndex = 0;
            flpItemsUser.MouseWheel += FlpItemsUser_MouseWheel;
            // 
            // FriendsList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(347, 450);
            Controls.Add(flpItemsUser);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FriendsList";
            Text = "FriendsList";
            Load += FriendsList_Load;
            ResumeLayout(false);
        }


        #endregion

        private FlowLayoutPanel flpItemsUser;
    }
}