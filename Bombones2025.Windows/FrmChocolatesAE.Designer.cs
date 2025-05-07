namespace Bombones2025.Windows
{
    partial class FrmChocolatesAE
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
            TxtChocolate = new TextBox();
            label1 = new Label();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // BtnCancelar
            // 
            BtnCancelar.Image = Properties.Resources.Cancelar;
            BtnCancelar.Location = new Point(387, 95);
            BtnCancelar.Name = "BtnCancelar";
            BtnCancelar.Size = new Size(75, 52);
            BtnCancelar.TabIndex = 9;
            BtnCancelar.Text = "Cancelar";
            BtnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnCancelar.UseVisualStyleBackColor = true;
            BtnCancelar.Click += BtnCancelar_Click;
            // 
            // BtnOK
            // 
            BtnOK.Image = Properties.Resources.Aceptar1;
            BtnOK.Location = new Point(48, 95);
            BtnOK.Name = "BtnOK";
            BtnOK.Size = new Size(75, 52);
            BtnOK.TabIndex = 10;
            BtnOK.Text = "OK";
            BtnOK.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnOK.UseVisualStyleBackColor = true;
            BtnOK.Click += BtnOK_Click;
            // 
            // TxtChocolate
            // 
            TxtChocolate.Location = new Point(120, 50);
            TxtChocolate.MaxLength = 100;
            TxtChocolate.Name = "TxtChocolate";
            TxtChocolate.Size = new Size(342, 23);
            TxtChocolate.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(48, 53);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 7;
            label1.Text = "Chocolate:";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FrmChocolatesAE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(508, 180);
            Controls.Add(BtnCancelar);
            Controls.Add(BtnOK);
            Controls.Add(TxtChocolate);
            Controls.Add(label1);
            MaximumSize = new Size(524, 219);
            MinimumSize = new Size(524, 219);
            Name = "FrmChocolatesAE";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmChocolateAE";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnCancelar;
        private Button BtnOK;
        private TextBox TxtChocolate;
        private Label label1;
        private ErrorProvider errorProvider1;
    }
}