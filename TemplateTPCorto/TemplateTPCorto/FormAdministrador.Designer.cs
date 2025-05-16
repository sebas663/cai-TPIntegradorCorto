namespace TemplateTPCorto
{
    partial class FormAdministrador
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
            this.btnAutorizaciones = new System.Windows.Forms.Button();
            this.btnCerrarSession = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tablacontraseñas = new System.Windows.Forms.DataGridView();
            this.tablausuarios = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tablacontraseñas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablausuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAutorizaciones
            // 
            this.btnAutorizaciones.Location = new System.Drawing.Point(187, 241);
            this.btnAutorizaciones.Name = "btnAutorizaciones";
            this.btnAutorizaciones.Size = new System.Drawing.Size(381, 25);
            this.btnAutorizaciones.TabIndex = 4;
            this.btnAutorizaciones.Text = "Autorizar";
            this.btnAutorizaciones.UseVisualStyleBackColor = true;
            this.btnAutorizaciones.Click += new System.EventHandler(this.btnAutorizaciones_Click);
            // 
            // btnCerrarSession
            // 
            this.btnCerrarSession.Location = new System.Drawing.Point(618, 12);
            this.btnCerrarSession.Name = "btnCerrarSession";
            this.btnCerrarSession.Size = new System.Drawing.Size(170, 25);
            this.btnCerrarSession.TabIndex = 5;
            this.btnCerrarSession.Text = "Cerrar session";
            this.btnCerrarSession.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Autorizar cambio constraseña";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(470, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Autorizar modificacion de datos del usuario";
            // 
            // tablacontraseñas
            // 
            this.tablacontraseñas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablacontraseñas.Location = new System.Drawing.Point(12, 94);
            this.tablacontraseñas.Name = "tablacontraseñas";
            this.tablacontraseñas.Size = new System.Drawing.Size(347, 117);
            this.tablacontraseñas.TabIndex = 10;
            this.tablacontraseñas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // tablausuarios
            // 
            this.tablausuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablausuarios.Location = new System.Drawing.Point(395, 94);
            this.tablausuarios.Name = "tablausuarios";
            this.tablausuarios.Size = new System.Drawing.Size(381, 117);
            this.tablausuarios.TabIndex = 11;
            this.tablausuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 217);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 21);
            this.button1.TabIndex = 12;
            this.button1.Text = "Limpiar seleccion";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(676, 219);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 19);
            this.button2.TabIndex = 13;
            this.button2.Text = "Limpiar seleccion";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tablausuarios);
            this.Controls.Add(this.tablacontraseñas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCerrarSession);
            this.Controls.Add(this.btnAutorizaciones);
            this.Name = "FormAdministrador";
            this.Text = "FormAdministrador";
            ((System.ComponentModel.ISupportInitialize)(this.tablacontraseñas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablausuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAutorizaciones;
        private System.Windows.Forms.Button btnCerrarSession;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView tablacontraseñas;
        private System.Windows.Forms.DataGridView tablausuarios;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}