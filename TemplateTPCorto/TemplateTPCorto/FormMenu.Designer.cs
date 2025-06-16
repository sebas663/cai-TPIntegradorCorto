using System.Drawing;
using System.Windows.Forms;

namespace TemplateTPCorto
{
    partial class FormMenu
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
            this.btnCerrarSession = new System.Windows.Forms.Button();
            this.btnAutorizaciones = new System.Windows.Forms.Button();
            this.btnCambioContrasenia = new System.Windows.Forms.Button();
            this.btnModificarPersona = new System.Windows.Forms.Button();
            this.btnDesbloquearCredencial = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.btnVentas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCerrarSession
            // 
            this.btnCerrarSession.Location = new System.Drawing.Point(1163, 15);
            this.btnCerrarSession.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCerrarSession.Name = "btnCerrarSession";
            this.btnCerrarSession.Size = new System.Drawing.Size(133, 31);
            this.btnCerrarSession.TabIndex = 8;
            this.btnCerrarSession.Text = "Cerrar sesion";
            this.btnCerrarSession.UseVisualStyleBackColor = true;
            this.btnCerrarSession.Click += new System.EventHandler(this.BtnCerrarSession_Click);
            // 
            // btnAutorizaciones
            // 
            this.btnAutorizaciones.Location = new System.Drawing.Point(197, 15);
            this.btnAutorizaciones.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAutorizaciones.Name = "btnAutorizaciones";
            this.btnAutorizaciones.Size = new System.Drawing.Size(173, 31);
            this.btnAutorizaciones.TabIndex = 7;
            this.btnAutorizaciones.Text = "Autorizaciones";
            this.btnAutorizaciones.UseVisualStyleBackColor = true;
            this.btnAutorizaciones.Click += new System.EventHandler(this.BtnAutorizaciones_Click);
            // 
            // btnCambioContrasenia
            // 
            this.btnCambioContrasenia.Location = new System.Drawing.Point(16, 15);
            this.btnCambioContrasenia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCambioContrasenia.Name = "btnCambioContrasenia";
            this.btnCambioContrasenia.Size = new System.Drawing.Size(173, 31);
            this.btnCambioContrasenia.TabIndex = 6;
            this.btnCambioContrasenia.Text = "Cambiar contraseña";
            this.btnCambioContrasenia.UseVisualStyleBackColor = true;
            this.btnCambioContrasenia.Click += new System.EventHandler(this.BtnCambioContrasenia_Click);
            // 
            // btnModificarPersona
            // 
            this.btnModificarPersona.Location = new System.Drawing.Point(197, 15);
            this.btnModificarPersona.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnModificarPersona.Name = "btnModificarPersona";
            this.btnModificarPersona.Size = new System.Drawing.Size(173, 31);
            this.btnModificarPersona.TabIndex = 10;
            this.btnModificarPersona.Text = "Modificar persona";
            this.btnModificarPersona.UseVisualStyleBackColor = true;
            this.btnModificarPersona.Click += new System.EventHandler(this.BtnModificarPersona_Click);
            // 
            // btnDesbloquearCredencial
            // 
            this.btnDesbloquearCredencial.Location = new System.Drawing.Point(379, 15);
            this.btnDesbloquearCredencial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDesbloquearCredencial.Name = "btnDesbloquearCredencial";
            this.btnDesbloquearCredencial.Size = new System.Drawing.Size(173, 31);
            this.btnDesbloquearCredencial.TabIndex = 9;
            this.btnDesbloquearCredencial.Text = "Desbloquear credencial";
            this.btnDesbloquearCredencial.UseVisualStyleBackColor = true;
            this.btnDesbloquearCredencial.Click += new System.EventHandler(this.BtnDesbloquearCredencial_Click);
            // 
            // panelMain
            // 
            this.panelMain.Location = new System.Drawing.Point(16, 78);
            this.panelMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1280, 583);
            this.panelMain.TabIndex = 11;
            // 
            // btnVentas
            // 
            this.btnVentas.Location = new System.Drawing.Point(197, 15);
            this.btnVentas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(173, 31);
            this.btnVentas.TabIndex = 12;
            this.btnVentas.Text = "Ventas";
            this.btnVentas.UseVisualStyleBackColor = true;
            this.btnVentas.Click += new System.EventHandler(this.BtnVentas_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1309, 681);
            this.Controls.Add(this.btnVentas);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.btnModificarPersona);
            this.Controls.Add(this.btnDesbloquearCredencial);
            this.Controls.Add(this.btnCerrarSession);
            this.Controls.Add(this.btnAutorizaciones);
            this.Controls.Add(this.btnCambioContrasenia);
            this.Location = new System.Drawing.Point(200, 75);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FormMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCerrarSession;
        private System.Windows.Forms.Button btnAutorizaciones;
        private System.Windows.Forms.Button btnCambioContrasenia;
        private System.Windows.Forms.Button btnModificarPersona;
        private System.Windows.Forms.Button btnDesbloquearCredencial;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button btnVentas;
    }
}