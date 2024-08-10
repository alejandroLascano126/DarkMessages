namespace DarkMessages.DesktopApp
{
    partial class GroupMessageCell
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            messageCell = new MessageCell();
            lblNameUser = new Label();
            SuspendLayout();
            // 
            // messageCell
            // 
            messageCell.BackColor = SystemColors.GradientActiveCaption;
            messageCell.Description = null;
            messageCell.FlatAppearance.BorderSize = 0;
            messageCell.FlatStyle = FlatStyle.Flat;
            messageCell.ForeColor = Color.White;
            messageCell.Location = new Point(0, 18);
            messageCell.Name = "messageCell";
            messageCell.Size = new Size(150, 50);
            messageCell.TabIndex = 0;
            messageCell.Title = null;
            messageCell.UseVisualStyleBackColor = false;
            // 
            // lblNameUser
            // 
            lblNameUser.AutoSize = true;
            lblNameUser.Location = new Point(3, 0);
            lblNameUser.Name = "lblNameUser";
            lblNameUser.Size = new Size(37, 15);
            lblNameUser.TabIndex = 1;
            lblNameUser.Text = "name";
            // 
            // GroupMessageCell
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            Controls.Add(lblNameUser);
            Controls.Add(messageCell);
            Name = "GroupMessageCell";
            Size = new Size(152, 69);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MessageCell messageCell;
        private Label lblNameUser;
    }
}
