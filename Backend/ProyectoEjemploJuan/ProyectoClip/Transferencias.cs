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
    public partial class Transferencias : Form
    {
        private static Moneda pesos = new Moneda("Pesos Argentinos", 1);
        private static DateTime fechaAlta = new DateTime(2020, 10, 25);
        private static Caja cajaEnPesos = new Caja(pesos, 2000, 152);
        private static Caja[] cajas = { cajaEnPesos };
        private static EstadoCuenta activa = new EstadoCuenta();
        private static Cuenta cuentaOrigen = new Cuenta(156808253, fechaAlta, activa, cajas);
        private static TipoDocumento tipoDoc = new TipoDocumento("DNI", "Documento Nacional de Identidad");
        private static Cliente clienteNuevo = new Cliente("Juan", "Cuello", tipoDoc, "jcuello@gmail.com", cuentaOrigen, "Habilitado");
        DataTable tablaTransferencia = new DataTable();

        private static DateTime fechaAltaDestino = new DateTime(2020, 10, 15);
        private static Caja cajaEnPesosDestino = new Caja(pesos, 3000, 135);
        private static Caja[] cajasDestino = { cajaEnPesosDestino };
        private static Cuenta cuentaDestino = new Cuenta(156044767, fechaAltaDestino, activa, cajasDestino);
        private static Cliente cliente = new Cliente("Juan", "Gomez", tipoDoc, "jcuello777@gmail.com", cuentaDestino, "Habilitado");
    

        public Transferencias()
        {
            InitializeComponent();
        }

        private void btnTransferir_Click(object sender, EventArgs e)
        {
            double monto = double.Parse(MontoATrasnferir.Text);
            if (monto > cuentaOrigen.ObtenerSaldoCajaPesos())
            {
                MessageBox.Show(" No tiene el saldo suficiente para realizar esta transferencia ");
            }
            else
            {
                Transferencia nuevaTransferencia = new Transferencia(cuentaOrigen, cuentaDestino, monto, pesos);
                nuevaTransferencia.transferir();
                MessageBox.Show("Transferencia Realizada Correctamente");
                tablaTransferencia.Rows.Add(cliente.Nombre + " " + cliente.Apellido, cliente.ObtenerNumeroCuenta(), monto, nuevaTransferencia.FechaOperacion, cuentaOrigen.ObtenerSaldoCajaPesos());
            }
            

        }

        private void RegistroParaPrueba_Load(object sender, EventArgs e)
        {
            this.txtSaldo.Text = cuentaOrigen.ObtenerSaldoCajaPesos().ToString();
            this.nombreCliente.Text = clienteNuevo.Nombre +" " + clienteNuevo.Apellido;
            this.txtNumeroCuenta.Text = clienteNuevo.ObtenerNumeroCuenta().ToString();
            this.txtNumeroCaja.Text = cuentaOrigen.ObtenerNumeroCajaPesos().ToString();
            this.txtMoneda.Text = pesos.NombreMoneda;

            this.txtNombreDestino.Text = cliente.Nombre + " " + cliente.Apellido;
            this.txtNroCuenta.Text = cliente.ObtenerNumeroCuenta().ToString();
            this.txtNroCaja.Text = cuentaDestino.ObtenerNumeroCajaPesos().ToString();
            this.txtMonedaD.Text = pesos.NombreMoneda;

            tablaTransferencia.Columns.Add("Nombre Destino");
            tablaTransferencia.Columns.Add("Cuenta Destino");
            tablaTransferencia.Columns.Add("Monto Transferido");
            tablaTransferencia.Columns.Add("Fecha");
            tablaTransferencia.Columns.Add("Saldo Pos Transferencia");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataTransferencias.DataSource = tablaTransferencia;
        }
    }
}
