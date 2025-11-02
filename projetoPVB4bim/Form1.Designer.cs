
namespace projetoPVB4bim
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonInserir = new System.Windows.Forms.Button();
            this.textBoxPeso = new System.Windows.Forms.TextBox();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.listBoxID = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.buttonAlterar = new System.Windows.Forms.Button();
            this.textBoxAltura = new System.Windows.Forms.TextBox();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.buttonExcluir = new System.Windows.Forms.Button();
            this.buttonHtml = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxDados = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonInserir
            // 
            this.buttonInserir.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInserir.Location = new System.Drawing.Point(236, 496);
            this.buttonInserir.Name = "buttonInserir";
            this.buttonInserir.Size = new System.Drawing.Size(139, 41);
            this.buttonInserir.TabIndex = 0;
            this.buttonInserir.Text = "Inserir";
            this.buttonInserir.UseVisualStyleBackColor = true;
            this.buttonInserir.Click += new System.EventHandler(this.buttonInserir_Click);
            // 
            // textBoxPeso
            // 
            this.textBoxPeso.Location = new System.Drawing.Point(427, 340);
            this.textBoxPeso.Name = "textBoxPeso";
            this.textBoxPeso.Size = new System.Drawing.Size(139, 22);
            this.textBoxPeso.TabIndex = 1;
            this.textBoxPeso.TextChanged += new System.EventHandler(this.textBoxPeso_TextChanged);
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBuscar.Location = new System.Drawing.Point(52, 496);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(139, 41);
            this.buttonBuscar.TabIndex = 2;
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // listBoxID
            // 
            this.listBoxID.FormattingEnabled = true;
            this.listBoxID.ItemHeight = 16;
            this.listBoxID.Location = new System.Drawing.Point(52, 180);
            this.listBoxID.Name = "listBoxID";
            this.listBoxID.Size = new System.Drawing.Size(140, 212);
            this.listBoxID.TabIndex = 3;
            this.listBoxID.SelectedIndexChanged += new System.EventHandler(this.listBoxID_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // buttonAlterar
            // 
            this.buttonAlterar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAlterar.Location = new System.Drawing.Point(427, 496);
            this.buttonAlterar.Name = "buttonAlterar";
            this.buttonAlterar.Size = new System.Drawing.Size(139, 41);
            this.buttonAlterar.TabIndex = 5;
            this.buttonAlterar.Text = "Alterar";
            this.buttonAlterar.UseVisualStyleBackColor = true;
            this.buttonAlterar.Click += new System.EventHandler(this.buttonAlterar_Click);
            // 
            // textBoxAltura
            // 
            this.textBoxAltura.Location = new System.Drawing.Point(427, 258);
            this.textBoxAltura.Name = "textBoxAltura";
            this.textBoxAltura.Size = new System.Drawing.Size(139, 22);
            this.textBoxAltura.TabIndex = 6;
            this.textBoxAltura.TextChanged += new System.EventHandler(this.textBoxAltura_TextChanged);
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(427, 180);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(139, 22);
            this.textBoxNome.TabIndex = 7;
            this.textBoxNome.TextChanged += new System.EventHandler(this.textBoxNome_TextChanged);
            // 
            // buttonExcluir
            // 
            this.buttonExcluir.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExcluir.Location = new System.Drawing.Point(621, 496);
            this.buttonExcluir.Name = "buttonExcluir";
            this.buttonExcluir.Size = new System.Drawing.Size(139, 41);
            this.buttonExcluir.TabIndex = 9;
            this.buttonExcluir.Text = "Excluir";
            this.buttonExcluir.UseVisualStyleBackColor = true;
            this.buttonExcluir.Click += new System.EventHandler(this.buttonExcluir_Click);
            // 
            // buttonHtml
            // 
            this.buttonHtml.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHtml.Location = new System.Drawing.Point(799, 496);
            this.buttonHtml.Name = "buttonHtml";
            this.buttonHtml.Size = new System.Drawing.Size(139, 41);
            this.buttonHtml.TabIndex = 10;
            this.buttonHtml.Text = "Gerar HTML";
            this.buttonHtml.UseVisualStyleBackColor = true;
            this.buttonHtml.Click += new System.EventHandler(this.buttonHtml_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(470, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 23);
            this.label1.TabIndex = 11;
            this.label1.Text = "Nome:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(470, 314);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 23);
            this.label2.TabIndex = 12;
            this.label2.Text = "Peso:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(470, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 23);
            this.label3.TabIndex = 13;
            this.label3.Text = "Altura:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 15F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(694, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(230, 28);
            this.label4.TabIndex = 14;
            this.label4.Text = "Dados do paciente:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 25.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(146, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(693, 49);
            this.label5.TabIndex = 15;
            this.label5.Text = "SISTEMA DE CONTROLE DE IMC";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(12, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(234, 28);
            this.label7.TabIndex = 17;
            this.label7.Text = "Lista de Pacientes: ";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // textBoxDados
            // 
            this.textBoxDados.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDados.Location = new System.Drawing.Point(699, 196);
            this.textBoxDados.Multiline = true;
            this.textBoxDados.Name = "textBoxDados";
            this.textBoxDados.ReadOnly = true;
            this.textBoxDados.Size = new System.Drawing.Size(225, 113);
            this.textBoxDados.TabIndex = 18;
            this.textBoxDados.TextChanged += new System.EventHandler(this.textBoxDados_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(990, 572);
            this.Controls.Add(this.textBoxDados);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonHtml);
            this.Controls.Add(this.buttonExcluir);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.textBoxAltura);
            this.Controls.Add(this.buttonAlterar);
            this.Controls.Add(this.listBoxID);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.textBoxPeso);
            this.Controls.Add(this.buttonInserir);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonInserir;
        private System.Windows.Forms.TextBox textBoxPeso;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.ListBox listBoxID;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button buttonAlterar;
        private System.Windows.Forms.TextBox textBoxAltura;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.Button buttonExcluir;
        private System.Windows.Forms.Button buttonHtml;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxDados;
    }
}

