namespace DarkMessages.DesktopApp
{
    partial class SettingsList
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
            flpSettingsItems = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // flpSettingsItems
            // 
            flpSettingsItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            flpSettingsItems.BackColor = SystemColors.GradientInactiveCaption;
            flpSettingsItems.Location = new Point(0, 0);
            flpSettingsItems.Name = "flpSettingsItems";
            flpSettingsItems.Size = new Size(347, 450);
            flpSettingsItems.TabIndex = 0;
            flpSettingsItems.ClientSizeChanged += flpSettingsItems_ClientSizeChanged;
            flpSettingsItems.MouseWheel += FlpSettingsItem_MouseWheel;
            // 
            // SettingsList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(347, 450);
            Controls.Add(flpSettingsItems);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SettingsList";
            Text = "FriendsList";
            Load += SettingsList_Load;
            ResumeLayout(false);
        }




        #endregion

        private FlowLayoutPanel flpSettingsItems;
    }
}