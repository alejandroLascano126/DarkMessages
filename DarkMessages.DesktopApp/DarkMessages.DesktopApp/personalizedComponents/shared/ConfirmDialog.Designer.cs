namespace DarkMessages.DesktopApp.personalizedComponents.shared
{
    partial class ConfirmDialog
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
            btnAfirmation = new CreateGroupButton();
            btnNegation = new CreateGroupButton();
            txtPredicateMessage = new TextBox();
            SuspendLayout();
            // 
            // btnAfirmation
            // 
            btnAfirmation.Anchor = AnchorStyles.None;
            btnAfirmation.BackColor = Color.Silver;
            btnAfirmation.FlatAppearance.BorderSize = 0;
            btnAfirmation.FlatStyle = FlatStyle.Flat;
            btnAfirmation.ForeColor = Color.White;
            btnAfirmation.Location = new Point(47, 81);
            btnAfirmation.Name = "btnAfirmation";
            btnAfirmation.Size = new Size(95, 29);
            btnAfirmation.TabIndex = 28;
            btnAfirmation.Text = "Yes";
            btnAfirmation.UseVisualStyleBackColor = false;
            btnAfirmation.Click += btnAfirmation_Click;
            // 
            // btnNegation
            // 
            btnNegation.Anchor = AnchorStyles.None;
            btnNegation.BackColor = Color.Silver;
            btnNegation.FlatAppearance.BorderSize = 0;
            btnNegation.FlatStyle = FlatStyle.Flat;
            btnNegation.ForeColor = Color.White;
            btnNegation.Location = new Point(163, 81);
            btnNegation.Name = "btnNegation";
            btnNegation.Size = new Size(95, 29);
            btnNegation.TabIndex = 29;
            btnNegation.Text = "No";
            btnNegation.UseVisualStyleBackColor = false;
            btnNegation.Click += btnNegation_Click;
            // 
            // txtPredicateMessage
            // 
            txtPredicateMessage.BorderStyle = BorderStyle.None;
            txtPredicateMessage.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txtPredicateMessage.Location = new Point(21, 12);
            txtPredicateMessage.Multiline = true;
            txtPredicateMessage.Name = "txtPredicateMessage";
            txtPredicateMessage.Size = new Size(271, 62);
            txtPredicateMessage.TabIndex = 34;
            txtPredicateMessage.Text = "Seguro que deseas salir del grupo?";
            // 
            // ConfirmDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(306, 133);
            Controls.Add(txtPredicateMessage);
            Controls.Add(btnNegation);
            Controls.Add(btnAfirmation);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "ConfirmDialog";
            Text = "ConfirmDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CreateGroupButton btnAfirmation;
        private CreateGroupButton btnNegation;
        private TextBox txtPredicateMessage;
    }
}