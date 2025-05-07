using Bombones2025.Entidades.Entidades;
using Bombones2025.Servicios.Servicios;
using Bombones2025.Windows.Helpers;

namespace Bombones2025.Windows
{
    public partial class FrmChocolates : Form
    {
        private readonly ChocolateServicio _servicio = null!;
        private List<Chocolate> lista = null!;
        public FrmChocolates(ChocolateServicio servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private void FrmChocolates_Load(object sender, EventArgs e)
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
            GridHelper.LimpiarGrilla(dgvDatos);
            foreach (Chocolate chocolate in lista)
            {
                var r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, chocolate);
                GridHelper.AgregarFila(r,dgvDatos);
            }
        }



        private void TsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TsbNuevo_Click(object sender, EventArgs e)
        {
            FrmChocolatesAE frm = new FrmChocolatesAE() { Text = "Agregar Chocolate" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            Chocolate? chocolate = frm.GetChocolate();
            if (chocolate is null) return;
            try
            {
                if (!_servicio.Existe(chocolate))
                {
                    _servicio.Guardar(chocolate);
                    DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                    GridHelper.SetearFila(r, chocolate);
                    GridHelper.AgregarFila(r,dgvDatos);
                    MessageBox.Show("Registro Agregado", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Registro Duplicado", "Error",
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
            Chocolate? chocolate = r.Tag as Chocolate;
            if (chocolate is null) return;
            DialogResult dr = MessageBox.Show($"¿Desea borrar el registro de {chocolate}?",
                "Confirmar Baja",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;
            try
            {
                _servicio.Borrar(chocolate.ChocolateId);
                GridHelper.QuitarFila(r, dgvDatos);
                MessageBox.Show("Registro Eliminado", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            Chocolate? chocolate = r.Tag as Chocolate;
            if (chocolate is null) return;
            Chocolate? chocoEditar = chocolate.Clonar();
            FrmChocolatesAE frm = new FrmChocolatesAE() { Text = "Editar Chocolate" };
            frm.SetChocolate(chocoEditar);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            chocoEditar = frm.GetChocolate();
            if (chocoEditar is null) return;
            try
            {
                if (!_servicio.Existe(chocoEditar))
                {
                    _servicio.Guardar(chocoEditar);
                    GridHelper.SetearFila(r, chocoEditar);
                    MessageBox.Show("Registro Editado", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Registro Duplicado", "Error",
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
