namespace DarkMessages.DesktopApp
{
    partial class SecurityCodeSettingsForm
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
            components = new System.ComponentModel.Container();
            lblSecurityCode = new Label();
            txtSecurityCode = new TextBox();
            timerCodigoValida = new System.Windows.Forms.Timer(components);
            lblTimerCodigoValida = new Label();
            btnReSendSecurityCode = new CreateGroupButton();
            btnSecurityCode = new CreateGroupButton();
            btnBackSecCode = new CreateGroupButton();
            SuspendLayout();
            // 
            // lblSecurityCode
            // 
            lblSecurityCode.Anchor = AnchorStyles.None;
            lblSecurityCode.AutoSize = true;
            lblSecurityCode.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSecurityCode.Location = new Point(274, 224);
            lblSecurityCode.Name = "lblSecurityCode";
            lblSecurityCode.Size = new Size(190, 21);
            lblSecurityCode.TabIndex = 0;
            lblSecurityCode.Text = "INSERT SECURITY CODE";
            // 
            // txtSecurityCode
            // 
            txtSecurityCode.Anchor = AnchorStyles.None;
            txtSecurityCode.BorderStyle = BorderStyle.FixedSingle;
            txtSecurityCode.Font = new Font("Segoe UI", 12F);
            txtSecurityCode.Location = new Point(274, 257);
            txtSecurityCode.Name = "txtSecurityCode";
            txtSecurityCode.Size = new Size(190, 29);
            txtSecurityCode.TabIndex = 1;
            txtSecurityCode.Click += txtSecurityCode_Click;
            // 
            // timerCodigoValida
            // 
            timerCodigoValida.Interval = 1000;
            // 
            // lblTimerCodigoValida
            // 
            lblTimerCodigoValida.Anchor = AnchorStyles.None;
            lblTimerCodigoValida.AutoSize = true;
            lblTimerCodigoValida.Font = new Font("Segoe UI", 14F);
            lblTimerCodigoValida.Location = new Point(344, 292);
            lblTimerCodigoValida.Name = "lblTimerCodigoValida";
            lblTimerCodigoValida.Size = new Size(56, 25);
            lblTimerCodigoValida.TabIndex = 3;
            lblTimerCodigoValida.Text = "01:00";
            // 
            // btnReSendSecurityCode
            // 
            btnReSendSecurityCode.Anchor = AnchorStyles.None;
            btnReSendSecurityCode.AutoSize = true;
            btnReSendSecurityCode.BackColor = Color.DodgerBlue;
            btnReSendSecurityCode.FlatAppearance.BorderSize = 0;
            btnReSendSecurityCode.FlatStyle = FlatStyle.Flat;
            btnReSendSecurityCode.Font = new Font("Segoe UI", 12F);
            btnReSendSecurityCode.ForeColor = Color.White;
            btnReSendSecurityCode.Location = new Point(253, 316);
            btnReSendSecurityCode.Name = "btnReSendSecurityCode";
            btnReSendSecurityCode.Size = new Size(116, 33);
            btnReSendSecurityCode.TabIndex = 8;
            btnReSendSecurityCode.Text = "RESEND";
            btnReSendSecurityCode.UseVisualStyleBackColor = false;
            btnReSendSecurityCode.Click += btnReSendSecurityCode_ClickAsync;
            // 
            // btnSecurityCode
            // 
            btnSecurityCode.Anchor = AnchorStyles.None;
            btnSecurityCode.AutoSize = true;
            btnSecurityCode.BackColor = Color.DodgerBlue;
            btnSecurityCode.FlatAppearance.BorderSize = 0;
            btnSecurityCode.FlatStyle = FlatStyle.Flat;
            btnSecurityCode.Font = new Font("Segoe UI", 12F);
            btnSecurityCode.ForeColor = Color.White;
            btnSecurityCode.Location = new Point(375, 316);
            btnSecurityCode.Name = "btnSecurityCode";
            btnSecurityCode.Size = new Size(116, 33);
            btnSecurityCode.TabIndex = 9;
            btnSecurityCode.Text = "ACCEPT";
            btnSecurityCode.UseVisualStyleBackColor = false;
            btnSecurityCode.Click += btnSecurityCode_ClickAsync;
            // 
            // btnBackSecCode
            // 
            btnBackSecCode.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnBackSecCode.BackColor = Color.DodgerBlue;
            btnBackSecCode.FlatAppearance.BorderSize = 0;
            btnBackSecCode.FlatStyle = FlatStyle.Flat;
            btnBackSecCode.Font = new Font("Segoe UI", 12F);
            btnBackSecCode.ForeColor = Color.White;
            btnBackSecCode.Location = new Point(47, 479);
            btnBackSecCode.Name = "btnBackSecCode";
            btnBackSecCode.Size = new Size(116, 33);
            btnBackSecCode.TabIndex = 10;
            btnBackSecCode.Text = "BACK";
            btnBackSecCode.UseVisualStyleBackColor = false;
            btnBackSecCode.Click += btnBackSecCode_Click;
            // 
            // SecurityCodeSettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(771, 544);
            Controls.Add(btnBackSecCode);
            Controls.Add(btnSecurityCode);
            Controls.Add(btnReSendSecurityCode);
            Controls.Add(lblTimerCodigoValida);
            Controls.Add(txtSecurityCode);
            Controls.Add(lblSecurityCode);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SecurityCodeSettingsForm";
            Text = "SecurityCodeForm";
            Load += SecurityCodeSettingsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSecurityCode;
        private TextBox txtSecurityCode;
        private System.Windows.Forms.Timer timerCodigoValida;
        private Label lblTimerCodigoValida;
        private CreateGroupButton btnReSendSecurityCode;
        private CreateGroupButton btnSecurityCode;
        private CreateGroupButton btnBackSecCode;
    }
}