namespace ProyectoClip
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
            this.btnDepositar = new System.Windows.Forms.Button();
            this.txtMontoADepositar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSaldoActual = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNuevoSaldo = new System.Windows.Forms.TextBox();
            this.btnExtraccion = new System.Windows.Forms.Button();
            this.btnHistorialOperaciones = new System.Windows.Forms.Button();
            this.dtg_operaciones = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_operaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDepositar
            // 
            this.btnDepositar.Location = new System.Drawing.Point(284, 101);
            this.btnDepositar.Name = "btnDepositar";
            this.btnDepositar.Size = new System.Drawing.Size(75, 23);
            this.btnDepositar.TabIndex = 0;
            this.btnDepositar.Text = "Deposito";
            this.btnDepositar.UseVisualStyleBackColor = true;
            this.btnDepositar.Click += new System.EventHandler(this.btnDepositar_Click);
            // 
            // txtMontoADepositar
            // 
            this.txtMontoADepositar.Location = new System.Drawing.Point(340, 61);
            this.txtMontoADepositar.Name = "txtMontoADepositar";
            this.txtMontoADepositar.Size = new System.Drawing.Size(100, 20);
            this.txtMontoADepositar.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(242, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Monto operacion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Saldo Actual";
            // 
            // txtSaldoActual
            // 
            this.txtSaldoActual.Location = new System.Drawing.Point(131, 58);
            this.txtSaldoActual.Name = "txtSaldoActual";
            this.txtSaldoActual.Size = new System.Drawing.Size(100, 20);
            this.txtSaldoActual.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nuevo Saldo";
            // 
            // txtNuevoSaldo
            // 
            this.txtNuevoSaldo.Location = new System.Drawing.Point(131, 104);
            this.txtNuevoSaldo.Name = "txtNuevoSaldo";
            this.txtNuevoSaldo.Size = new System.Drawing.Size(100, 20);
            this.txtNuevoSaldo.TabIndex = 5;
            // 
            // btnExtraccion
            // 
            this.btnExtraccion.Location = new System.Drawing.Point(365, 101);
            this.btnExtraccion.Name = "btnExtraccion";
            this.btnExtraccion.Size = new System.Drawing.Size(75, 23);
            this.btnExtraccion.TabIndex = 7;
            this.btnExtraccion.Text = "Extraccion";
            this.btnExtraccion.UseVisualStyleBackColor = true;
            this.btnExtraccion.Click += new System.EventHandler(this.btnExtraccion_Click);
            // 
            // btnHistorialOperaciones
            // 
            this.btnHistorialOperaciones.Location = new System.Drawing.Point(365, 130);
            this.btnHistorialOperaciones.Name = "btnHistorialOperaciones";
            this.btnHistorialOperaciones.Size = new System.Drawing.Size(75, 27);
            this.btnHistorialOperaciones.TabIndex = 8;
            this.btnHistorialOperaciones.Text = "Ver historial";
            this.btnHistorialOperaciones.UseVisualStyleBackColor = true;
            this.btnHistorialOperaciones.Click += new System.EventHandler(this.btnHistorialOperaciones_Click);
            // 
            // dtg_operaciones
            // 
            this.dtg_operaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_operaciones.Location = new System.Drawing.Point(39, 184);
            this.dtg_operaciones.Name = "dtg_operaciones";
            this.dtg_operaciones.Size = new System.Drawing.Size(791, 288);
            this.dtg_operaciones.TabIndex = 9;
            this.dtg_operaciones.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(59, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 27);
            this.button1.TabIndex = 10;
            this.button1.Text = "Inicio";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 484);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtg_operaciones);
            this.Controls.Add(this.btnHistorialOperaciones);
            this.Controls.Add(this.btnExtraccion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNuevoSaldo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSaldoActual);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMontoADepositar);
            this.Controls.Add(this.btnDepositar);
            this.Name = "Form1";
            this.Text = "Deposito/Extraccion";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_operaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDepositar;
        private System.Windows.Forms.TextBox txtMontoADepositar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSaldoActual;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNuevoSaldo;
        private System.Windows.Forms.Button btnExtraccion;
        private System.Windows.Forms.Button btnHistorialOperaciones;
        private System.Windows.Forms.DataGridView dtg_operaciones;
        private System.Windows.Forms.Button button1;
    }
}

