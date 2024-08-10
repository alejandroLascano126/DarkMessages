namespace DarkMessages.DesktopApp
{
    partial class GroupSettingsForm
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
            label1 = new Label();
            btnAddContact = new CreateGroupButton();
            txtSelectedContact = new TextBox();
            btnViewContacts = new CreateGroupButton();
            panelContacts = new Panel();
            txtDescription = new TextBox();
            lblDescription = new Label();
            btnSaveTitle = new CreateGroupButton();
            label2 = new Label();
            txtTitle = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(44, 35);
            label1.Name = "label1";
            label1.Size = new Size(123, 25);
            label1.TabIndex = 0;
            label1.Text = "Add Contact";
            // 
            // btnAddContact
            // 
            btnAddContact.BackColor = Color.DodgerBlue;
            btnAddContact.FlatAppearance.BorderSize = 0;
            btnAddContact.FlatStyle = FlatStyle.Flat;
            btnAddContact.ForeColor = Color.White;
            btnAddContact.Location = new Point(219, 31);
            btnAddContact.Name = "btnAddContact";
            btnAddContact.Size = new Size(95, 29);
            btnAddContact.TabIndex = 9;
            btnAddContact.Text = "Save";
            btnAddContact.UseVisualStyleBackColor = false;
            // 
            // txtSelectedContact
            // 
            txtSelectedContact.BorderStyle = BorderStyle.FixedSingle;
            txtSelectedContact.Font = new Font("Segoe UI", 14F);
            txtSelectedContact.Location = new Point(44, 66);
            txtSelectedContact.Name = "txtSelectedContact";
            txtSelectedContact.Size = new Size(270, 32);
            txtSelectedContact.TabIndex = 10;
            // 
            // btnViewContacts
            // 
            btnViewContacts.BackColor = Color.DodgerBlue;
            btnViewContacts.FlatAppearance.BorderSize = 0;
            btnViewContacts.FlatStyle = FlatStyle.Flat;
            btnViewContacts.ForeColor = Color.White;
            btnViewContacts.Location = new Point(600, 31);
            btnViewContacts.Name = "btnViewContacts";
            btnViewContacts.Size = new Size(95, 29);
            btnViewContacts.TabIndex = 11;
            btnViewContacts.Text = "View contacts";
            btnViewContacts.UseVisualStyleBackColor = false;
            // 
            // panelContacts
            // 
            panelContacts.BackColor = SystemColors.ButtonHighlight;
            panelContacts.BorderStyle = BorderStyle.FixedSingle;
            panelContacts.Location = new Point(417, 66);
            panelContacts.Name = "panelContacts";
            panelContacts.Size = new Size(278, 426);
            panelContacts.TabIndex = 12;
            // 
            // txtDescription
            // 
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Font = new Font("Segoe UI", 14F);
            txtDescription.Location = new Point(44, 202);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(270, 101);
            txtDescription.TabIndex = 13;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblDescription.Location = new Point(44, 174);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(114, 25);
            lblDescription.TabIndex = 14;
            lblDescription.Text = "Description";
            // 
            // btnSaveTitle
            // 
            btnSaveTitle.BackColor = Color.DodgerBlue;
            btnSaveTitle.FlatAppearance.BorderSize = 0;
            btnSaveTitle.FlatStyle = FlatStyle.Flat;
            btnSaveTitle.ForeColor = Color.White;
            btnSaveTitle.Location = new Point(219, 104);
            btnSaveTitle.Name = "btnSaveTitle";
            btnSaveTitle.Size = new Size(95, 29);
            btnSaveTitle.TabIndex = 15;
            btnSaveTitle.Text = "Save";
            btnSaveTitle.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label2.Location = new Point(417, 35);
            label2.Name = "label2";
            label2.Size = new Size(95, 25);
            label2.TabIndex = 16;
            label2.Text = "Members";
            // 
            // txtTitle
            // 
            txtTitle.BorderStyle = BorderStyle.FixedSingle;
            txtTitle.Font = new Font("Segoe UI", 14F);
            txtTitle.Location = new Point(44, 139);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(270, 32);
            txtTitle.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label3.Location = new Point(44, 101);
            label3.Name = "label3";
            label3.Size = new Size(50, 25);
            label3.TabIndex = 18;
            label3.Text = "Title";
            // 
            // GroupSettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(770, 543);
            Controls.Add(label3);
            Controls.Add(txtTitle);
            Controls.Add(label2);
            Controls.Add(btnSaveTitle);
            Controls.Add(lblDescription);
            Controls.Add(txtDescription);
            Controls.Add(panelContacts);
            Controls.Add(btnViewContacts);
            Controls.Add(txtSelectedContact);
            Controls.Add(btnAddContact);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "GroupSettingsForm";
            Text = "GroupSettingsForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private CreateGroupButton btnAddContact;
        private TextBox txtSelectedContact;
        private CreateGroupButton btnViewContacts;
        private Panel panelContacts;
        private TextBox txtDescription;
        private Label lblDescription;
        private CreateGroupButton btnSaveTitle;
        private Label label2;
        private TextBox txtTitle;
        private Label label3;
    }
}