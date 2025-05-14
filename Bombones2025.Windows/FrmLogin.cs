using Bombones2025.Entidades.Entidades;
using Bombones2025.Servicios.Servicios;
using Bombones2025.Windows.Helpers;
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
    public partial class FrmLogin : Form
    {
        private Usuario? usuarioLogueado;
        private readonly UsuarioServicio? _usuarioServicio;
        public FrmLogin(UsuarioServicio? usuarioServicio)
        {
            InitializeComponent();
            _usuarioServicio=usuarioServicio;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Salida del Sistema");
            Application.Exit();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                usuarioLogueado = _usuarioServicio!.Login(TxtUsuario.Text);
                if (usuarioLogueado is null)
                {
                    errorProvider1.SetError(TxtUsuario, "Usuario inexistente o clave errónea");
                    TxtUsuario.SelectAll();
                    return;
                }
                if (!SeguridadHelper.VerificarHash(TxtClave.Text, usuarioLogueado.ClaveHash))
                {
                    errorProvider1.SetError(TxtClave, "Clave errónea");
                    TxtClave.SelectAll();
                    return;

                }
                this.Hide();
                FrmPrincipal frm = new FrmPrincipal() { Text = "Menú Principal" };
                frm.SetUsuario(usuarioLogueado);
                frm.ShowDialog();
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            return valido;
        }
    }
}
