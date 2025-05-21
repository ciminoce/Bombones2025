using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bombones2025.Windows
{
    public partial class FrmFiltro : Form
    {
        private string? textoFiltro;
        public FrmFiltro()
        {
            InitializeComponent();
        }

        public string? GetTexto()
        {
            return textoFiltro;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                textoFiltro = TxtTextoFiltro.Text.Trim();
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(TxtTextoFiltro.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(TxtTextoFiltro, "Debe ingresar un texto para filtrar");
            }
            return valido;
        }
    }
}
