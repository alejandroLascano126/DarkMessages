namespace DarkMessages.DesktopApp.personalizedComponents.shared
{
    partial class MessageDialog
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
            btnClose = new CreateGroupButton();
            txtPredicateMessage = new TextBox();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.None;
            btnClose.BackColor = Color.Silver;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(199, 80);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(95, 29);
            btnClose.TabIndex = 32;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // txtPredicateMessage
            // 
            txtPredicateMessage.BorderStyle = BorderStyle.None;
            txtPredicateMessage.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txtPredicateMessage.Location = new Point(21, 12);
            txtPredicateMessage.Multiline = true;
            txtPredicateMessage.Name = "txtPredicateMessage";
            txtPredicateMessage.Size = new Size(271, 62);
            txtPredicateMessage.TabIndex = 33;
            txtPredicateMessage.Text = "Seguro que deseas salir del grupo?";
            // 
            // MessageDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(306, 133);
            Controls.Add(txtPredicateMessage);
            Controls.Add(btnClose);
            Name = "MessageDialog";
            Text = "MessageDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private CreateGroupButton btnClose;
        private TextBox txtPredicateMessage;
    }
}