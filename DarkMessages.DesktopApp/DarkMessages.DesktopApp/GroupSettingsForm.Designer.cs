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
            txtDescription = new TextBox();
            lblDescription = new Label();
            lblContacts = new Label();
            txtTitle = new TextBox();
            label3 = new Label();
            flpContacts = new FlowLayoutPanel();
            lblResponseMessage = new Label();
            btnBack = new CreateGroupButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(17, 35);
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
            btnAddContact.Location = new Point(625, 502);
            btnAddContact.Name = "btnAddContact";
            btnAddContact.Size = new Size(95, 29);
            btnAddContact.TabIndex = 9;
            btnAddContact.Text = "Save";
            btnAddContact.UseVisualStyleBackColor = false;
            btnAddContact.Click += btnAddContact_Click;
            // 
            // txtSelectedContact
            // 
            txtSelectedContact.BackColor = SystemColors.InactiveCaption;
            txtSelectedContact.BorderStyle = BorderStyle.FixedSingle;
            txtSelectedContact.Font = new Font("Segoe UI", 14F);
            txtSelectedContact.Location = new Point(17, 66);
            txtSelectedContact.Name = "txtSelectedContact";
            txtSelectedContact.Size = new Size(314, 32);
            txtSelectedContact.TabIndex = 10;
            txtSelectedContact.Click += txtSelectedContact_Click;
            txtSelectedContact.TextChanged += txtSelectedContact_TextChanged;
            // 
            // btnViewContacts
            // 
            btnViewContacts.BackColor = Color.DodgerBlue;
            btnViewContacts.FlatAppearance.BorderSize = 0;
            btnViewContacts.FlatStyle = FlatStyle.Flat;
            btnViewContacts.ForeColor = Color.White;
            btnViewContacts.Location = new Point(625, 31);
            btnViewContacts.Name = "btnViewContacts";
            btnViewContacts.Size = new Size(95, 29);
            btnViewContacts.TabIndex = 11;
            btnViewContacts.Text = "View contacts";
            btnViewContacts.UseVisualStyleBackColor = false;
            btnViewContacts.Click += btnViewContacts_Click;
            // 
            // txtDescription
            // 
            txtDescription.BackColor = SystemColors.InactiveCaption;
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Font = new Font("Segoe UI", 14F);
            txtDescription.Location = new Point(17, 209);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(314, 276);
            txtDescription.TabIndex = 13;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblDescription.Location = new Point(17, 178);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(114, 25);
            lblDescription.TabIndex = 14;
            lblDescription.Text = "Description";
            // 
            // lblContacts
            // 
            lblContacts.AutoSize = true;
            lblContacts.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblContacts.Location = new Point(358, 35);
            lblContacts.Name = "lblContacts";
            lblContacts.Size = new Size(95, 25);
            lblContacts.TabIndex = 16;
            lblContacts.Text = "Members";
            // 
            // txtTitle
            // 
            txtTitle.BackColor = SystemColors.InactiveCaption;
            txtTitle.BorderStyle = BorderStyle.FixedSingle;
            txtTitle.Font = new Font("Segoe UI", 14F);
            txtTitle.Location = new Point(17, 139);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(314, 32);
            txtTitle.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label3.Location = new Point(17, 108);
            label3.Name = "label3";
            label3.Size = new Size(50, 25);
            label3.TabIndex = 18;
            label3.Text = "Title";
            // 
            // flpContacts
            // 
            flpContacts.BackColor = SystemColors.InactiveCaption;
            flpContacts.BorderStyle = BorderStyle.FixedSingle;
            flpContacts.Location = new Point(358, 66);
            flpContacts.Name = "flpContacts";
            flpContacts.Size = new Size(362, 419);
            flpContacts.TabIndex = 20;
            // 
            // lblResponseMessage
            // 
            lblResponseMessage.AutoSize = true;
            lblResponseMessage.Font = new Font("Segoe UI", 10F);
            lblResponseMessage.Location = new Point(17, 501);
            lblResponseMessage.Name = "lblResponseMessage";
            lblResponseMessage.Size = new Size(121, 19);
            lblResponseMessage.TabIndex = 21;
            lblResponseMessage.Text = "response message";
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.DodgerBlue;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(524, 502);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(95, 29);
            btnBack.TabIndex = 22;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // GroupSettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(770, 543);
            Controls.Add(btnBack);
            Controls.Add(lblResponseMessage);
            Controls.Add(flpContacts);
            Controls.Add(label3);
            Controls.Add(txtTitle);
            Controls.Add(lblContacts);
            Controls.Add(lblDescription);
            Controls.Add(txtDescription);
            Controls.Add(btnViewContacts);
            Controls.Add(txtSelectedContact);
            Controls.Add(btnAddContact);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "GroupSettingsForm";
            Text = "GroupSettingsForm";
            Load += GroupSettingsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private CreateGroupButton btnAddContact;
        private TextBox txtSelectedContact;
        private CreateGroupButton btnViewContacts;
        private TextBox txtDescription;
        private Label lblDescription;
        private Label lblContacts;
        private TextBox txtTitle;
        private Label label3;
        private FlowLayoutPanel flpContacts;
        private Label lblResponseMessage;
        private CreateGroupButton btnBack;
    }
}