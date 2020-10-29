namespace ProyectoClip
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
            this.label1 = new System.Windows.Forms.Label();
            this.AbrirTransferencia = new System.Windows.Forms.Button();
            this.AbrirExtDep = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clip Money";
            // 
            // AbrirTransferencia
            // 
            this.AbrirTransferencia.Location = new System.Drawing.Point(45, 71);
            this.AbrirTransferencia.Name = "AbrirTransferencia";
            this.AbrirTransferencia.Size = new System.Drawing.Size(168, 46);
            this.AbrirTransferencia.TabIndex = 1;
            this.AbrirTransferencia.Text = "Realizar transferencia";
            this.AbrirTransferencia.UseVisualStyleBackColor = true;
            this.AbrirTransferencia.Click += new System.EventHandler(this.AbrirTransferencia_Click);
            // 
            // AbrirExtDep
            // 
            this.AbrirExtDep.Location = new System.Drawing.Point(45, 136);
            this.AbrirExtDep.Name = "AbrirExtDep";
            this.AbrirExtDep.Size = new System.Drawing.Size(168, 46);
            this.AbrirExtDep.TabIndex = 2;
            this.AbrirExtDep.Text = "Retirar/Ingresar Dinero\r\n";
            this.AbrirExtDep.UseVisualStyleBackColor = true;
            this.AbrirExtDep.Click += new System.EventHandler(this.AbrirExtDep_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 250);
            this.Controls.Add(this.AbrirExtDep);
            this.Controls.Add(this.AbrirTransferencia);
            this.Controls.Add(this.label1);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AbrirTransferencia;
        private System.Windows.Forms.Button AbrirExtDep;
    }
}