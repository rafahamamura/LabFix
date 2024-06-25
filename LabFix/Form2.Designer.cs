namespace LabFix
{
    partial class frm_configIP
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
            cbLabs = new ComboBox();
            label2 = new Label();
            cbHosts = new ComboBox();
            txtLog = new TextBox();
            progressBar1 = new ProgressBar();
            label3 = new Label();
            txtBoxHostname = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            cbInterfaces = new ComboBox();
            txtBoxIP = new TextBox();
            txtBoxMask = new TextBox();
            txtBoxGw = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(106, 20);
            label1.TabIndex = 0;
            label1.Text = "LABORATÓRIO";
            // 
            // cbLabs
            // 
            cbLabs.FormattingEnabled = true;
            cbLabs.Location = new Point(12, 32);
            cbLabs.Name = "cbLabs";
            cbLabs.Size = new Size(160, 28);
            cbLabs.TabIndex = 1;
            cbLabs.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(178, 9);
            label2.Name = "label2";
            label2.Size = new Size(78, 20);
            label2.TabIndex = 2;
            label2.Text = "MÁQUINA";
            // 
            // cbHosts
            // 
            cbHosts.FormattingEnabled = true;
            cbHosts.Location = new Point(178, 32);
            cbHosts.Name = "cbHosts";
            cbHosts.Size = new Size(160, 28);
            cbHosts.TabIndex = 3;
            cbHosts.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // txtLog
            // 
            txtLog.Location = new Point(356, 12);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.Size = new Size(388, 401);
            txtLog.TabIndex = 4;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 430);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(732, 11);
            progressBar1.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 164);
            label3.Name = "label3";
            label3.Size = new Size(80, 20);
            label3.TabIndex = 6;
            label3.Text = "Hostname:";
            // 
            // txtBoxHostname
            // 
            txtBoxHostname.Enabled = false;
            txtBoxHostname.Location = new Point(98, 161);
            txtBoxHostname.Name = "txtBoxHostname";
            txtBoxHostname.Size = new Size(240, 27);
            txtBoxHostname.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 210);
            label4.Name = "label4";
            label4.Size = new Size(94, 20);
            label4.TabIndex = 8;
            label4.Text = "Endereço IP: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 251);
            label5.Name = "label5";
            label5.Size = new Size(67, 20);
            label5.TabIndex = 9;
            label5.Text = "Máscara:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 293);
            label6.Name = "label6";
            label6.Size = new Size(73, 20);
            label6.TabIndex = 10;
            label6.Text = "Gateway: ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 79);
            label7.Name = "label7";
            label7.Size = new Size(82, 20);
            label7.TabIndex = 11;
            label7.Text = "INTERFACE";
            // 
            // cbInterfaces
            // 
            cbInterfaces.FormattingEnabled = true;
            cbInterfaces.Location = new Point(12, 102);
            cbInterfaces.Name = "cbInterfaces";
            cbInterfaces.Size = new Size(326, 28);
            cbInterfaces.TabIndex = 12;
            cbInterfaces.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // txtBoxIP
            // 
            txtBoxIP.Enabled = false;
            txtBoxIP.Location = new Point(112, 207);
            txtBoxIP.Name = "txtBoxIP";
            txtBoxIP.Size = new Size(226, 27);
            txtBoxIP.TabIndex = 13;
            // 
            // txtBoxMask
            // 
            txtBoxMask.Enabled = false;
            txtBoxMask.Location = new Point(85, 248);
            txtBoxMask.Name = "txtBoxMask";
            txtBoxMask.Size = new Size(253, 27);
            txtBoxMask.TabIndex = 14;
            // 
            // txtBoxGw
            // 
            txtBoxGw.Enabled = false;
            txtBoxGw.Location = new Point(112, 290);
            txtBoxGw.Name = "txtBoxGw";
            txtBoxGw.Size = new Size(226, 27);
            txtBoxGw.TabIndex = 15;
            // 
            // button1
            // 
            button1.Location = new Point(12, 339);
            button1.Name = "button1";
            button1.Size = new Size(326, 74);
            button1.TabIndex = 16;
            button1.Text = "Aplicar";
            button1.UseVisualStyleBackColor = true;
            // 
            // frm_configIP
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(758, 453);
            Controls.Add(button1);
            Controls.Add(txtBoxGw);
            Controls.Add(txtBoxMask);
            Controls.Add(txtBoxIP);
            Controls.Add(cbInterfaces);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtBoxHostname);
            Controls.Add(label3);
            Controls.Add(progressBar1);
            Controls.Add(txtLog);
            Controls.Add(cbHosts);
            Controls.Add(label2);
            Controls.Add(cbLabs);
            Controls.Add(label1);
            Name = "frm_configIP";
            Text = "Configuração de IP";
            Load += frm_configIP_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cbLabs;
        private Label label2;
        private ComboBox cbHosts;
        private TextBox txtLog;
        private ProgressBar progressBar1;
        private Label label3;
        private TextBox txtBoxHostname;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private ComboBox cbInterfaces;
        private TextBox txtBoxIP;
        private TextBox txtBoxMask;
        private TextBox txtBoxGw;
        private Button button1;
    }
}