namespace Bombones2025.Windows
{
    partial class FrmPrincipal
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
            BtnPaises = new Button();
            BtnFrutosSecos = new Button();
            BtnRellenos = new Button();
            BtnChocolates = new Button();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            LblUsuario = new ToolStripStatusLabel();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // BtnPaises
            // 
            BtnPaises.Location = new Point(40, 46);
            BtnPaises.Name = "BtnPaises";
            BtnPaises.Size = new Size(87, 54);
            BtnPaises.TabIndex = 0;
            BtnPaises.Text = "Países";
            BtnPaises.UseVisualStyleBackColor = true;
            BtnPaises.Click += BtnPaises_Click;
            // 
            // BtnFrutosSecos
            // 
            BtnFrutosSecos.Location = new Point(153, 46);
            BtnFrutosSecos.Name = "BtnFrutosSecos";
            BtnFrutosSecos.Size = new Size(87, 54);
            BtnFrutosSecos.TabIndex = 0;
            BtnFrutosSecos.Text = "Frutos Secos";
            BtnFrutosSecos.UseVisualStyleBackColor = true;
            BtnFrutosSecos.Click += BtnFrutosSecos_Click;
            // 
            // BtnRellenos
            // 
            BtnRellenos.Location = new Point(265, 46);
            BtnRellenos.Name = "BtnRellenos";
            BtnRellenos.Size = new Size(87, 54);
            BtnRellenos.TabIndex = 0;
            BtnRellenos.Text = "Rellenos";
            BtnRellenos.UseVisualStyleBackColor = true;
            BtnRellenos.Click += BtnRellenos_Click;
            // 
            // BtnChocolates
            // 
            BtnChocolates.Location = new Point(380, 46);
            BtnChocolates.Name = "BtnChocolates";
            BtnChocolates.Size = new Size(87, 54);
            BtnChocolates.TabIndex = 0;
            BtnChocolates.Text = "Chocolates";
            BtnChocolates.UseVisualStyleBackColor = true;
            BtnChocolates.Click += BtnChocolates_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, LblUsuario });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(50, 17);
            toolStripStatusLabel1.Text = "Usuario:";
            // 
            // LblUsuario
            // 
            LblUsuario.Name = "LblUsuario";
            LblUsuario.Size = new Size(118, 17);
            LblUsuario.Text = "toolStripStatusLabel2";
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(statusStrip1);
            Controls.Add(BtnChocolates);
            Controls.Add(BtnRellenos);
            Controls.Add(BtnFrutosSecos);
            Controls.Add(BtnPaises);
            Name = "FrmPrincipal";
            Text = "FrmPrincipal";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnPaises;
        private Button BtnFrutosSecos;
        private Button BtnRellenos;
        private Button BtnChocolates;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel LblUsuario;
    }
}