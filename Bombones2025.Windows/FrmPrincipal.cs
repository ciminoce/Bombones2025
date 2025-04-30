using Bombones2025.Servicios.Servicios;

namespace Bombones2025.Windows
{
    public partial class FrmPrincipal : Form
    {
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
    }
}
