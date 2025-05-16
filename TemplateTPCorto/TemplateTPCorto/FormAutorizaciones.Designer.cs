using System.Windows.Forms;

namespace TemplateTPCorto
{
    partial class FormAutorizaciones
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtTitulo = new System.Windows.Forms.Label();
            this.dgwAutorizarOperaciones = new System.Windows.Forms.DataGridView();
            this.btnAutorizar = new System.Windows.Forms.Button();
            this.btnAutorizarCambioCredencial = new System.Windows.Forms.Button();
            this.btnAutorizarCambioPersona = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgwAutorizarOperaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTitulo
            // 
            this.txtTitulo.AutoSize = true;
            this.txtTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitulo.Location = new System.Drawing.Point(355, 0);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(148, 24);
            this.txtTitulo.TabIndex = 26;
            this.txtTitulo.Text = "Autorizaciones";
            // 
            // dgwAutorizarOperaciones
            // 
            this.dgwAutorizarOperaciones.AllowUserToAddRows = false;
            this.dgwAutorizarOperaciones.AllowUserToDeleteRows = false;
            this.dgwAutorizarOperaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwAutorizarOperaciones.Location = new System.Drawing.Point(23, 63);
            this.dgwAutorizarOperaciones.Name = "dgwAutorizarOperaciones";
            this.dgwAutorizarOperaciones.ReadOnly = false;
            this.dgwAutorizarOperaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwAutorizarOperaciones.Size = new System.Drawing.Size(837, 322);
            this.dgwAutorizarOperaciones.TabIndex = 27;
            this.dgwAutorizarOperaciones.EditMode = DataGridViewEditMode.EditOnEnter;
            // 
            // btnAutorizar
            // 
            this.btnAutorizar.Location = new System.Drawing.Point(359, 411);
            this.btnAutorizar.Name = "btnAutorizar";
            this.btnAutorizar.Size = new System.Drawing.Size(150, 25);
            this.btnAutorizar.TabIndex = 29;
            this.btnAutorizar.Text = "Autorizar seleccionados";
            this.btnAutorizar.UseVisualStyleBackColor = true;
            this.btnAutorizar.Click += new System.EventHandler(this.btnAutorizar_Click);
            // 
            // btnAutorizarCambioCredencial
            // 
            this.btnAutorizarCambioCredencial.Location = new System.Drawing.Point(23, 32);
            this.btnAutorizarCambioCredencial.Name = "btnAutorizarCambioCredencial";
            this.btnAutorizarCambioCredencial.Size = new System.Drawing.Size(150, 25);
            this.btnAutorizarCambioCredencial.TabIndex = 30;
            this.btnAutorizarCambioCredencial.Text = "Autorizar cambio credencial";
            this.btnAutorizarCambioCredencial.UseVisualStyleBackColor = true;
            this.btnAutorizarCambioCredencial.Click += new System.EventHandler(this.btnAutorizarCambioCredencial_Click);
            // 
            // btnAutorizarCambioPersona
            // 
            this.btnAutorizarCambioPersona.Location = new System.Drawing.Point(198, 32);
            this.btnAutorizarCambioPersona.Name = "btnAutorizarCambioPersona";
            this.btnAutorizarCambioPersona.Size = new System.Drawing.Size(150, 25);
            this.btnAutorizarCambioPersona.TabIndex = 31;
            this.btnAutorizarCambioPersona.Text = "Autorizar cambio persona";
            this.btnAutorizarCambioPersona.UseVisualStyleBackColor = true;
            this.btnAutorizarCambioPersona.Click += new System.EventHandler(this.btnAutorizarCambioPersona_Click);
            // 
            // FormAutorizaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAutorizarCambioPersona);
            this.Controls.Add(this.btnAutorizarCambioCredencial);
            this.Controls.Add(this.btnAutorizar);
            this.Controls.Add(this.dgwAutorizarOperaciones);
            this.Controls.Add(this.txtTitulo);
            this.Name = "FormAutorizaciones";
            this.Size = new System.Drawing.Size(886, 504);
            ((System.ComponentModel.ISupportInitialize)(this.dgwAutorizarOperaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtTitulo;
        private System.Windows.Forms.DataGridView dgwAutorizarOperaciones;
        private Button btnAutorizar;
        private Button btnAutorizarCambioCredencial;
        private Button btnAutorizarCambioPersona;
    }
}
