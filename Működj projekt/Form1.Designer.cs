namespace Működj_projekt
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnmegse = new System.Windows.Forms.Button();
            this.btnok = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.txtpath = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ujsqllog = new System.Windows.Forms.RadioButton();
            this.ujwinlog = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.txtujuser = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtujpw = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtujdb = new System.Windows.Forms.TextBox();
            this.txtujserver = new System.Windows.Forms.TextBox();
            this.vissza2 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.csat = new System.Windows.Forms.Button();
            this.uj = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtadatbnev = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.vissza = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.servername = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.WinLog = new System.Windows.Forms.RadioButton();
            this.SqlLog = new System.Windows.Forms.RadioButton();
            this.username = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnmegse
            // 
            this.btnmegse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnmegse.Location = new System.Drawing.Point(346, 351);
            this.btnmegse.Margin = new System.Windows.Forms.Padding(2);
            this.btnmegse.Name = "btnmegse";
            this.btnmegse.Size = new System.Drawing.Size(56, 21);
            this.btnmegse.TabIndex = 22;
            this.btnmegse.Text = "Mégse";
            this.btnmegse.UseVisualStyleBackColor = true;
            this.btnmegse.Click += new System.EventHandler(this.btnmegse_Click);
            // 
            // btnok
            // 
            this.btnok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnok.Location = new System.Drawing.Point(33, 351);
            this.btnok.Margin = new System.Windows.Forms.Padding(2);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(56, 21);
            this.btnok.TabIndex = 21;
            this.btnok.Text = "Ok";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.txtpath);
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtujdb);
            this.panel3.Controls.Add(this.txtujserver);
            this.panel3.Controls.Add(this.vissza2);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Location = new System.Drawing.Point(33, 29);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(368, 317);
            this.panel3.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 60);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Új adatbázis helye:";
            // 
            // txtpath
            // 
            this.txtpath.Location = new System.Drawing.Point(107, 57);
            this.txtpath.Margin = new System.Windows.Forms.Padding(2);
            this.txtpath.Name = "txtpath";
            this.txtpath.Size = new System.Drawing.Size(76, 20);
            this.txtpath.TabIndex = 18;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ujsqllog);
            this.groupBox2.Controls.Add(this.ujwinlog);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtujuser);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtujpw);
            this.groupBox2.Location = new System.Drawing.Point(5, 111);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(177, 117);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            // 
            // ujsqllog
            // 
            this.ujsqllog.AutoSize = true;
            this.ujsqllog.Location = new System.Drawing.Point(4, 38);
            this.ujsqllog.Margin = new System.Windows.Forms.Padding(2);
            this.ujsqllog.Name = "ujsqllog";
            this.ujsqllog.Size = new System.Drawing.Size(114, 17);
            this.ujsqllog.TabIndex = 1;
            this.ujsqllog.TabStop = true;
            this.ujsqllog.Text = "SQL bejelentkezés";
            this.ujsqllog.UseVisualStyleBackColor = true;
            this.ujsqllog.CheckedChanged += new System.EventHandler(this.ujsqllog_CheckedChanged);
            // 
            // ujwinlog
            // 
            this.ujwinlog.AutoSize = true;
            this.ujwinlog.Location = new System.Drawing.Point(4, 16);
            this.ujwinlog.Margin = new System.Windows.Forms.Padding(2);
            this.ujwinlog.Name = "ujwinlog";
            this.ujwinlog.Size = new System.Drawing.Size(137, 17);
            this.ujwinlog.TabIndex = 0;
            this.ujwinlog.TabStop = true;
            this.ujwinlog.Text = "Windows bejelentkezés";
            this.ujwinlog.UseVisualStyleBackColor = true;
            this.ujwinlog.CheckedChanged += new System.EventHandler(this.ujwinlog_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 98);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Jelszó:";
            // 
            // txtujuser
            // 
            this.txtujuser.Location = new System.Drawing.Point(92, 72);
            this.txtujuser.Margin = new System.Windows.Forms.Padding(2);
            this.txtujuser.Name = "txtujuser";
            this.txtujuser.Size = new System.Drawing.Size(76, 20);
            this.txtujuser.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 75);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Felhasználónév:";
            // 
            // txtujpw
            // 
            this.txtujpw.Location = new System.Drawing.Point(92, 95);
            this.txtujpw.Margin = new System.Windows.Forms.Padding(2);
            this.txtujpw.Name = "txtujpw";
            this.txtujpw.Size = new System.Drawing.Size(76, 20);
            this.txtujpw.TabIndex = 20;
            this.txtujpw.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(187, 11);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 129);
            this.button1.TabIndex = 24;
            this.button1.Text = "Kérem írja be az adminisztrátori fiók felhasználónevét és jelszavát!";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 37);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Új adatbázis neve:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 14);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Szerver:";
            // 
            // txtujdb
            // 
            this.txtujdb.Location = new System.Drawing.Point(107, 34);
            this.txtujdb.Margin = new System.Windows.Forms.Padding(2);
            this.txtujdb.Name = "txtujdb";
            this.txtujdb.Size = new System.Drawing.Size(76, 20);
            this.txtujdb.TabIndex = 17;
            // 
            // txtujserver
            // 
            this.txtujserver.Location = new System.Drawing.Point(107, 11);
            this.txtujserver.Margin = new System.Windows.Forms.Padding(2);
            this.txtujserver.Name = "txtujserver";
            this.txtujserver.Size = new System.Drawing.Size(76, 20);
            this.txtujserver.TabIndex = 16;
            // 
            // vissza2
            // 
            this.vissza2.Location = new System.Drawing.Point(150, 284);
            this.vissza2.Margin = new System.Windows.Forms.Padding(2);
            this.vissza2.Name = "vissza2";
            this.vissza2.Size = new System.Drawing.Size(75, 24);
            this.vissza2.TabIndex = 15;
            this.vissza2.Text = "Vissza";
            this.vissza2.UseVisualStyleBackColor = true;
            this.vissza2.Click += new System.EventHandler(this.vissza2_Click);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(2, 92);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(180, 16);
            this.label8.TabIndex = 25;
            this.label8.Text = "________________________________________________________________________";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel2.Controls.Add(this.csat);
            this.panel2.Controls.Add(this.uj);
            this.panel2.Location = new System.Drawing.Point(33, 29);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(368, 317);
            this.panel2.TabIndex = 24;
            // 
            // csat
            // 
            this.csat.Location = new System.Drawing.Point(3, 84);
            this.csat.Margin = new System.Windows.Forms.Padding(2);
            this.csat.Name = "csat";
            this.csat.Size = new System.Drawing.Size(361, 32);
            this.csat.TabIndex = 2;
            this.csat.Text = "Csatlakozás meglévő adatbázishoz";
            this.csat.UseVisualStyleBackColor = true;
            this.csat.Click += new System.EventHandler(this.csat_Click_1);
            // 
            // uj
            // 
            this.uj.Location = new System.Drawing.Point(3, 40);
            this.uj.Margin = new System.Windows.Forms.Padding(2);
            this.uj.Name = "uj";
            this.uj.Size = new System.Drawing.Size(361, 32);
            this.uj.TabIndex = 1;
            this.uj.Text = "Új adatbázis létrehozása";
            this.uj.UseVisualStyleBackColor = true;
            this.uj.Click += new System.EventHandler(this.uj_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel1.Controls.Add(this.txtadatbnev);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.vissza);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.servername);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(33, 29);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(368, 317);
            this.panel1.TabIndex = 23;
            // 
            // txtadatbnev
            // 
            this.txtadatbnev.Location = new System.Drawing.Point(102, 34);
            this.txtadatbnev.Margin = new System.Windows.Forms.Padding(2);
            this.txtadatbnev.Name = "txtadatbnev";
            this.txtadatbnev.Size = new System.Drawing.Size(76, 20);
            this.txtadatbnev.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 37);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Adatbázisnév:";
            // 
            // vissza
            // 
            this.vissza.Location = new System.Drawing.Point(150, 284);
            this.vissza.Margin = new System.Windows.Forms.Padding(2);
            this.vissza.Name = "vissza";
            this.vissza.Size = new System.Drawing.Size(75, 24);
            this.vissza.TabIndex = 11;
            this.vissza.Text = "Vissza";
            this.vissza.UseVisualStyleBackColor = true;
            this.vissza.Click += new System.EventHandler(this.vissza_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Szerver:";
            // 
            // servername
            // 
            this.servername.Location = new System.Drawing.Point(102, 8);
            this.servername.Margin = new System.Windows.Forms.Padding(2);
            this.servername.Name = "servername";
            this.servername.Size = new System.Drawing.Size(76, 20);
            this.servername.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.WinLog);
            this.groupBox1.Controls.Add(this.SqlLog);
            this.groupBox1.Controls.Add(this.username);
            this.groupBox1.Controls.Add(this.password);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(59, 61);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(232, 136);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bejelentkezés";
            // 
            // WinLog
            // 
            this.WinLog.AutoSize = true;
            this.WinLog.Location = new System.Drawing.Point(4, 24);
            this.WinLog.Margin = new System.Windows.Forms.Padding(2);
            this.WinLog.Name = "WinLog";
            this.WinLog.Size = new System.Drawing.Size(137, 17);
            this.WinLog.TabIndex = 0;
            this.WinLog.TabStop = true;
            this.WinLog.Text = "Windows bejelentkezés";
            this.WinLog.UseVisualStyleBackColor = true;
            this.WinLog.CheckedChanged += new System.EventHandler(this.WinLog_CheckedChanged);
            // 
            // SqlLog
            // 
            this.SqlLog.AutoSize = true;
            this.SqlLog.Location = new System.Drawing.Point(4, 46);
            this.SqlLog.Margin = new System.Windows.Forms.Padding(2);
            this.SqlLog.Name = "SqlLog";
            this.SqlLog.Size = new System.Drawing.Size(114, 17);
            this.SqlLog.TabIndex = 1;
            this.SqlLog.TabStop = true;
            this.SqlLog.Text = "SQL bejelentkezés";
            this.SqlLog.UseVisualStyleBackColor = true;
            this.SqlLog.CheckedChanged += new System.EventHandler(this.SqlLog_CheckedChanged);
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(100, 77);
            this.username.Margin = new System.Windows.Forms.Padding(2);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(76, 20);
            this.username.TabIndex = 4;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(100, 109);
            this.password.Margin = new System.Windows.Forms.Padding(2);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(76, 20);
            this.password.TabIndex = 5;
            this.password.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Felhasználónév:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 111);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Jelszó:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(435, 25);
            this.toolStrip1.TabIndex = 25;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.helpToolStripButton.Text = "He&lp";
            this.helpToolStripButton.Click += new System.EventHandler(this.helpToolStripButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 401);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnmegse);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Bejelentkezés";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnmegse;
        private System.Windows.Forms.Button btnok;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtpath;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton ujsqllog;
        private System.Windows.Forms.RadioButton ujwinlog;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtujuser;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtujpw;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtujdb;
        private System.Windows.Forms.TextBox txtujserver;
        private System.Windows.Forms.Button vissza2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button csat;
        private System.Windows.Forms.Button uj;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtadatbnev;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button vissza;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox servername;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton WinLog;
        private System.Windows.Forms.RadioButton SqlLog;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
    }
}

