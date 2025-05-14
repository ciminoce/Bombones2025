using Bombones2025.Entidades.Entidades;
using Bombones2025.Servicios.Servicios;

namespace Bombones2025.Windows
{
    public partial class FrmPrincipal : Form
    {
        private Usuario usuario=null!;
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void BtnPaises_Click(object sender, EventArgs e)
        {
            try
            {
                PaisServicio servicio = new PaisServicio();
                FrmPaises frm = new FrmPaises(servicio) { Text = "Listado de Paises" };
                frm.ShowDialog(this);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BtnFrutosSecos_Click(object sender, EventArgs e)
        {
            try
            {
                FrutoSecoServicio servicio = new FrutoSecoServicio();
                FrmFrutosSecos frm = new FrmFrutosSecos(servicio) { Text = "Listado de Frutos Secos" };
                frm.ShowDialog(this);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void BtnRellenos_Click(object sender, EventArgs e)
        {
            try
            {
                RellenoServicio servicio = new RellenoServicio();
                FrmRellenos frm = new FrmRellenos(servicio) { Text = "Listado de Rellenos" };
                frm.ShowDialog(this);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void BtnChocolates_Click(object sender, EventArgs e)
        {
            try
            {
                ChocolateServicio servicio = new ChocolateServicio();
                FrmChocolates frm = new FrmChocolates(servicio) { Text = "Listado de Chocolates" };
                frm.ShowDialog(this);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        public void SetUsuario(Usuario usuarioLogueado)
        {
            LblUsuario.Text = usuarioLogueado.Nombre;
        }
    }
}
