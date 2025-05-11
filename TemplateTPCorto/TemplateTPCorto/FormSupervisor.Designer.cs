namespace TemplateTPCorto
{
    partial class FormSupervisor
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
            this.btnModificarPersona = new System.Windows.Forms.Button();
            this.btnDesbloquearCredencial = new System.Windows.Forms.Button();
            this.btnCerrarSession = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCambioContrasenia
            // 
            this.btnCambioContrasenia.Location = new System.Drawing.Point(12, 12);
            this.btnCambioContrasenia.Name = "btnCambioContrasenia";
            this.btnCambioContrasenia.Size = new System.Drawing.Size(170, 25);
            this.btnCambioContrasenia.TabIndex = 1;
            this.btnCambioContrasenia.Text = "Cambiar contraseña";
            this.btnCambioContrasenia.UseVisualStyleBackColor = true;
            this.btnCambioContrasenia.Click += new System.EventHandler(this.btnCambioContrasenia_Click);
            // 
            // btnModificarPersona
            // 
            this.btnModificarPersona.Location = new System.Drawing.Point(188, 12);
            this.btnModificarPersona.Name = "btnModificarPersona";
            this.btnModificarPersona.Size = new System.Drawing.Size(170, 25);
            this.btnModificarPersona.TabIndex = 5;
            this.btnModificarPersona.Text = "Modificar persona";
            this.btnModificarPersona.UseVisualStyleBackColor = true;
            this.btnModificarPersona.Click += new System.EventHandler(this.btnModificarPersona_Click);
            // 
            // btnDesbloquearCredencial
            // 
            this.btnDesbloquearCredencial.Location = new System.Drawing.Point(364, 12);
            this.btnDesbloquearCredencial.Name = "btnDesbloquearCredencial";
            this.btnDesbloquearCredencial.Size = new System.Drawing.Size(170, 25);
            this.btnDesbloquearCredencial.TabIndex = 4;
            this.btnDesbloquearCredencial.Text = "Desbloquear credencial";
            this.btnDesbloquearCredencial.UseVisualStyleBackColor = true;
            this.btnDesbloquearCredencial.Click += new System.EventHandler(this.btnDesbloquearCredencial_Click);
            // 
            // btnCerrarSession
            // 
            this.btnCerrarSession.Location = new System.Drawing.Point(618, 12);
            this.btnCerrarSession.Name = "btnCerrarSession";
            this.btnCerrarSession.Size = new System.Drawing.Size(170, 25);
            this.btnCerrarSession.TabIndex = 6;
            this.btnCerrarSession.Text = "Cerrar session";
            this.btnCerrarSession.UseVisualStyleBackColor = true;
            // 
            // FormSupervisor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCerrarSession);
            this.Controls.Add(this.btnModificarPersona);
            this.Controls.Add(this.btnDesbloquearCredencial);
            this.Controls.Add(this.btnCambioContrasenia);
            this.Name = "FormSupervisor";
            this.Text = "FormSupervisor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCambioContrasenia;
        private System.Windows.Forms.Button btnModificarPersona;
        private System.Windows.Forms.Button btnDesbloquearCredencial;
        private System.Windows.Forms.Button btnCerrarSession;
    }
}