namespace DarkMessages.DesktopApp
{
    partial class ChatFormPrivate
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
            lblNameChat = new Label();
            panelUpChat = new Panel();
            lblOnlineStatus = new Label();
            rtbSendMessage = new RichTextBox();
            btnSendMessage = new Button();
            tlpMessagesChat = new TableLayoutPanel();
            panelUpChat.SuspendLayout();
            SuspendLayout();
            // 
            // lblNameChat
            // 
            lblNameChat.AutoSize = true;
            lblNameChat.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblNameChat.Location = new Point(25, 4);
            lblNameChat.Name = "lblNameChat";
            lblNameChat.Size = new Size(68, 28);
            lblNameChat.TabIndex = 0;
            lblNameChat.Text = "Name";
            // 
            // panelUpChat
            // 
            panelUpChat.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelUpChat.BackColor = SystemColors.GradientActiveCaption;
            panelUpChat.Controls.Add(lblOnlineStatus);
            panelUpChat.Controls.Add(lblNameChat);
            panelUpChat.Location = new Point(0, 0);
            panelUpChat.Name = "panelUpChat";
            panelUpChat.Size = new Size(801, 47);
            panelUpChat.TabIndex = 1;
            // 
            // lblOnlineStatus
            // 
            lblOnlineStatus.AutoSize = true;
            lblOnlineStatus.ForeColor = Color.White;
            lblOnlineStatus.Location = new Point(26, 30);
            lblOnlineStatus.Name = "lblOnlineStatus";
            lblOnlineStatus.Size = new Size(42, 15);
            lblOnlineStatus.TabIndex = 1;
            lblOnlineStatus.Text = "Online";
            // 
            // rtbSendMessage
            // 
            rtbSendMessage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtbSendMessage.Font = new Font("Segoe UI", 12F);
            rtbSendMessage.Location = new Point(12, 488);
            rtbSendMessage.Name = "rtbSendMessage";
            rtbSendMessage.Size = new Size(605, 43);
            rtbSendMessage.TabIndex = 2;
            rtbSendMessage.Text = "";
            rtbSendMessage.KeyDown += rtbSendMessage_KeyDown;
            // 
            // btnSendMessage
            // 
            btnSendMessage.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSendMessage.Font = new Font("Segoe UI", 15F);
            btnSendMessage.Location = new Point(623, 488);
            btnSendMessage.Name = "btnSendMessage";
            btnSendMessage.Size = new Size(135, 43);
            btnSendMessage.TabIndex = 3;
            btnSendMessage.Text = "Send";
            btnSendMessage.UseVisualStyleBackColor = true;
            btnSendMessage.Click += btnSendMessage_Click;
            // 
            // tlpMessagesChat
            // 
            tlpMessagesChat.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tlpMessagesChat.AutoScroll = true;
            tlpMessagesChat.AutoSize = true;
            tlpMessagesChat.BackColor = SystemColors.GradientInactiveCaption;
            tlpMessagesChat.ColumnCount = 3;
            tlpMessagesChat.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlpMessagesChat.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpMessagesChat.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlpMessagesChat.Location = new Point(12, 53);
            tlpMessagesChat.Name = "tlpMessagesChat";
            tlpMessagesChat.RowCount = 22;
            tlpMessagesChat.RowStyles.Add(new RowStyle());
            tlpMessagesChat.RowStyles.Add(new RowStyle());
            tlpMessagesChat.RowStyles.Add(new RowStyle());
            tlpMessagesChat.RowStyles.Add(new RowStyle());
            tlpMessagesChat.RowStyles.Add(new RowStyle());
            tlpMessagesChat.RowStyles.Add(new RowStyle());
            tlpMessagesChat.RowStyles.Add(new RowStyle());
            tlpMessagesChat.RowStyles.Add(new RowStyle());
            tlpMessagesChat.RowStyles.Add(new RowStyle());
            tlpMessagesChat.RowStyles.Add(new RowStyle());
            tlpMessagesChat.RowStyles.Add(new RowStyle());
            tlpMessagesChat.RowStyles.Add(new RowStyle());
            tlpMessagesChat.RowStyles.Add(new RowStyle());
            tlpMessagesChat.RowStyles.Add(new RowStyle());
            tlpMessagesChat.RowStyles.Add(new RowStyle());
            tlpMessagesChat.RowStyles.Add(new RowStyle());
            tlpMessagesChat.RowStyles.Add(new RowStyle());
            tlpMessagesChat.RowStyles.Add(new RowStyle());
            tlpMessagesChat.RowStyles.Add(new RowStyle());
            tlpMessagesChat.RowStyles.Add(new RowStyle());
            tlpMessagesChat.RowStyles.Add(new RowStyle());
            tlpMessagesChat.RowStyles.Add(new RowStyle());
            tlpMessagesChat.Size = new Size(746, 429);
            tlpMessagesChat.TabIndex = 4;
            tlpMessagesChat.ClientSizeChanged += tlpMessagesChat_ClientSizeChanged;
            tlpMessagesChat.MouseWheel += TlpMessagesChat_MouseWheel;
            // 
            // ChatFormPrivate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(770, 543);
            Controls.Add(tlpMessagesChat);
            Controls.Add(btnSendMessage);
            Controls.Add(rtbSendMessage);
            Controls.Add(panelUpChat);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ChatFormPrivate";
            Text = "ChatForm";
            Load += ChatForm_Load;
            panelUpChat.ResumeLayout(false);
            panelUpChat.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private Label lblNameChat;
        private Panel panelUpChat;
        private RichTextBox rtbSendMessage;
        private Button btnSendMessage;
        private TableLayoutPanel tlpMessagesChat;
        private Label lblOnlineStatus;
    }
}