namespace TemplateTPCorto
{
    partial class FormContraseniaCambio
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
            this.btnCambioContrasenia = new System.Windows.Forms.Button();
            this.labelContraseniaNueva = new System.Windows.Forms.Label();
            this.labelContraseniaActual = new System.Windows.Forms.Label();
            this.txtContraseniaNueva = new System.Windows.Forms.TextBox();
            this.txtContraseniaActual = new System.Windows.Forms.TextBox();
            this.labelConfirmarContraseniaActual = new System.Windows.Forms.Label();
            this.txtConfirmarContraseniaNueva = new System.Windows.Forms.TextBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnCerrarSession = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCambioContrasenia
            // 
            this.btnCambioContrasenia.Location = new System.Drawing.Point(23, 178);
            this.btnCambioContrasenia.Margin = new System.Windows.Forms.Padding(2);
            this.btnCambioContrasenia.Name = "btnCambioContrasenia";
            this.btnCambioContrasenia.Size = new System.Drawing.Size(141, 19);
            this.btnCambioContrasenia.TabIndex = 9;
            this.btnCambioContrasenia.Text = "Cambiar contraseña";
            this.btnCambioContrasenia.UseVisualStyleBackColor = true;
            this.btnCambioContrasenia.Click += new System.EventHandler(this.btnCambioContrasenia_Click);
            // 
            // labelContraseniaNueva
            // 
            this.labelContraseniaNueva.AutoSize = true;
            this.labelContraseniaNueva.Location = new System.Drawing.Point(20, 60);
            this.labelContraseniaNueva.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelContraseniaNueva.Name = "labelContraseniaNueva";
            this.labelContraseniaNueva.Size = new System.Drawing.Size(94, 13);
            this.labelContraseniaNueva.TabIndex = 8;
            this.labelContraseniaNueva.Text = "Contraseña nueva";
            // 
            // labelContraseniaActual
            // 
            this.labelContraseniaActual.AutoSize = true;
            this.labelContraseniaActual.Location = new System.Drawing.Point(20, 18);
            this.labelContraseniaActual.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelContraseniaActual.Name = "labelContraseniaActual";
            this.labelContraseniaActual.Size = new System.Drawing.Size(93, 13);
            this.labelContraseniaActual.TabIndex = 7;
            this.labelContraseniaActual.Text = "Contraseña actual";
            // 
            // txtContraseniaNueva
            // 
            this.txtContraseniaNueva.Location = new System.Drawing.Point(198, 60);
            this.txtContraseniaNueva.Margin = new System.Windows.Forms.Padding(2);
            this.txtContraseniaNueva.Name = "txtContraseniaNueva";
            this.txtContraseniaNueva.Size = new System.Drawing.Size(144, 20);
            this.txtContraseniaNueva.TabIndex = 6;
            // 
            // txtContraseniaActual
            // 
            this.txtContraseniaActual.Location = new System.Drawing.Point(198, 15);
            this.txtContraseniaActual.Margin = new System.Windows.Forms.Padding(2);
            this.txtContraseniaActual.Name = "txtContraseniaActual";
            this.txtContraseniaActual.Size = new System.Drawing.Size(144, 20);
            this.txtContraseniaActual.TabIndex = 5;
            // 
            // labelConfirmarContraseniaActual
            // 
            this.labelConfirmarContraseniaActual.AutoSize = true;
            this.labelConfirmarContraseniaActual.Location = new System.Drawing.Point(20, 106);
            this.labelConfirmarContraseniaActual.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelConfirmarContraseniaActual.Name = "labelConfirmarContraseniaActual";
            this.labelConfirmarContraseniaActual.Size = new System.Drawing.Size(140, 13);
            this.labelConfirmarContraseniaActual.TabIndex = 11;
            this.labelConfirmarContraseniaActual.Text = "Confirmar contraseña nueva";
            // 
            // txtConfirmarContraseniaNueva
            // 
            this.txtConfirmarContraseniaNueva.Location = new System.Drawing.Point(198, 103);
            this.txtConfirmarContraseniaNueva.Margin = new System.Windows.Forms.Padding(2);
            this.txtConfirmarContraseniaNueva.Name = "txtConfirmarContraseniaNueva";
            this.txtConfirmarContraseniaNueva.Size = new System.Drawing.Size(144, 20);
            this.txtConfirmarContraseniaNueva.TabIndex = 10;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(567, 6);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(100, 25);
            this.btnVolver.TabIndex = 12;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnCerrarSession
            // 
            this.btnCerrarSession.Location = new System.Drawing.Point(685, 6);
            this.btnCerrarSession.Name = "btnCerrarSession";
            this.btnCerrarSession.Size = new System.Drawing.Size(100, 25);
            this.btnCerrarSession.TabIndex = 13;
            this.btnCerrarSession.Text = "Cerrar session";
            this.btnCerrarSession.UseVisualStyleBackColor = true;
            // 
            // FormContraseniaCambio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCerrarSession);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.labelConfirmarContraseniaActual);
            this.Controls.Add(this.txtConfirmarContraseniaNueva);
            this.Controls.Add(this.btnCambioContrasenia);
            this.Controls.Add(this.labelContraseniaNueva);
            this.Controls.Add(this.labelContraseniaActual);
            this.Controls.Add(this.txtContraseniaNueva);
            this.Controls.Add(this.txtContraseniaActual);
            this.Name = "FormContraseniaCambio";
            this.Text = "FormContraseniaCambio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCambioContrasenia;
        private System.Windows.Forms.Label labelContraseniaNueva;
        private System.Windows.Forms.Label labelContraseniaActual;
        private System.Windows.Forms.TextBox txtContraseniaNueva;
        private System.Windows.Forms.TextBox txtContraseniaActual;
        private System.Windows.Forms.Label labelConfirmarContraseniaActual;
        private System.Windows.Forms.TextBox txtConfirmarContraseniaNueva;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnCerrarSession;
    }
}