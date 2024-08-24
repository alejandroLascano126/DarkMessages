namespace DarkMessages.DesktopApp
{
    partial class CreateGroupForm
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
            txtName = new TextBox();
            txtDescription = new TextBox();
            lblname = new Label();
            lblDescription = new Label();
            cbAccess = new ComboBox();
            btnCreateGroup = new CreateGroupButton();
            btnAccess = new Label();
            lblMensaje = new Label();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.BackColor = SystemColors.InactiveCaption;
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Font = new Font("Segoe UI", 14F);
            txtName.Location = new Point(22, 58);
            txtName.Name = "txtName";
            txtName.Size = new Size(310, 32);
            txtName.TabIndex = 5;
            // 
            // txtDescription
            // 
            txtDescription.BackColor = SystemColors.InactiveCaption;
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Font = new Font("Segoe UI", 14F);
            txtDescription.Location = new Point(22, 185);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(310, 161);
            txtDescription.TabIndex = 6;
            // 
            // lblname
            // 
            lblname.AutoSize = true;
            lblname.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblname.Location = new Point(22, 30);
            lblname.Name = "lblname";
            lblname.Size = new Size(64, 25);
            lblname.TabIndex = 7;
            lblname.Text = "Name";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblDescription.Location = new Point(22, 157);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(114, 25);
            lblDescription.TabIndex = 8;
            lblDescription.Text = "Description";
            // 
            // cbAccess
            // 
            cbAccess.BackColor = SystemColors.InactiveCaption;
            cbAccess.Enabled = false;
            cbAccess.Font = new Font("Segoe UI", 14F);
            cbAccess.FormattingEnabled = true;
            cbAccess.Location = new Point(22, 121);
            cbAccess.Name = "cbAccess";
            cbAccess.Size = new Size(310, 33);
            cbAccess.TabIndex = 10;
            // 
            // btnCreateGroup
            // 
            btnCreateGroup.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCreateGroup.BackColor = Color.DodgerBlue;
            btnCreateGroup.FlatAppearance.BorderSize = 0;
            btnCreateGroup.FlatStyle = FlatStyle.Flat;
            btnCreateGroup.ForeColor = Color.White;
            btnCreateGroup.Location = new Point(212, 393);
            btnCreateGroup.Name = "btnCreateGroup";
            btnCreateGroup.Size = new Size(120, 35);
            btnCreateGroup.TabIndex = 11;
            btnCreateGroup.Text = "Create group";
            btnCreateGroup.UseVisualStyleBackColor = false;
            btnCreateGroup.Click += btnCreateGroup_Click;
            // 
            // btnAccess
            // 
            btnAccess.AutoSize = true;
            btnAccess.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnAccess.Location = new Point(22, 93);
            btnAccess.Name = "btnAccess";
            btnAccess.Size = new Size(69, 25);
            btnAccess.TabIndex = 13;
            btnAccess.Text = "Access";
            // 
            // lblMensaje
            // 
            lblMensaje.AutoSize = true;
            lblMensaje.Font = new Font("Segoe UI", 10F);
            lblMensaje.Location = new Point(22, 349);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(59, 19);
            lblMensaje.TabIndex = 14;
            lblMensaje.Text = "mensaje";
            // 
            // CreateGroupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(354, 450);
            Controls.Add(lblMensaje);
            Controls.Add(btnAccess);
            Controls.Add(btnCreateGroup);
            Controls.Add(cbAccess);
            Controls.Add(lblDescription);
            Controls.Add(lblname);
            Controls.Add(txtDescription);
            Controls.Add(txtName);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CreateGroupForm";
            Text = "CreateGroupFrom";
            Load += CreateGroupForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private TextBox txtDescription;
        private Label lblname;
        private Label lblDescription;
        private ComboBox cbAccess;
        private CreateGroupButton btnCreateGroup;
        private Label btnAccess;
        private Label lblMensaje;
    }
}