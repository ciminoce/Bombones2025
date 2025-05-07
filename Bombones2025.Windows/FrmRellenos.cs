using Bombones2025.Entidades.Entidades;
using Bombones2025.Servicios.Servicios;

namespace Bombones2025.Windows
{
    public partial class FrmRellenos : Form
    {
        private readonly RellenoServicio _servicio = null!;
        private List<Relleno> lista = null!;
       public FrmRellenos(RellenoServicio servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private void FrmRellenos_Load(object sender, EventArgs e)
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
            foreach (Relleno relleno in lista)
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgvDatos);
                SetearFila(r, relleno);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Relleno relleno)
        {
            r.Cells[0].Value = relleno.RellenoId;
            r.Cells[1].Value = relleno.Descripcion;

            r.Tag = relleno;
        }

        private void TsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TsbNuevo_Click(object sender, EventArgs e)
        {
            FrmRellenosAE frm = new FrmRellenosAE() { Text = "Agregar Relleno" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            Relleno? relleno = frm.GetRelleno();
            if (relleno is null) return;
            try
            {
                if (!_servicio.Existe(relleno))
                {
                    _servicio.Guardar(relleno);
                    DataGridViewRow r = ConstuirFila();
                    SetearFila(r, relleno);
                    AgregarFila(r);
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

        private DataGridViewRow ConstuirFila()
        {
            var r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void TsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0) return;
            DataGridViewRow r = dgvDatos.SelectedRows[0];
            Relleno? relleno = r.Tag as Relleno;
            if (relleno is null) return;
            DialogResult dr = MessageBox.Show($"¿Desea borrar el registro de {relleno}?",
                "Confirmar Baja",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;
            try
            {
                _servicio.Borrar(relleno.RellenoId);
                QuitarFila(r);
                MessageBox.Show("Registro Eliminado", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void QuitarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Remove(r);
        }

        private void TsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0) return;
            DataGridViewRow r = dgvDatos.SelectedRows[0];
            Relleno? relleno = r.Tag as Relleno;
            if (relleno is null) return;
            Relleno? rellenoEditar = relleno.Clonar();
            FrmRellenosAE frm = new FrmRellenosAE() { Text = "Editar Relleno" };
            frm.SetRelleno(rellenoEditar);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            rellenoEditar = frm.GetRelleno();
            if (rellenoEditar is null) return;
            try
            {
                if (!_servicio.Existe(rellenoEditar))
                {
                    _servicio.Guardar(rellenoEditar);
                    SetearFila(r, rellenoEditar);
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
