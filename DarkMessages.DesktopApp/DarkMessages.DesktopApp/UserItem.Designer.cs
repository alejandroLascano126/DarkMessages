namespace DarkMessages.DesktopApp
{
    partial class UserItem
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
            lblname = new Label();
            lblDescripcionItemUser = new Label();
            picboxUserItem = new personalizedComponents.Settings.RoundedPictureBox();
            ((System.ComponentModel.ISupportInitialize)picboxUserItem).BeginInit();
            SuspendLayout();
            // 
            // lblname
            // 
            lblname.AutoSize = true;
            lblname.Font = new Font("Segoe UI", 10F);
            lblname.Location = new Point(95, 12);
            lblname.Name = "lblname";
            lblname.Size = new Size(120, 19);
            lblname.TabIndex = 0;
            lblname.Text = "Alejandro Lascano";
            // 
            // lblDescripcionItemUser
            // 
            lblDescripcionItemUser.AutoSize = true;
            lblDescripcionItemUser.Location = new Point(95, 40);
            lblDescripcionItemUser.Name = "lblDescripcionItemUser";
            lblDescripcionItemUser.Size = new Size(184, 15);
            lblDescripcionItemUser.TabIndex = 2;
            lblDescripcionItemUser.Text = "Como la pasaste la ultima noche?";
            // 
            // picboxUserItem
            // 
            picboxUserItem.BorderStyle = BorderStyle.FixedSingle;
            picboxUserItem.Image = Properties.Resources.user_solid;
            picboxUserItem.Location = new Point(15, 12);
            picboxUserItem.Name = "picboxUserItem";
            picboxUserItem.Size = new Size(58, 58);
            picboxUserItem.SizeMode = PictureBoxSizeMode.StretchImage;
            picboxUserItem.TabIndex = 3;
            picboxUserItem.TabStop = false;
            // 
            // UserItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            Controls.Add(picboxUserItem);
            Controls.Add(lblDescripcionItemUser);
            Controls.Add(lblname);
            Name = "UserItem";
            Size = new Size(352, 76);
            MouseClick += UserItem_MouseClick;
            MouseEnter += UserItem_MouseEnter;
            MouseLeave += UserItem_MouseLeave;
            ((System.ComponentModel.ISupportInitialize)picboxUserItem).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblname;
        private Label lblDescripcionItemUser;
        private personalizedComponents.Settings.RoundedPictureBox picboxUserItem;
    }
}