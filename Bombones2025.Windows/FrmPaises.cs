using Bombones2025.Entidades;
using Bombones2025.Servicios;

namespace Bombones2025.Windows
{
    public partial class FrmPaises : Form
    {
        private readonly PaisServicio _paisServicio;

        private List<Pais> _paises = new();
        public FrmPaises(PaisServicio paisServicio)
        {
            InitializeComponent();
            _paisServicio = paisServicio;
        }

        private void FrmPaises_Load(object sender, EventArgs e)
        {
            _paises = _paisServicio.GetPaises();
            MostrarDatosEnGrilla();
        }

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (Pais pais in _paises)
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgvDatos);
                SetearFila(r, pais);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Pais pais)
        {
            r.Cells[0].Value = pais.PaisId;
            r.Cells[1].Value = pais.NombrePais;

            r.Tag = pais;
        }

        private void TsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TsbNuevo_Click(object sender, EventArgs e)
        {
            FrmPaisesAE frm = new FrmPaisesAE() { Text = "Nuevo País" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            Pais? pais = frm.GetPais();
            if (pais == null) return;
            if (!_paisServicio.Existe(pais))
            {
                _paisServicio.Guardar(pais);
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgvDatos);
                SetearFila(r, pais);
                AgregarFila(r);
                MessageBox.Show("Pais agregado", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Pais existente", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void TsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            Pais paisBorrar = (Pais)r.Tag!;
            DialogResult dr = MessageBox.Show($"¿Desea borrar el pais {paisBorrar}?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;
            _paisServicio.Borrar(paisBorrar);
            dgvDatos.Rows.Remove(r);
            MessageBox.Show("País eliminado");
        }

        private void TsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            Pais? pais = (Pais)r.Tag!;
            FrmPaisesAE frm = new FrmPaisesAE() { Text = "Editar País" };
            frm.SetPais(pais);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            pais = frm.GetPais();
            if (pais == null) return;
            if (!_paisServicio.Existe(pais))
            {
                _paisServicio.Guardar(pais);
                SetearFila(r, pais);

                MessageBox.Show("Pais editado", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Pais existente", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
