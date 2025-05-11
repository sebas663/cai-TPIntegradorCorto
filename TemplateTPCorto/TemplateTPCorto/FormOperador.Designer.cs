namespace TemplateTPCorto
{
    partial class FormOperador
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
            this.btnCerrarSession = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCambioContrasenia
            // 
            this.btnCambioContrasenia.Location = new System.Drawing.Point(12, 12);
            this.btnCambioContrasenia.Name = "btnCambioContrasenia";
            this.btnCambioContrasenia.Size = new System.Drawing.Size(170, 25);
            this.btnCambioContrasenia.TabIndex = 0;
            this.btnCambioContrasenia.Text = "Cambiar contraseña";
            this.btnCambioContrasenia.UseVisualStyleBackColor = true;
            this.btnCambioContrasenia.Click += new System.EventHandler(this.btnCambioContrasenia_Click);
            // 
            // btnCerrarSession
            // 
            this.btnCerrarSession.Location = new System.Drawing.Point(618, 10);
            this.btnCerrarSession.Name = "btnCerrarSession";
            this.btnCerrarSession.Size = new System.Drawing.Size(170, 25);
            this.btnCerrarSession.TabIndex = 1;
            this.btnCerrarSession.Text = "Cerrar session";
            this.btnCerrarSession.UseVisualStyleBackColor = true;
            // 
            // FormOperador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCerrarSession);
            this.Controls.Add(this.btnCambioContrasenia);
            this.Name = "FormOperador";
            this.Text = "FormOperador";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCambioContrasenia;
        private System.Windows.Forms.Button btnCerrarSession;
    }
}