namespace TemplateTPCorto
{
    partial class FormCambioContraseña
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtNuevaContrasena = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtConfirmarContrasena = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(165, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nueva Contraseña";
            // 
            // txtNuevaContrasena
            // 
            this.txtNuevaContrasena.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtNuevaContrasena.Location = new System.Drawing.Point(130, 81);
            this.txtNuevaContrasena.Name = "txtNuevaContrasena";
            this.txtNuevaContrasena.Size = new System.Drawing.Size(173, 22);
            this.txtNuevaContrasena.TabIndex = 1;
            this.txtNuevaContrasena.TextChanged += new System.EventHandler(this.txtNuevaContrasena_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(148, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Confirmar Contraseña";
            // 
            // txtConfirmarContrasena
            // 
            this.txtConfirmarContrasena.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtConfirmarContrasena.Location = new System.Drawing.Point(130, 151);
            this.txtConfirmarContrasena.Name = "txtConfirmarContrasena";
            this.txtConfirmarContrasena.Size = new System.Drawing.Size(173, 22);
            this.txtConfirmarContrasena.TabIndex = 3;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(184, 205);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // 
            // FormCambioContraseña
            // 
            this.ClientSize = new System.Drawing.Size(470, 356);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtConfirmarContrasena);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNuevaContrasena);
            this.Controls.Add(this.label3);
            this.Name = "FormCambioContraseña";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNuevaContrasena;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtConfirmarContrasena;
        private System.Windows.Forms.Button btnGuardar;
    }
}