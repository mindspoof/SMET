namespace SMET
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.cmbEncryption = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.btnBuilder = new System.Windows.Forms.Button();
            this.lblIp = new System.Windows.Forms.Label();
            this.cmbPayload = new System.Windows.Forms.ComboBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbType);
            this.groupBox1.Controls.Add(this.lblType);
            this.groupBox1.Controls.Add(this.cmbEncryption);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtStatus);
            this.groupBox1.Controls.Add(this.btnBuilder);
            this.groupBox1.Controls.Add(this.lblIp);
            this.groupBox1.Controls.Add(this.cmbPayload);
            this.groupBox1.Controls.Add(this.txtIP);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Location = new System.Drawing.Point(11, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(632, 306);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Meterpreter Builder";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Windows Form Application",
            "Console Application"});
            this.cmbType.Location = new System.Drawing.Point(431, 32);
            this.cmbType.Margin = new System.Windows.Forms.Padding(2);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(192, 21);
            this.cmbType.TabIndex = 14;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(393, 35);
            this.lblType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 13);
            this.lblType.TabIndex = 15;
            this.lblType.Text = "Type:";
            // 
            // cmbEncryption
            // 
            this.cmbEncryption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEncryption.FormattingEnabled = true;
            this.cmbEncryption.Items.AddRange(new object[] {
            "Base64",
            "Rijndael / AES",
            "DES"});
            this.cmbEncryption.Location = new System.Drawing.Point(392, 69);
            this.cmbEncryption.Margin = new System.Windows.Forms.Padding(2);
            this.cmbEncryption.Name = "cmbEncryption";
            this.cmbEncryption.Size = new System.Drawing.Size(231, 21);
            this.cmbEncryption.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(329, 71);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Encryption:";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 102);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(2);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtStatus.Size = new System.Drawing.Size(624, 153);
            this.txtStatus.TabIndex = 7;
            // 
            // btnBuilder
            // 
            this.btnBuilder.Location = new System.Drawing.Point(525, 260);
            this.btnBuilder.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuilder.Name = "btnBuilder";
            this.btnBuilder.Size = new System.Drawing.Size(98, 37);
            this.btnBuilder.TabIndex = 6;
            this.btnBuilder.Text = "Build Meterpreter";
            this.btnBuilder.UseVisualStyleBackColor = true;
            this.btnBuilder.Click += new System.EventHandler(this.btnBuilder_Click);
            // 
            // lblIp
            // 
            this.lblIp.AutoSize = true;
            this.lblIp.Location = new System.Drawing.Point(7, 35);
            this.lblIp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(20, 13);
            this.lblIp.TabIndex = 0;
            this.lblIp.Text = "IP:";
            // 
            // cmbPayload
            // 
            this.cmbPayload.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPayload.FormattingEnabled = true;
            this.cmbPayload.Items.AddRange(new object[] {
            "meterpreter/reverse_tcp",
            "x64/meterpreter/reverse_tcp",
            "meterpreter/reverse_tcp_rc4",
            "shell/reverse_tcp",
            "meterpreter/bind_tcp"});
            this.cmbPayload.Location = new System.Drawing.Point(59, 68);
            this.cmbPayload.Margin = new System.Windows.Forms.Padding(2);
            this.cmbPayload.Name = "cmbPayload";
            this.cmbPayload.Size = new System.Drawing.Size(220, 21);
            this.cmbPayload.TabIndex = 5;
            this.cmbPayload.SelectedIndexChanged += new System.EventHandler(this.cmbPayload_SelectedIndexChanged);
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(59, 32);
            this.txtIP.Margin = new System.Windows.Forms.Padding(2);
            this.txtIP.Multiline = true;
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(184, 19);
            this.txtIP.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 72);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Payload:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(247, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Port:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(280, 32);
            this.txtPort.Margin = new System.Windows.Forms.Padding(2);
            this.txtPort.Multiline = true;
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(109, 19);
            this.txtPort.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 329);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "SMET - Symmetric Meterpreter Encryption Tool";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cmbEncryption;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Button btnBuilder;
        private System.Windows.Forms.Label lblIp;
        private System.Windows.Forms.ComboBox cmbPayload;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPort;
    }
}