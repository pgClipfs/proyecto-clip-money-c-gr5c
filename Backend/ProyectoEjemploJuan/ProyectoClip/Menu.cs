using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProyectoClip
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void AbrirTransferencia_Click(object sender, EventArgs e)
        {
            Transferencias formTrans = new Transferencias();
            formTrans.Show();
        }

        private void AbrirExtDep_Click(object sender, EventArgs e)
        {
            Form1 ExtrDepVista = new Form1();
            ExtrDepVista.Show();
        }
    }
}
