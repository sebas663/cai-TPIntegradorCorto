using System.Drawing;

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
            this.txtTitulo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCambioContrasenia
            // 
            this.btnCambioContrasenia.Location = new System.Drawing.Point(244, 170);
            this.btnCambioContrasenia.Margin = new System.Windows.Forms.Padding(2);
            this.btnCambioContrasenia.Name = "btnCambioContrasenia";
            this.btnCambioContrasenia.Size = new System.Drawing.Size(100, 25);
            this.btnCambioContrasenia.TabIndex = 9;
            this.btnCambioContrasenia.Text = "Cambiar";
            this.btnCambioContrasenia.UseVisualStyleBackColor = true;
            this.btnCambioContrasenia.Click += new System.EventHandler(this.BtnCambioContrasenia_Click);
            // 
            // labelContraseniaNueva
            // 
            this.labelContraseniaNueva.AutoSize = true;
            this.labelContraseniaNueva.Location = new System.Drawing.Point(20, 90);
            this.labelContraseniaNueva.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelContraseniaNueva.Name = "labelContraseniaNueva";
            this.labelContraseniaNueva.Size = new System.Drawing.Size(94, 13);
            this.labelContraseniaNueva.TabIndex = 8;
            this.labelContraseniaNueva.Text = "Contraseña nueva";
            // 
            // labelContraseniaActual
            // 
            this.labelContraseniaActual.AutoSize = true;
            this.labelContraseniaActual.Location = new System.Drawing.Point(20, 50);
            this.labelContraseniaActual.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelContraseniaActual.Name = "labelContraseniaActual";
            this.labelContraseniaActual.Size = new System.Drawing.Size(93, 13);
            this.labelContraseniaActual.TabIndex = 7;
            this.labelContraseniaActual.Text = "Contraseña actual";
            // 
            // txtContraseniaNueva
            // 
            this.txtContraseniaNueva.Location = new System.Drawing.Point(200, 90);
            this.txtContraseniaNueva.Margin = new System.Windows.Forms.Padding(2);
            this.txtContraseniaNueva.Name = "txtContraseniaNueva";
            this.txtContraseniaNueva.Size = new System.Drawing.Size(144, 20);
            this.txtContraseniaNueva.TabIndex = 6;
            // 
            // txtContraseniaActual
            // 
            this.txtContraseniaActual.Location = new System.Drawing.Point(200, 50);
            this.txtContraseniaActual.Margin = new System.Windows.Forms.Padding(2);
            this.txtContraseniaActual.Name = "txtContraseniaActual";
            this.txtContraseniaActual.Size = new System.Drawing.Size(144, 20);
            this.txtContraseniaActual.TabIndex = 5;
            // 
            // labelConfirmarContraseniaActual
            // 
            this.labelConfirmarContraseniaActual.AutoSize = true;
            this.labelConfirmarContraseniaActual.Location = new System.Drawing.Point(20, 130);
            this.labelConfirmarContraseniaActual.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelConfirmarContraseniaActual.Name = "labelConfirmarContraseniaActual";
            this.labelConfirmarContraseniaActual.Size = new System.Drawing.Size(140, 13);
            this.labelConfirmarContraseniaActual.TabIndex = 11;
            this.labelConfirmarContraseniaActual.Text = "Confirmar contraseña nueva";
            // 
            // txtConfirmarContraseniaNueva
            // 
            this.txtConfirmarContraseniaNueva.Location = new System.Drawing.Point(200, 130);
            this.txtConfirmarContraseniaNueva.Margin = new System.Windows.Forms.Padding(2);
            this.txtConfirmarContraseniaNueva.Name = "txtConfirmarContraseniaNueva";
            this.txtConfirmarContraseniaNueva.Size = new System.Drawing.Size(144, 20);
            this.txtConfirmarContraseniaNueva.TabIndex = 10;
            // 
            // txtTitulo
            // 
            this.txtTitulo.AutoSize = true;
            this.txtTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitulo.Location = new System.Drawing.Point(350, 10);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(220, 24);
            this.txtTitulo.TabIndex = 12;
            this.txtTitulo.Text = "Cambio de contraseña";
            // 
            // FormContraseniaCambio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.labelConfirmarContraseniaActual);
            this.Controls.Add(this.txtConfirmarContraseniaNueva);
            this.Controls.Add(this.btnCambioContrasenia);
            this.Controls.Add(this.labelContraseniaNueva);
            this.Controls.Add(this.labelContraseniaActual);
            this.Controls.Add(this.txtContraseniaNueva);
            this.Controls.Add(this.txtContraseniaActual);
            this.Location = new System.Drawing.Point(200, 75);
            this.Name = "FormContraseniaCambio";
            this.Size = new System.Drawing.Size(900, 500);
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
        private System.Windows.Forms.Label txtTitulo;
    }
}