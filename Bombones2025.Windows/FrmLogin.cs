using Bombones2025.Entidades.Entidades;
using Bombones2025.Servicios.Interfaces;
using Bombones2025.Windows.Helpers;

namespace Bombones2025.Windows
{
    public partial class FrmLogin : Form
    {
        private Usuario? usuarioLogueado;
        private readonly IUsuarioServicio? _usuarioServicio;
        public FrmLogin(IUsuarioServicio? usuarioServicio)
        {
            InitializeComponent();
            _usuarioServicio = usuarioServicio;
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
