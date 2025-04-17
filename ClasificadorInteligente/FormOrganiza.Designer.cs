namespace ClasificadorInteligente
{
    partial class FormOrganiza
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOrganiza));
            this.TxtRuta = new System.Windows.Forms.TextBox();
            this.BtProcesar = new System.Windows.Forms.Button();
            this.PbProceso = new System.Windows.Forms.ProgressBar();
            this.BtElegirCarpeta = new System.Windows.Forms.Button();
            this.LbPrincipal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TxtRuta
            // 
            this.TxtRuta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtRuta.Location = new System.Drawing.Point(71, 39);
            this.TxtRuta.Name = "TxtRuta";
            this.TxtRuta.ReadOnly = true;
            this.TxtRuta.Size = new System.Drawing.Size(355, 20);
            this.TxtRuta.TabIndex = 1;
            // 
            // BtProcesar
            // 
            this.BtProcesar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtProcesar.Location = new System.Drawing.Point(351, 65);
            this.BtProcesar.Name = "BtProcesar";
            this.BtProcesar.Size = new System.Drawing.Size(75, 23);
            this.BtProcesar.TabIndex = 2;
            this.BtProcesar.Text = "Procesar";
            this.BtProcesar.UseVisualStyleBackColor = true;
            this.BtProcesar.Click += new System.EventHandler(this.BtProcesar_Click);
            // 
            // PbProceso
            // 
            this.PbProceso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PbProceso.Location = new System.Drawing.Point(26, 104);
            this.PbProceso.Name = "PbProceso";
            this.PbProceso.Size = new System.Drawing.Size(400, 11);
            this.PbProceso.TabIndex = 3;
            // 
            // BtElegirCarpeta
            // 
            this.BtElegirCarpeta.Image = global::ClasificadorInteligente.Properties.Resources.telephone_5647721;
            this.BtElegirCarpeta.Location = new System.Drawing.Point(26, 33);
            this.BtElegirCarpeta.Name = "BtElegirCarpeta";
            this.BtElegirCarpeta.Size = new System.Drawing.Size(39, 31);
            this.BtElegirCarpeta.TabIndex = 0;
            this.BtElegirCarpeta.UseVisualStyleBackColor = true;
            this.BtElegirCarpeta.Click += new System.EventHandler(this.BtElegirCarpeta_Click);
            // 
            // LbPrincipal
            // 
            this.LbPrincipal.AutoSize = true;
            this.LbPrincipal.Location = new System.Drawing.Point(68, 23);
            this.LbPrincipal.Name = "LbPrincipal";
            this.LbPrincipal.Size = new System.Drawing.Size(212, 13);
            this.LbPrincipal.TabIndex = 4;
            this.LbPrincipal.Text = "Elige una carpeta para odenar los archivos:";
            // 
            // FormOrganiza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 155);
            this.Controls.Add(this.LbPrincipal);
            this.Controls.Add(this.PbProceso);
            this.Controls.Add(this.BtProcesar);
            this.Controls.Add(this.TxtRuta);
            this.Controls.Add(this.BtElegirCarpeta);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(480, 194);
            this.Name = "FormOrganiza";
            this.Text = "Organiza Carpetas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtElegirCarpeta;
        private System.Windows.Forms.TextBox TxtRuta;
        private System.Windows.Forms.Button BtProcesar;
        private System.Windows.Forms.ProgressBar PbProceso;
        private System.Windows.Forms.Label LbPrincipal;
    }
}