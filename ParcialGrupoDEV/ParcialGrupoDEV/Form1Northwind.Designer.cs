namespace ParcialGrupoDEV
{
    partial class Form1Northwind
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvConsulNorthwind = new System.Windows.Forms.DataGridView();
            this.btnConsulBasic = new System.Windows.Forms.Button();
            this.btnConsulInter = new System.Windows.Forms.Button();
            this.btnConsulAvan = new System.Windows.Forms.Button();
            this.cmbBasic = new System.Windows.Forms.ComboBox();
            this.cmbInter = new System.Windows.Forms.ComboBox();
            this.cmbAvan = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsulNorthwind)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvConsulNorthwind
            // 
            this.dgvConsulNorthwind.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsulNorthwind.Location = new System.Drawing.Point(12, 248);
            this.dgvConsulNorthwind.Name = "dgvConsulNorthwind";
            this.dgvConsulNorthwind.RowHeadersWidth = 62;
            this.dgvConsulNorthwind.RowTemplate.Height = 28;
            this.dgvConsulNorthwind.Size = new System.Drawing.Size(1112, 479);
            this.dgvConsulNorthwind.TabIndex = 0;
            this.dgvConsulNorthwind.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnConsulBasic
            // 
            this.btnConsulBasic.Location = new System.Drawing.Point(24, 36);
            this.btnConsulBasic.Name = "btnConsulBasic";
            this.btnConsulBasic.Size = new System.Drawing.Size(337, 46);
            this.btnConsulBasic.TabIndex = 1;
            this.btnConsulBasic.Text = "Consultas Basicas";
            this.btnConsulBasic.UseVisualStyleBackColor = true;
            this.btnConsulBasic.Click += new System.EventHandler(this.btnConsulBasic_Click);
            // 
            // btnConsulInter
            // 
            this.btnConsulInter.Location = new System.Drawing.Point(382, 36);
            this.btnConsulInter.Name = "btnConsulInter";
            this.btnConsulInter.Size = new System.Drawing.Size(337, 46);
            this.btnConsulInter.TabIndex = 2;
            this.btnConsulInter.Text = "Consultas Intermedias";
            this.btnConsulInter.UseVisualStyleBackColor = true;
            this.btnConsulInter.Click += new System.EventHandler(this.btnConsulInter_Click);
            // 
            // btnConsulAvan
            // 
            this.btnConsulAvan.Location = new System.Drawing.Point(740, 36);
            this.btnConsulAvan.Name = "btnConsulAvan";
            this.btnConsulAvan.Size = new System.Drawing.Size(337, 46);
            this.btnConsulAvan.TabIndex = 3;
            this.btnConsulAvan.Text = "Consultas Avanzadas";
            this.btnConsulAvan.UseVisualStyleBackColor = true;
            this.btnConsulAvan.Click += new System.EventHandler(this.btnConsulAvan_Click);
            // 
            // cmbBasic
            // 
            this.cmbBasic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBasic.FormattingEnabled = true;
            this.cmbBasic.Location = new System.Drawing.Point(24, 88);
            this.cmbBasic.Name = "cmbBasic";
            this.cmbBasic.Size = new System.Drawing.Size(337, 28);
            this.cmbBasic.TabIndex = 4;
            // 
            // cmbInter
            // 
            this.cmbInter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInter.FormattingEnabled = true;
            this.cmbInter.Location = new System.Drawing.Point(382, 88);
            this.cmbInter.Name = "cmbInter";
            this.cmbInter.Size = new System.Drawing.Size(337, 28);
            this.cmbInter.TabIndex = 5;
            // 
            // cmbAvan
            // 
            this.cmbAvan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAvan.FormattingEnabled = true;
            this.cmbAvan.Location = new System.Drawing.Point(740, 88);
            this.cmbAvan.Name = "cmbAvan";
            this.cmbAvan.Size = new System.Drawing.Size(337, 28);
            this.cmbAvan.TabIndex = 6;
            // 
            // Form1Northwind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 739);
            this.Controls.Add(this.btnConsulAvan);
            this.Controls.Add(this.btnConsulInter);
            this.Controls.Add(this.btnConsulBasic);
            this.Controls.Add(this.cmbAvan);
            this.Controls.Add(this.cmbInter);
            this.Controls.Add(this.cmbBasic);
            this.Controls.Add(this.dgvConsulNorthwind);
            this.Name = "Form1Northwind";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsulNorthwind)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvConsulNorthwind;
        private System.Windows.Forms.Button btnConsulBasic;
        private System.Windows.Forms.Button btnConsulInter;
        private System.Windows.Forms.Button btnConsulAvan;
        private System.Windows.Forms.ComboBox cmbBasic;
        private System.Windows.Forms.ComboBox cmbInter;
        private System.Windows.Forms.ComboBox cmbAvan;
    }
}

