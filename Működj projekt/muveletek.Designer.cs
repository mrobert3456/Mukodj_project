namespace Működj_projekt
{
    partial class muveletek
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnujrek = new System.Windows.Forms.Button();
            this.btnmod = new System.Windows.Forms.Button();
            this.btntorol = new System.Windows.Forms.Button();
            this.btnfriss = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnujrek
            // 
            this.btnujrek.Location = new System.Drawing.Point(12, 76);
            this.btnujrek.Name = "btnujrek";
            this.btnujrek.Size = new System.Drawing.Size(191, 23);
            this.btnujrek.TabIndex = 0;
            this.btnujrek.Text = "Új rekord";
            this.btnujrek.UseVisualStyleBackColor = true;
            this.btnujrek.Click += new System.EventHandler(this.btnujrek_Click);
            // 
            // btnmod
            // 
            this.btnmod.Location = new System.Drawing.Point(12, 18);
            this.btnmod.Name = "btnmod";
            this.btnmod.Size = new System.Drawing.Size(191, 23);
            this.btnmod.TabIndex = 1;
            this.btnmod.Text = "Módosít";
            this.btnmod.UseVisualStyleBackColor = true;
            this.btnmod.Click += new System.EventHandler(this.btnmod_Click);
            // 
            // btntorol
            // 
            this.btntorol.Location = new System.Drawing.Point(12, 47);
            this.btntorol.Name = "btntorol";
            this.btntorol.Size = new System.Drawing.Size(191, 23);
            this.btntorol.TabIndex = 2;
            this.btntorol.Text = "Törlés";
            this.btntorol.UseVisualStyleBackColor = true;
            this.btntorol.Click += new System.EventHandler(this.btntorol_Click);
            // 
            // btnfriss
            // 
            this.btnfriss.Location = new System.Drawing.Point(12, 106);
            this.btnfriss.Name = "btnfriss";
            this.btnfriss.Size = new System.Drawing.Size(191, 23);
            this.btnfriss.TabIndex = 3;
            this.btnfriss.Text = "Frissités";
            this.btnfriss.UseVisualStyleBackColor = true;
            this.btnfriss.Click += new System.EventHandler(this.btnfriss_Click);
            // 
            // muveletek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnfriss);
            this.Controls.Add(this.btntorol);
            this.Controls.Add(this.btnmod);
            this.Controls.Add(this.btnujrek);
            this.Name = "muveletek";
            this.Size = new System.Drawing.Size(221, 158);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnujrek;
        private System.Windows.Forms.Button btnmod;
        private System.Windows.Forms.Button btntorol;
        private System.Windows.Forms.Button btnfriss;
    }
}
