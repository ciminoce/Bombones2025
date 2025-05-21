using Bombones2025.Entidades.Entidades;

namespace Bombones2025.Windows
{
    public partial class FrmFrutosSecosAE : Form
    {
        private FrutoSeco? fruto;
        public FrmFrutosSecosAE()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (fruto is not null)
            {
                TxtFrutoSeco.Text = fruto.Descripcion;
            }
        }
        public FrutoSeco? GetFrutoSeco()
        {
            return fruto;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (fruto is null)
                {
                    fruto = new FrutoSeco();
                }
                fruto.Descripcion = TxtFrutoSeco.Text.Trim();
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(TxtFrutoSeco.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(TxtFrutoSeco, "La descripción es requerida");
            }
            return valido;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public void SetFruto(FrutoSeco fs)
        {
            fruto = fs;
        }
    }
}
