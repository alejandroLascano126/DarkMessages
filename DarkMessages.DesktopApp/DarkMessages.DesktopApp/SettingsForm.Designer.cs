namespace DarkMessages.DesktopApp
{
    partial class SettingsForm
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
            btnQuitSession = new CreateGroupButton();
            label1 = new Label();
            btnBack = new CreateGroupButton();
            SuspendLayout();
            // 
            // btnQuitSession
            // 
            btnQuitSession.BackColor = Color.DodgerBlue;
            btnQuitSession.FlatAppearance.BorderSize = 0;
            btnQuitSession.FlatStyle = FlatStyle.Flat;
            btnQuitSession.ForeColor = Color.White;
            btnQuitSession.Location = new Point(82, 105);
            btnQuitSession.Name = "btnQuitSession";
            btnQuitSession.Size = new Size(133, 35);
            btnQuitSession.TabIndex = 0;
            btnQuitSession.Text = "Log out";
            btnQuitSession.UseVisualStyleBackColor = false;
            btnQuitSession.Click += btnQuitSession_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(82, 61);
            label1.Name = "label1";
            label1.Size = new Size(84, 25);
            label1.TabIndex = 1;
            label1.Text = "Settings";
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Silver;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(970, 534);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(133, 35);
            btnBack.TabIndex = 2;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(1175, 622);
            Controls.Add(btnBack);
            Controls.Add(label1);
            Controls.Add(btnQuitSession);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SettingsForm";
            Text = "SetingsForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CreateGroupButton btnQuitSession;
        private Label label1;
        private CreateGroupButton btnBack;
    }
}