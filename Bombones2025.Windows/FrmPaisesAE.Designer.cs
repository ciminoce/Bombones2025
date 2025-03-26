namespace Bombones2025.Windows
{
    partial class FrmPaisesAE
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
            label1 = new Label();
            TxtPais = new TextBox();
            errorProvider1 = new ErrorProvider(components);
            BtnOK = new Button();
            BtnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 43);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 0;
            label1.Text = "País:";
            // 
            // TxtPais
            // 
            TxtPais.Location = new Point(78, 40);
            TxtPais.MaxLength = 200;
            TxtPais.Name = "TxtPais";
            TxtPais.Size = new Size(377, 23);
            TxtPais.TabIndex = 1;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // BtnOK
            // 
            BtnOK.Location = new Point(58, 135);
            BtnOK.Name = "BtnOK";
            BtnOK.Size = new Size(75, 52);
            BtnOK.TabIndex = 2;
            BtnOK.Text = "OK";
            BtnOK.UseVisualStyleBackColor = true;
            BtnOK.Click += BtnOK_Click;
            // 
            // BtnCancelar
            // 
            BtnCancelar.Location = new Point(380, 135);
            BtnCancelar.Name = "BtnCancelar";
            BtnCancelar.Size = new Size(75, 52);
            BtnCancelar.TabIndex = 2;
            BtnCancelar.Text = "Cancelar";
            BtnCancelar.UseVisualStyleBackColor = true;
            BtnCancelar.Click += BtnCancelar_Click;
            // 
            // FrmPaisesAE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(532, 210);
            Controls.Add(BtnCancelar);
            Controls.Add(BtnOK);
            Controls.Add(TxtPais);
            Controls.Add(label1);
            Name = "FrmPaisesAE";
            Text = "FrmPaisesAE";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox TxtPais;
        private ErrorProvider errorProvider1;
        private Button BtnCancelar;
        private Button BtnOK;
    }
}