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
            btnLeaveGroup = new CreateGroupButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(33, 33);
            label1.Name = "label1";
            label1.Size = new Size(123, 25);
            label1.TabIndex = 0;
            label1.Text = "Add Contact";
            // 
            // btnAddContact
            // 
            btnAddContact.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAddContact.BackColor = Color.DodgerBlue;
            btnAddContact.FlatAppearance.BorderSize = 0;
            btnAddContact.FlatStyle = FlatStyle.Flat;
            btnAddContact.ForeColor = Color.White;
            btnAddContact.Location = new Point(641, 500);
            btnAddContact.Name = "btnAddContact";
            btnAddContact.Size = new Size(95, 29);
            btnAddContact.TabIndex = 9;
            btnAddContact.Text = "Save";
            btnAddContact.UseVisualStyleBackColor = false;
            btnAddContact.Click += btnAddContact_Click;
            // 
            // txtSelectedContact
            // 
            txtSelectedContact.Anchor = AnchorStyles.None;
            txtSelectedContact.BackColor = SystemColors.InactiveCaption;
            txtSelectedContact.BorderStyle = BorderStyle.FixedSingle;
            txtSelectedContact.Font = new Font("Segoe UI", 14F);
            txtSelectedContact.Location = new Point(33, 64);
            txtSelectedContact.Name = "txtSelectedContact";
            txtSelectedContact.Size = new Size(314, 32);
            txtSelectedContact.TabIndex = 10;
            txtSelectedContact.Click += txtSelectedContact_Click;
            txtSelectedContact.TextChanged += txtSelectedContact_TextChanged;
            // 
            // btnViewContacts
            // 
            btnViewContacts.Anchor = AnchorStyles.None;
            btnViewContacts.BackColor = Color.DodgerBlue;
            btnViewContacts.FlatAppearance.BorderSize = 0;
            btnViewContacts.FlatStyle = FlatStyle.Flat;
            btnViewContacts.ForeColor = Color.White;
            btnViewContacts.Location = new Point(641, 29);
            btnViewContacts.Name = "btnViewContacts";
            btnViewContacts.Size = new Size(95, 29);
            btnViewContacts.TabIndex = 11;
            btnViewContacts.Text = "View contacts";
            btnViewContacts.UseVisualStyleBackColor = false;
            btnViewContacts.Click += btnViewContacts_Click;
            // 
            // txtDescription
            // 
            txtDescription.Anchor = AnchorStyles.None;
            txtDescription.BackColor = SystemColors.InactiveCaption;
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Font = new Font("Segoe UI", 14F);
            txtDescription.Location = new Point(33, 207);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(314, 276);
            txtDescription.TabIndex = 13;
            // 
            // lblDescription
            // 
            lblDescription.Anchor = AnchorStyles.None;
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblDescription.Location = new Point(33, 176);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(114, 25);
            lblDescription.TabIndex = 14;
            lblDescription.Text = "Description";
            // 
            // lblContacts
            // 
            lblContacts.Anchor = AnchorStyles.None;
            lblContacts.AutoSize = true;
            lblContacts.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblContacts.Location = new Point(374, 33);
            lblContacts.Name = "lblContacts";
            lblContacts.Size = new Size(95, 25);
            lblContacts.TabIndex = 16;
            lblContacts.Text = "Members";
            // 
            // txtTitle
            // 
            txtTitle.Anchor = AnchorStyles.None;
            txtTitle.BackColor = SystemColors.InactiveCaption;
            txtTitle.BorderStyle = BorderStyle.FixedSingle;
            txtTitle.Font = new Font("Segoe UI", 14F);
            txtTitle.Location = new Point(33, 137);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(314, 32);
            txtTitle.TabIndex = 17;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label3.Location = new Point(33, 106);
            label3.Name = "label3";
            label3.Size = new Size(50, 25);
            label3.TabIndex = 18;
            label3.Text = "Title";
            // 
            // flpContacts
            // 
            flpContacts.Anchor = AnchorStyles.None;
            flpContacts.BackColor = SystemColors.InactiveCaption;
            flpContacts.BorderStyle = BorderStyle.FixedSingle;
            flpContacts.Location = new Point(374, 64);
            flpContacts.Name = "flpContacts";
            flpContacts.Size = new Size(362, 419);
            flpContacts.TabIndex = 20;
            flpContacts.MouseWheel += FlpContacts_MouseWheel;
            // 
            // lblResponseMessage
            // 
            lblResponseMessage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblResponseMessage.AutoSize = true;
            lblResponseMessage.Font = new Font("Segoe UI", 10F);
            lblResponseMessage.Location = new Point(33, 499);
            lblResponseMessage.Name = "lblResponseMessage";
            lblResponseMessage.Size = new Size(121, 19);
            lblResponseMessage.TabIndex = 21;
            lblResponseMessage.Text = "response message";
            // 
            // btnBack
            // 
            btnBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnBack.BackColor = Color.DodgerBlue;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(540, 500);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(95, 29);
            btnBack.TabIndex = 22;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // btnLeaveGroup
            // 
            btnLeaveGroup.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLeaveGroup.BackColor = Color.DodgerBlue;
            btnLeaveGroup.FlatAppearance.BorderSize = 0;
            btnLeaveGroup.FlatStyle = FlatStyle.Flat;
            btnLeaveGroup.ForeColor = Color.White;
            btnLeaveGroup.Location = new Point(439, 500);
            btnLeaveGroup.Name = "btnLeaveGroup";
            btnLeaveGroup.Size = new Size(95, 29);
            btnLeaveGroup.TabIndex = 23;
            btnLeaveGroup.Text = "Leave Group";
            btnLeaveGroup.UseVisualStyleBackColor = false;
            btnLeaveGroup.Click += btnLeaveGroup_Click;
            // 
            // GroupSettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(770, 543);
            Controls.Add(btnLeaveGroup);
            Controls.Add(btnViewContacts);
            Controls.Add(btnBack);
            Controls.Add(lblResponseMessage);
            Controls.Add(flpContacts);
            Controls.Add(label3);
            Controls.Add(txtTitle);
            Controls.Add(lblContacts);
            Controls.Add(lblDescription);
            Controls.Add(txtDescription);
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
        private CreateGroupButton btnLeaveGroup;
    }
}