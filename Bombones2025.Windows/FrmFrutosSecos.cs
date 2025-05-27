using Bombones2025.Entidades.Entidades;
using Bombones2025.Servicios.Interfaces;
using Bombones2025.Windows.Helpers;

namespace Bombones2025.Windows
{
    public partial class FrmFrutosSecos : Form
    {
        private readonly IFrutoSecoServicio _servicio = null!;
        private List<FrutoSeco> lista = null!;
        public FrmFrutosSecos(IFrutoSecoServicio servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private void FrmFrutosSecos_Load(object sender, EventArgs e)
        {
            try
            {
                lista = _servicio.GetLista();
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (FrutoSeco fs in lista)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);

                GridHelper.SetearFila(r, fs);
                GridHelper.AgregarFila(r,dgvDatos);
            }
        }

        private void TsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TsbNuevo_Click(object sender, EventArgs e)
        {
            FrmFrutosSecosAE frm = new FrmFrutosSecosAE() { Text = "Agregar Fruto Seco" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            FrutoSeco? fruto = frm.GetFrutoSeco();
            if (fruto is null) return;
            try
            {
                if(_servicio.Agregar(fruto, out var errores))
                {
                    DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                    GridHelper.SetearFila(r, fruto);
                    GridHelper.AgregarFila(r,dgvDatos);
                    MessageBox.Show("Registro Agregado", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                else
                {
                    MessageBox.Show(errores.First(), "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void TsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0) return;
            DataGridViewRow r = dgvDatos.SelectedRows[0];
            FrutoSeco? fs = r.Tag as FrutoSeco;
            if (fs is null) return;
            DialogResult dr = MessageBox.Show($"¿Desea borrar el registro de {fs}?",
                "Confirmar Baja",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;
            try
            {
                if(_servicio.Borrar(fs.FrutoSecoId, out var errores))
                {
                    GridHelper.QuitarFila(r,dgvDatos);
                    MessageBox.Show("Registro Eliminado", "Información",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show(errores.First(), "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void TsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0) return;
            DataGridViewRow r = dgvDatos.SelectedRows[0];
            FrutoSeco? fs = r.Tag as FrutoSeco;
            if (fs is null) return;
            FrutoSeco? fsEditar = fs.Clonar();
            FrmFrutosSecosAE frm = new FrmFrutosSecosAE() { Text = "Editar Fruto Seco" };
            frm.SetFruto(fsEditar);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            fsEditar = frm.GetFrutoSeco();
            if (fsEditar is null) return;
            try
            {
                if (_servicio.Editar(fsEditar, out var errores))
                {
                    GridHelper.SetearFila(r, fsEditar);
                    MessageBox.Show("Registro Editado", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show(errores.First(), "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
