using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProyectoClip.Clases;

namespace ProyectoClip
    
{
    public partial class Form1 : Form
    {
        private static Moneda pesoArgentino = new Moneda("Pesos Argentinos", 1);
        private static DateTime fechaAlta = new DateTime(2020, 10, 25);
        private static Caja cajaEnPesos = new Caja(pesoArgentino, 2000, 152);
        private static Caja[] cajas = { cajaEnPesos };
        private static EstadoCuenta activa = new EstadoCuenta();
        private static Cuenta cuenta = new Cuenta(156808253, fechaAlta, activa, cajas);
        private static TipoDocumento tipoDoc = new TipoDocumento("DNI", "Documento Nacional de Identidad");
        private static Cliente clienteNuevo = new Cliente("Juan", "Cuello", tipoDoc, "jcuello@gmail.com", cuenta, "Habilitado");
        DataTable operaciones = new DataTable();

        



        public Form1()
        {
            InitializeComponent();
            

        }
       

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            double saldoAnterior = cuenta.ObtenerSaldoCajaPesos();
            double montoAdepositar = double.Parse(txtMontoADepositar.Text);
            Deposito deposito = new Deposito(cuenta, montoAdepositar, pesoArgentino);
            deposito.realizar();
            txtNuevoSaldo.Text = cuenta.ObtenerSaldoCajaPesos().ToString();
            txtSaldoActual.Text = cuenta.ObtenerSaldoCajaPesos().ToString();
            MessageBox.Show("Operacion Realizada con Exitoso!");
            operaciones.Rows.Add(deposito.Nombre, saldoAnterior, deposito.Monto, cuenta.ObtenerSaldoCajaPesos(), deposito.FechaOperacion);
        }

        private void btnExtraccion_Click(object sender, EventArgs e)
        {
            
            double montoAretirar = double.Parse(txtMontoADepositar.Text);
            double saldoActual = cuenta.ObtenerSaldoCajaPesos();
            Extraccion extraccion = new Extraccion(cuenta, montoAretirar, pesoArgentino);            
            
            if (saldoActual < montoAretirar)
            {
                MessageBox.Show("Lo sentimos, no posee el saldo suficiente para realizar esta operacion");            
            }
            else
            {
                extraccion.realizar();                
                MessageBox.Show("Operacion Realizada con Exitoso!");

                operaciones.Rows.Add(extraccion.Nombre, saldoActual, extraccion.Monto, cuenta.ObtenerSaldoCajaPesos(),extraccion.FechaOperacion);
            }
            txtNuevoSaldo.Text = cuenta.ObtenerSaldoCajaPesos().ToString();
            txtSaldoActual.Text = cuenta.ObtenerSaldoCajaPesos().ToString();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtSaldoActual.Text = cuenta.ObtenerSaldoCajaPesos().ToString();
           
        }

        private void btnHistorialOperaciones_Click(object sender, EventArgs e)
        {
            
            dtg_operaciones.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            operaciones.Columns.Add("Tipo Operacion");
            operaciones.Columns.Add("Saldo Anterior");
            operaciones.Columns.Add("Monto Operacion");
            operaciones.Columns.Add("Saldo Posterior");
            operaciones.Columns.Add("Fecha Operacion");
            dtg_operaciones.DataSource = operaciones;
        }
    }
}
