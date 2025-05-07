using Bombones2025.Entidades.Entidades;
using Bombones2025.Servicios.Servicios;
using Bombones2025.Windows.Helpers;
using Bombones2025.Windows.Properties;

namespace Bombones2025.Windows
{
    public partial class FrmPaises : Form
    {
        private readonly PaisServicio _paisServicio;

        private List<Pais> _paises = new();

        private bool filterOn = false;
        public FrmPaises(PaisServicio paisServicio)
        {
            InitializeComponent();
            _paisServicio = paisServicio;
        }

        private void FrmPaises_Load(object sender, EventArgs e)
        {
            try
            {
                _paises = _paisServicio.GetLista();
                MostrarDatosEnGrilla();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            foreach (Pais pais in _paises)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, pais);
                GridHelper.AgregarFila(r, dgvDatos);
            }
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
            try
            {
                if (!_paisServicio.Existe(pais))
                {
                    _paisServicio.Guardar(pais);
                    DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                    GridHelper.SetearFila(r, pais);
                    GridHelper.AgregarFila(r,dgvDatos);
                    MessageBox.Show("Pais agregado", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Pais existente", "Error",
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
            try
            {
                _paisServicio.Borrar(paisBorrar.PaisId);
                GridHelper.QuitarFila(r, dgvDatos);
                MessageBox.Show("País eliminado");

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void TsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            Pais? pais = (Pais)r.Tag!;
            if (pais == null) return;
            Pais? paisEditar = pais.Clonar();
            FrmPaisesAE frm = new FrmPaisesAE() { Text = "Editar País" };
            frm.SetPais(paisEditar);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            paisEditar = frm.GetPais();
            if (paisEditar == null) return;
            try
            {
                if (!_paisServicio.Existe(paisEditar))
                {
                    _paisServicio.Guardar(paisEditar);
                    GridHelper.SetearFila(r, paisEditar);

                    MessageBox.Show("Pais editado", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Pais existente", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void TsbFiltrar_Click(object sender, EventArgs e)
        {
            if (!filterOn)
            {
                FrmFiltro frm = new FrmFiltro() { Text = "Filtrar Paises" };
                DialogResult dr = frm.ShowDialog(this);
                string? textoParaFiltrar = frm.GetTexto();
                if (textoParaFiltrar is null) return;
                try
                {
                    _paises = _paisServicio.Filtrar(textoParaFiltrar);
                    MostrarDatosEnGrilla();
                    TsbFiltrar.Image = Resources.filter_intense_40px;
                    filterOn = true;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Quitar el filtro!!!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TsbActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                filterOn = false;
                TsbFiltrar.Image = Resources.filter_40px;
                _paises = _paisServicio.GetLista();
                MostrarDatosEnGrilla();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
