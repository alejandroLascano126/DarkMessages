namespace DarkMessages.DesktopApp
{
    partial class UsersQueryView
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
            flpUsersQuery = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // flpUsersQuery
            // 
            flpUsersQuery.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            flpUsersQuery.BackColor = SystemColors.GradientInactiveCaption;
            flpUsersQuery.Location = new Point(0, -1);
            flpUsersQuery.Name = "flpUsersQuery";
            flpUsersQuery.Size = new Size(347, 450);
            flpUsersQuery.TabIndex = 0;
            flpUsersQuery.ClientSizeChanged += flpUsersQuery_ClientSizeChanged;
            flpUsersQuery.MouseWheel += FlpUsersQuery_MouseWheel;
            // 
            // UsersQueryView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(347, 450);
            Controls.Add(flpUsersQuery);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UsersQueryView";
            Text = "UsersQueryView";
            Load += UsersQueryView_Load;
            ResumeLayout(false);
        }


        #endregion

        private FlowLayoutPanel flpUsersQuery;
    }
}