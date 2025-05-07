using Bombones2025.Entidades.Entidades;

namespace Bombones2025.Windows
{
    public partial class FrmPaisesAE : Form
    {
        private Pais? pais;
        public FrmPaisesAE()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (pais is not null)
            {
                TxtPais.Text = pais.NombrePais;
            }
        }
        public Pais? GetPais()
        {
            return pais;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (pais is null)
                {
                    pais = new Pais();

                }  
                pais.NombrePais = TxtPais.Text;

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(TxtPais.Text))
            {
                valido = false;
                errorProvider1.SetError(TxtPais, "El nombre es requerido");

            }
            return valido;
        }

        public void SetPais(Pais pais)
        {
            this.pais = pais;
        }
    }
}
