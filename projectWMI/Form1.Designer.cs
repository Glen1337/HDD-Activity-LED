namespace projectWMI
{
    partial class Menu
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
            this.diskMonBtn = new System.Windows.Forms.Button();
            this.hddLED = new System.Windows.Forms.Button();
            this.ssidFindBtn = new System.Windows.Forms.Button();
            this.compInfobtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.enumInstancesBtn = new System.Windows.Forms.Button();
            this.TextBox = new System.Windows.Forms.TextBox();
            this.nicBtn = new System.Windows.Forms.Button();
            this.hddSpaceBtn = new System.Windows.Forms.Button();
            this.tpmBtn = new System.Windows.Forms.Button();
            this.cpuBtn = new System.Windows.Forms.Button();
            this.envVarBtn = new System.Windows.Forms.Button();
            this.wikiBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // diskMonBtn
            // 
            this.diskMonBtn.Location = new System.Drawing.Point(12, 12);
            this.diskMonBtn.Name = "diskMonBtn";
            this.diskMonBtn.Size = new System.Drawing.Size(124, 20);
            this.diskMonBtn.TabIndex = 0;
            this.diskMonBtn.Text = "Disk Activity";
            this.diskMonBtn.UseVisualStyleBackColor = true;
            this.diskMonBtn.Click += new System.EventHandler(this.diskMon_Click);
            // 
            // hddLED
            // 
            this.hddLED.BackColor = System.Drawing.Color.Transparent;
            this.hddLED.Enabled = false;
            this.hddLED.FlatAppearance.BorderSize = 0;
            this.hddLED.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.hddLED.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.hddLED.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hddLED.Location = new System.Drawing.Point(142, 12);
            this.hddLED.Name = "hddLED";
            this.hddLED.Size = new System.Drawing.Size(54, 32);
            this.hddLED.TabIndex = 1;
            this.hddLED.UseVisualStyleBackColor = false;
            // 
            // ssidFindBtn
            // 
            this.ssidFindBtn.BackColor = System.Drawing.Color.Coral;
            this.ssidFindBtn.Location = new System.Drawing.Point(11, 38);
            this.ssidFindBtn.Name = "ssidFindBtn";
            this.ssidFindBtn.Size = new System.Drawing.Size(124, 27);
            this.ssidFindBtn.TabIndex = 2;
            this.ssidFindBtn.Text = "Find Network SSID";
            this.ssidFindBtn.UseVisualStyleBackColor = false;
            this.ssidFindBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // compInfobtn
            // 
            this.compInfobtn.Location = new System.Drawing.Point(11, 71);
            this.compInfobtn.Name = "compInfobtn";
            this.compInfobtn.Size = new System.Drawing.Size(145, 25);
            this.compInfobtn.TabIndex = 3;
            this.compInfobtn.Text = "Win32_ComputerSystem";
            this.compInfobtn.UseVisualStyleBackColor = true;
            this.compInfobtn.Click += new System.EventHandler(this.compInfobtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(527, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(527, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(527, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "label3";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(527, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "label4";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(527, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "label5";
            this.label5.Visible = false;
            // 
            // enumInstancesBtn
            // 
            this.enumInstancesBtn.Location = new System.Drawing.Point(11, 102);
            this.enumInstancesBtn.Name = "enumInstancesBtn";
            this.enumInstancesBtn.Size = new System.Drawing.Size(123, 28);
            this.enumInstancesBtn.TabIndex = 9;
            this.enumInstancesBtn.Text = "Enumerate Instances";
            this.enumInstancesBtn.UseVisualStyleBackColor = true;
            this.enumInstancesBtn.Click += new System.EventHandler(this.enumInstancesBtn_Click);
            // 
            // TextBox
            // 
            this.TextBox.Location = new System.Drawing.Point(596, 12);
            this.TextBox.Multiline = true;
            this.TextBox.Name = "TextBox";
            this.TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextBox.Size = new System.Drawing.Size(366, 309);
            this.TextBox.TabIndex = 10;
            this.TextBox.Visible = false;
            this.TextBox.WordWrap = false;
            // 
            // nicBtn
            // 
            this.nicBtn.Location = new System.Drawing.Point(11, 136);
            this.nicBtn.Name = "nicBtn";
            this.nicBtn.Size = new System.Drawing.Size(123, 20);
            this.nicBtn.TabIndex = 11;
            this.nicBtn.Text = "NIC";
            this.nicBtn.UseVisualStyleBackColor = true;
            this.nicBtn.Click += new System.EventHandler(this.nicBtn_Click);
            // 
            // hddSpaceBtn
            // 
            this.hddSpaceBtn.Location = new System.Drawing.Point(11, 162);
            this.hddSpaceBtn.Name = "hddSpaceBtn";
            this.hddSpaceBtn.Size = new System.Drawing.Size(123, 20);
            this.hddSpaceBtn.TabIndex = 12;
            this.hddSpaceBtn.Text = "HDD Space";
            this.hddSpaceBtn.UseVisualStyleBackColor = true;
            this.hddSpaceBtn.Click += new System.EventHandler(this.hddFreeSpaceBtn_Click);
            // 
            // tpmBtn
            // 
            this.tpmBtn.BackColor = System.Drawing.Color.Coral;
            this.tpmBtn.Location = new System.Drawing.Point(11, 188);
            this.tpmBtn.Name = "tpmBtn";
            this.tpmBtn.Size = new System.Drawing.Size(122, 20);
            this.tpmBtn.TabIndex = 13;
            this.tpmBtn.Text = "TPM";
            this.tpmBtn.UseVisualStyleBackColor = false;
            this.tpmBtn.Click += new System.EventHandler(this.tpmBtn_Click);
            // 
            // cpuBtn
            // 
            this.cpuBtn.Location = new System.Drawing.Point(12, 214);
            this.cpuBtn.Name = "cpuBtn";
            this.cpuBtn.Size = new System.Drawing.Size(121, 23);
            this.cpuBtn.TabIndex = 14;
            this.cpuBtn.Text = "CPU";
            this.cpuBtn.UseVisualStyleBackColor = true;
            this.cpuBtn.Click += new System.EventHandler(this.cpuBtn_Click);
            // 
            // envVarBtn
            // 
            this.envVarBtn.Location = new System.Drawing.Point(13, 244);
            this.envVarBtn.Name = "envVarBtn";
            this.envVarBtn.Size = new System.Drawing.Size(120, 40);
            this.envVarBtn.TabIndex = 15;
            this.envVarBtn.Text = "Env. Vars using object query";
            this.envVarBtn.UseVisualStyleBackColor = true;
            this.envVarBtn.Click += new System.EventHandler(this.envVarBtn_Click);
            // 
            // wikiBtn
            // 
            this.wikiBtn.BackColor = System.Drawing.Color.Coral;
            this.wikiBtn.Location = new System.Drawing.Point(13, 291);
            this.wikiBtn.Name = "wikiBtn";
            this.wikiBtn.Size = new System.Drawing.Size(120, 23);
            this.wikiBtn.TabIndex = 16;
            this.wikiBtn.Text = "wiki";
            this.wikiBtn.UseVisualStyleBackColor = false;
            this.wikiBtn.Click += new System.EventHandler(this.wikiBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(160, 290);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(974, 333);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.wikiBtn);
            this.Controls.Add(this.envVarBtn);
            this.Controls.Add(this.cpuBtn);
            this.Controls.Add(this.tpmBtn);
            this.Controls.Add(this.hddSpaceBtn);
            this.Controls.Add(this.nicBtn);
            this.Controls.Add(this.TextBox);
            this.Controls.Add(this.enumInstancesBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.compInfobtn);
            this.Controls.Add(this.ssidFindBtn);
            this.Controls.Add(this.hddLED);
            this.Controls.Add(this.diskMonBtn);
            this.Name = "Menu";
            this.Text = "WMI Tester - Glen";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Menu_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button diskMonBtn;
        private System.Windows.Forms.Button hddLED;
        private System.Windows.Forms.Button ssidFindBtn;
        private System.Windows.Forms.Button compInfobtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button enumInstancesBtn;
        private System.Windows.Forms.TextBox TextBox;
        private System.Windows.Forms.Button nicBtn;
        private System.Windows.Forms.Button hddSpaceBtn;
        private System.Windows.Forms.Button tpmBtn;
        private System.Windows.Forms.Button cpuBtn;
        private System.Windows.Forms.Button envVarBtn;
        private System.Windows.Forms.Button wikiBtn;
        private System.Windows.Forms.Button button1;
    }
}

