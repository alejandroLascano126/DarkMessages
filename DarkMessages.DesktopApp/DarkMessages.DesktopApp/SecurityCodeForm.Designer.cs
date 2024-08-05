namespace DarkMessages.DesktopApp
{
    partial class SecurityCodeForm
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
            btnSecurityCode = new Button();
            timerCodigoValida = new System.Windows.Forms.Timer(components);
            lblTimerCodigoValida = new Label();
            btnReSendSecurityCode = new Button();
            btnBackSecCode = new Button();
            SuspendLayout();
            // 
            // lblSecurityCode
            // 
            lblSecurityCode.AutoSize = true;
            lblSecurityCode.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSecurityCode.Location = new Point(483, 264);
            lblSecurityCode.Name = "lblSecurityCode";
            lblSecurityCode.Size = new Size(190, 21);
            lblSecurityCode.TabIndex = 0;
            lblSecurityCode.Text = "INSERT SECURITY CODE";
            // 
            // txtSecurityCode
            // 
            txtSecurityCode.Font = new Font("Segoe UI", 12F);
            txtSecurityCode.Location = new Point(483, 300);
            txtSecurityCode.Name = "txtSecurityCode";
            txtSecurityCode.Size = new Size(190, 29);
            txtSecurityCode.TabIndex = 1;
            txtSecurityCode.Click += txtSecurityCode_Click;
            // 
            // btnSecurityCode
            // 
            btnSecurityCode.Font = new Font("Segoe UI", 12F);
            btnSecurityCode.Location = new Point(586, 360);
            btnSecurityCode.Name = "btnSecurityCode";
            btnSecurityCode.Size = new Size(116, 33);
            btnSecurityCode.TabIndex = 2;
            btnSecurityCode.Text = "ACCEPT";
            btnSecurityCode.UseVisualStyleBackColor = true;
            btnSecurityCode.Click += btnSecurityCode_ClickAsync;
            // 
            // timerCodigoValida
            // 
            timerCodigoValida.Interval = 1000;
            // 
            // lblTimerCodigoValida
            // 
            lblTimerCodigoValida.AutoSize = true;
            lblTimerCodigoValida.Font = new Font("Segoe UI", 14F);
            lblTimerCodigoValida.Location = new Point(554, 332);
            lblTimerCodigoValida.Name = "lblTimerCodigoValida";
            lblTimerCodigoValida.Size = new Size(56, 25);
            lblTimerCodigoValida.TabIndex = 3;
            lblTimerCodigoValida.Text = "01:00";
            // 
            // btnReSendSecurityCode
            // 
            btnReSendSecurityCode.Font = new Font("Segoe UI", 12F);
            btnReSendSecurityCode.Location = new Point(464, 360);
            btnReSendSecurityCode.Name = "btnReSendSecurityCode";
            btnReSendSecurityCode.Size = new Size(116, 33);
            btnReSendSecurityCode.TabIndex = 5;
            btnReSendSecurityCode.Text = "RESEND";
            btnReSendSecurityCode.UseVisualStyleBackColor = true;
            btnReSendSecurityCode.Click += btnReSendSecurityCode_ClickAsync;
            // 
            // btnBackSecCode
            // 
            btnBackSecCode.Font = new Font("Segoe UI", 12F);
            btnBackSecCode.Location = new Point(40, 584);
            btnBackSecCode.Name = "btnBackSecCode";
            btnBackSecCode.Size = new Size(116, 33);
            btnBackSecCode.TabIndex = 6;
            btnBackSecCode.Text = "BACK";
            btnBackSecCode.UseVisualStyleBackColor = true;
            btnBackSecCode.Click += btnBackSecCode_Click;
            // 
            // SecurityCodeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1150, 649);
            Controls.Add(btnBackSecCode);
            Controls.Add(btnReSendSecurityCode);
            Controls.Add(lblTimerCodigoValida);
            Controls.Add(btnSecurityCode);
            Controls.Add(txtSecurityCode);
            Controls.Add(lblSecurityCode);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SecurityCodeForm";
            Text = "SecurityCodeForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSecurityCode;
        private TextBox txtSecurityCode;
        private Button btnSecurityCode;
        private System.Windows.Forms.Timer timerCodigoValida;
        private Label lblTimerCodigoValida;
        private Button btnReSendSecurityCode;
        private Button btnBackSecCode;
    }
}