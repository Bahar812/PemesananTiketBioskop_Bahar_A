namespace PemesananTiketBioskop
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.studioRegularToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studioPremiereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studioDolbyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studioIMAXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.studioRegularToolStripMenuItem,
            this.studioPremiereToolStripMenuItem,
            this.studioDolbyToolStripMenuItem,
            this.studioIMAXToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // studioRegularToolStripMenuItem
            // 
            this.studioRegularToolStripMenuItem.Name = "studioRegularToolStripMenuItem";
            this.studioRegularToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.studioRegularToolStripMenuItem.Text = "Studio Regular";
            this.studioRegularToolStripMenuItem.Click += new System.EventHandler(this.studioRegularToolStripMenuItem_Click);
            // 
            // studioPremiereToolStripMenuItem
            // 
            this.studioPremiereToolStripMenuItem.Name = "studioPremiereToolStripMenuItem";
            this.studioPremiereToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            this.studioPremiereToolStripMenuItem.Text = "Studio Premiere";
            // 
            // studioDolbyToolStripMenuItem
            // 
            this.studioDolbyToolStripMenuItem.Name = "studioDolbyToolStripMenuItem";
            this.studioDolbyToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
            this.studioDolbyToolStripMenuItem.Text = "Studio Dolby Atmos";
            // 
            // studioIMAXToolStripMenuItem
            // 
            this.studioIMAXToolStripMenuItem.Name = "studioIMAXToolStripMenuItem";
            this.studioIMAXToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.studioIMAXToolStripMenuItem.Text = "Studio IMAX";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem studioRegularToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studioPremiereToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studioDolbyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studioIMAXToolStripMenuItem;
    }
}

