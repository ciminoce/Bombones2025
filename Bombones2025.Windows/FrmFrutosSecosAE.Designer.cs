namespace Bombones2025.Windows
{
    partial class FrmFrutosSecosAE
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            BtnCancelar = new Button();
            BtnOK = new Button();
            TxtFrutoSeco = new TextBox();
            label1 = new Label();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // BtnCancelar
            // 
            BtnCancelar.Image = Properties.Resources.Cancelar;
            BtnCancelar.Location = new Point(383, 63);
            BtnCancelar.Name = "BtnCancelar";
            BtnCancelar.Size = new Size(75, 52);
            BtnCancelar.TabIndex = 5;
            BtnCancelar.Text = "Cancelar";
            BtnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnCancelar.UseVisualStyleBackColor = true;
            BtnCancelar.Click += BtnCancelar_Click;
            // 
            // BtnOK
            // 
            BtnOK.Image = Properties.Resources.Aceptar1;
            BtnOK.Location = new Point(44, 63);
            BtnOK.Name = "BtnOK";
            BtnOK.Size = new Size(75, 52);
            BtnOK.TabIndex = 6;
            BtnOK.Text = "OK";
            BtnOK.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnOK.UseVisualStyleBackColor = true;
            BtnOK.Click += BtnOK_Click;
            // 
            // TxtFrutoSeco
            // 
            TxtFrutoSeco.Location = new Point(116, 18);
            TxtFrutoSeco.MaxLength = 100;
            TxtFrutoSeco.Name = "TxtFrutoSeco";
            TxtFrutoSeco.Size = new Size(342, 23);
            TxtFrutoSeco.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 21);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 3;
            label1.Text = "Fruto Seco:";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FrmFrutosSecosAE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(495, 164);
            Controls.Add(BtnCancelar);
            Controls.Add(BtnOK);
            Controls.Add(TxtFrutoSeco);
            Controls.Add(label1);
            MaximumSize = new Size(511, 203);
            MinimumSize = new Size(511, 203);
            Name = "FrmFrutosSecosAE";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmFrutosSecosAE";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnCancelar;
        private Button BtnOK;
        private TextBox TxtFrutoSeco;
        private Label label1;
        private ErrorProvider errorProvider1;
    }
}