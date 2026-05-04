namespace ParcialGrupoDEV
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
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openNorthwindToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPubsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenNorthwind = new System.Windows.Forms.Button();
            this.btnOpenPubs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // menuStrip1
            //
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1069, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            //
            // menuToolStripMenuItem
            //
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openNorthwindToolStripMenuItem,
            this.openPubsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(60, 29);
            this.menuToolStripMenuItem.Text = "Menu";
            //
            // openNorthwindToolStripMenuItem
            //
            this.openNorthwindToolStripMenuItem.Name = "openNorthwindToolStripMenuItem";
            this.openNorthwindToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.openNorthwindToolStripMenuItem.Text = "Abrir Northwind";
            this.openNorthwindToolStripMenuItem.Click += new System.EventHandler(this.openNorthwindToolStripMenuItem_Click);
            //
            // openPubsToolStripMenuItem
            //
            this.openPubsToolStripMenuItem.Name = "openPubsToolStripMenuItem";
            this.openPubsToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.openPubsToolStripMenuItem.Text = "Abrir Pubs";
            this.openPubsToolStripMenuItem.Click += new System.EventHandler(this.openPubsToolStripMenuItem_Click);
            //
            // exitToolStripMenuItem
            //
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.exitToolStripMenuItem.Text = "Salir";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            //
            // btnOpenNorthwind
            //
            this.btnOpenNorthwind.Location = new System.Drawing.Point(50, 80);
            this.btnOpenNorthwind.Name = "btnOpenNorthwind";
            this.btnOpenNorthwind.Size = new System.Drawing.Size(200, 50);
            this.btnOpenNorthwind.TabIndex = 1;
            this.btnOpenNorthwind.Text = "Abrir Northwind";
            this.btnOpenNorthwind.UseVisualStyleBackColor = true;
            this.btnOpenNorthwind.Click += new System.EventHandler(this.btnOpenNorthwind_Click);
            //
            // btnOpenPubs
            //
            this.btnOpenPubs.Location = new System.Drawing.Point(300, 80);
            this.btnOpenPubs.Name = "btnOpenPubs";
            this.btnOpenPubs.Size = new System.Drawing.Size(200, 50);
            this.btnOpenPubs.TabIndex = 2;
            this.btnOpenPubs.Text = "Abrir Pubs";
            this.btnOpenPubs.UseVisualStyleBackColor = true;
            this.btnOpenPubs.Click += new System.EventHandler(this.btnOpenPubs_Click);

            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 637);
            this.Controls.Add(this.btnOpenPubs);
            this.Controls.Add(this.btnOpenNorthwind);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Inicio - Consultas";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openNorthwindToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPubsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button btnOpenNorthwind;
        private System.Windows.Forms.Button btnOpenPubs;
    }
}