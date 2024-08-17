namespace DarkMessages.DesktopApp
{
    partial class GroupsForm
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
            lblGroups = new Label();
            SuspendLayout();
            // 
            // lblGroups
            // 
            lblGroups.AutoSize = true;
            lblGroups.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblGroups.Location = new Point(45, 33);
            lblGroups.Name = "lblGroups";
            lblGroups.Size = new Size(78, 25);
            lblGroups.TabIndex = 1;
            lblGroups.Text = "Groups";
            // 
            // GroupsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(771, 544);
            Controls.Add(lblGroups);
            FormBorderStyle = FormBorderStyle.None;
            Name = "GroupsForm";
            Text = "SetingsForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CreateGroupButton btnQuitSession;
        private Label lblGroups;
    }
}