namespace ProyectoClip
{
    partial class Transferencias
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
            this.btnTransferir = new System.Windows.Forms.Button();
            this.nombreCliente = new System.Windows.Forms.TextBox();
            this.txtNumeroCuenta = new System.Windows.Forms.TextBox();
            this.txtNumeroCaja = new System.Windows.Forms.TextBox();
            this.txtMoneda = new System.Windows.Forms.TextBox();
            this.txtNombreDestino = new System.Windows.Forms.TextBox();
            this.txtNroCuenta = new System.Windows.Forms.TextBox();
            this.txtNroCaja = new System.Windows.Forms.TextBox();
            this.MontoATrasnferir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMonedaD = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dataTransferencias = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataTransferencias)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTransferir
            // 
            this.btnTransferir.Location = new System.Drawing.Point(405, 275);
            this.btnTransferir.Name = "btnTransferir";
            this.btnTransferir.Size = new System.Drawing.Size(132, 38);
            this.btnTransferir.TabIndex = 0;
            this.btnTransferir.Text = "Transferir";
            this.btnTransferir.UseVisualStyleBackColor = true;
            this.btnTransferir.Click += new System.EventHandler(this.btnTransferir_Click);
            // 
            // nombreCliente
            // 
            this.nombreCliente.Location = new System.Drawing.Point(136, 109);
            this.nombreCliente.Name = "nombreCliente";
            this.nombreCliente.Size = new System.Drawing.Size(140, 20);
            this.nombreCliente.TabIndex = 1;
            // 
            // txtNumeroCuenta
            // 
            this.txtNumeroCuenta.Location = new System.Drawing.Point(136, 146);
            this.txtNumeroCuenta.Name = "txtNumeroCuenta";
            this.txtNumeroCuenta.Size = new System.Drawing.Size(140, 20);
            this.txtNumeroCuenta.TabIndex = 2;
            // 
            // txtNumeroCaja
            // 
            this.txtNumeroCaja.Location = new System.Drawing.Point(136, 182);
            this.txtNumeroCaja.Name = "txtNumeroCaja";
            this.txtNumeroCaja.Size = new System.Drawing.Size(140, 20);
            this.txtNumeroCaja.TabIndex = 3;
            // 
            // txtMoneda
            // 
            this.txtMoneda.Location = new System.Drawing.Point(136, 217);
            this.txtMoneda.Name = "txtMoneda";
            this.txtMoneda.Size = new System.Drawing.Size(140, 20);
            this.txtMoneda.TabIndex = 4;
            // 
            // txtNombreDestino
            // 
            this.txtNombreDestino.Location = new System.Drawing.Point(408, 109);
            this.txtNombreDestino.Name = "txtNombreDestino";
            this.txtNombreDestino.Size = new System.Drawing.Size(129, 20);
            this.txtNombreDestino.TabIndex = 5;
            // 
            // txtNroCuenta
            // 
            this.txtNroCuenta.Location = new System.Drawing.Point(408, 146);
            this.txtNroCuenta.Name = "txtNroCuenta";
            this.txtNroCuenta.Size = new System.Drawing.Size(129, 20);
            this.txtNroCuenta.TabIndex = 6;
            // 
            // txtNroCaja
            // 
            this.txtNroCaja.Location = new System.Drawing.Point(408, 182);
            this.txtNroCaja.Name = "txtNroCaja";
            this.txtNroCaja.Size = new System.Drawing.Size(129, 20);
            this.txtNroCaja.TabIndex = 7;
            // 
            // MontoATrasnferir
            // 
            this.MontoATrasnferir.Location = new System.Drawing.Point(136, 256);
            this.MontoATrasnferir.Name = "MontoATrasnferir";
            this.MontoATrasnferir.Size = new System.Drawing.Size(140, 20);
            this.MontoATrasnferir.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Numero Cuenta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Numero Caja";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(84, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Moneda";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Monto transferencia";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(356, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Moneda";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(334, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Numero Caja";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(321, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Numero Cuenta";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(358, 116);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Nombre";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(156, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Datos cuenta de Origen";
            // 
            // txtMonedaD
            // 
            this.txtMonedaD.Location = new System.Drawing.Point(408, 217);
            this.txtMonedaD.Name = "txtMonedaD";
            this.txtMonedaD.Size = new System.Drawing.Size(129, 20);
            this.txtMonedaD.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(402, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(125, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Datos cuenta de Destino";
            // 
            // dataTransferencias
            // 
            this.dataTransferencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTransferencias.Location = new System.Drawing.Point(573, 48);
            this.dataTransferencias.Name = "dataTransferencias";
            this.dataTransferencias.Size = new System.Drawing.Size(352, 333);
            this.dataTransferencias.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(570, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(117, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Historial Transferencias";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(702, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 24);
            this.button1.TabIndex = 23;
            this.button1.Text = "Ver transferencias";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(86, 84);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "Saldo";
            // 
            // txtSaldo
            // 
            this.txtSaldo.Location = new System.Drawing.Point(136, 81);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.Size = new System.Drawing.Size(140, 20);
            this.txtSaldo.TabIndex = 24;
            // 
            // RegistroParaPrueba
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 403);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtSaldo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dataTransferencias);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MontoATrasnferir);
            this.Controls.Add(this.txtMonedaD);
            this.Controls.Add(this.txtNroCaja);
            this.Controls.Add(this.txtNroCuenta);
            this.Controls.Add(this.txtNombreDestino);
            this.Controls.Add(this.txtMoneda);
            this.Controls.Add(this.txtNumeroCaja);
            this.Controls.Add(this.txtNumeroCuenta);
            this.Controls.Add(this.nombreCliente);
            this.Controls.Add(this.btnTransferir);
            this.Name = "RegistroParaPrueba";
            this.Text = "Transferencias";
            this.Load += new System.EventHandler(this.RegistroParaPrueba_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataTransferencias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTransferir;
        private System.Windows.Forms.TextBox nombreCliente;
        private System.Windows.Forms.TextBox txtNumeroCuenta;
        private System.Windows.Forms.TextBox txtNumeroCaja;
        private System.Windows.Forms.TextBox txtMoneda;
        private System.Windows.Forms.TextBox txtNombreDestino;
        private System.Windows.Forms.TextBox txtNroCuenta;
        private System.Windows.Forms.TextBox txtNroCaja;
        private System.Windows.Forms.TextBox MontoATrasnferir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMonedaD;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dataTransferencias;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSaldo;
    }
}