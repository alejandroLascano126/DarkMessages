namespace DarkMessages.DesktopApp
{
    partial class GroupMemberOptionsForm
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
            btnRemove = new CreateGroupButton();
            lblUsername = new Label();
            btnSave = new CreateGroupButton();
            btnCancel = new CreateGroupButton();
            panelGroupMemberOptions = new Panel();
            lblGroupMember = new Label();
            panelGroupMemberOptions.SuspendLayout();
            SuspendLayout();
            // 
            // btnRemove
            // 
            btnRemove.BackColor = Color.Crimson;
            btnRemove.FlatAppearance.BorderSize = 0;
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.ForeColor = Color.White;
            btnRemove.Location = new Point(132, 427);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(79, 29);
            btnRemove.TabIndex = 13;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = false;
            btnRemove.Click += btnRemove_Click;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblUsername.Location = new Point(22, 28);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(255, 30);
            lblUsername.TabIndex = 14;
            lblUsername.Text = "Group member options";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.DodgerBlue;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(302, 427);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(79, 29);
            btnSave.TabIndex = 15;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.DodgerBlue;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(217, 427);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(79, 29);
            btnCancel.TabIndex = 16;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // panelGroupMemberOptions
            // 
            panelGroupMemberOptions.BackColor = SystemColors.GradientInactiveCaption;
            panelGroupMemberOptions.Controls.Add(lblGroupMember);
            panelGroupMemberOptions.Controls.Add(lblUsername);
            panelGroupMemberOptions.Controls.Add(btnCancel);
            panelGroupMemberOptions.Controls.Add(btnRemove);
            panelGroupMemberOptions.Controls.Add(btnSave);
            panelGroupMemberOptions.Location = new Point(0, 0);
            panelGroupMemberOptions.Name = "panelGroupMemberOptions";
            panelGroupMemberOptions.Size = new Size(409, 488);
            panelGroupMemberOptions.TabIndex = 17;
            // 
            // lblGroupMember
            // 
            lblGroupMember.AutoSize = true;
            lblGroupMember.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGroupMember.Location = new Point(22, 67);
            lblGroupMember.Name = "lblGroupMember";
            lblGroupMember.Size = new Size(154, 28);
            lblGroupMember.TabIndex = 17;
            lblGroupMember.Text = "Name lastname";
            // 
            // GroupMemberOptionsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(410, 490);
            Controls.Add(panelGroupMemberOptions);
            FormBorderStyle = FormBorderStyle.None;
            Name = "GroupMemberOptionsForm";
            Text = "GroupMemberOptionsForm";
            Load += GroupMemberOptionsForm_Load;
            panelGroupMemberOptions.ResumeLayout(false);
            panelGroupMemberOptions.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private CreateGroupButton btnRemove;
        private Label lblUsername;
        private CreateGroupButton btnSave;
        private CreateGroupButton btnCancel;
        private Panel panelGroupMemberOptions;
        private Label lblGroupMember;
    }
}