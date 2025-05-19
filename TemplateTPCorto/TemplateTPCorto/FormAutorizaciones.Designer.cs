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
            this.BtnAutorizarSeleccionados = new System.Windows.Forms.Button();
            this.BtnOperacionesCambioCredencial = new System.Windows.Forms.Button();
            this.BtnOperacionesCambioPersona = new System.Windows.Forms.Button();
            this.BtnRechazarSeleccionados = new System.Windows.Forms.Button();
            this.labelTipoOperacion = new System.Windows.Forms.Label();
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
            this.dgwAutorizarOperaciones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgwAutorizarOperaciones.Location = new System.Drawing.Point(23, 106);
            this.dgwAutorizarOperaciones.Name = "dgwAutorizarOperaciones";
            this.dgwAutorizarOperaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwAutorizarOperaciones.Size = new System.Drawing.Size(837, 305);
            this.dgwAutorizarOperaciones.TabIndex = 27;
            // 
            // BtnAutorizarSeleccionados
            // 
            this.BtnAutorizarSeleccionados.Location = new System.Drawing.Point(265, 431);
            this.BtnAutorizarSeleccionados.Name = "BtnAutorizarSeleccionados";
            this.BtnAutorizarSeleccionados.Size = new System.Drawing.Size(150, 25);
            this.BtnAutorizarSeleccionados.TabIndex = 29;
            this.BtnAutorizarSeleccionados.Text = "Autorizar seleccionados";
            this.BtnAutorizarSeleccionados.UseVisualStyleBackColor = true;
            this.BtnAutorizarSeleccionados.Click += new System.EventHandler(this.BtnAutorizarSeleccionados_Click);
            // 
            // BtnOperacionesCambioCredencial
            // 
            this.BtnOperacionesCambioCredencial.Location = new System.Drawing.Point(23, 32);
            this.BtnOperacionesCambioCredencial.Name = "BtnOperacionesCambioCredencial";
            this.BtnOperacionesCambioCredencial.Size = new System.Drawing.Size(170, 25);
            this.BtnOperacionesCambioCredencial.TabIndex = 30;
            this.BtnOperacionesCambioCredencial.Text = "Operaciones cambio credencial";
            this.BtnOperacionesCambioCredencial.UseVisualStyleBackColor = true;
            this.BtnOperacionesCambioCredencial.Click += new System.EventHandler(this.BtnOperacionesCambioCredencial_Click);
            // 
            // BtnOperacionesCambioPersona
            // 
            this.BtnOperacionesCambioPersona.Location = new System.Drawing.Point(199, 32);
            this.BtnOperacionesCambioPersona.Name = "BtnOperacionesCambioPersona";
            this.BtnOperacionesCambioPersona.Size = new System.Drawing.Size(170, 25);
            this.BtnOperacionesCambioPersona.TabIndex = 31;
            this.BtnOperacionesCambioPersona.Text = "Operaciones cambio persona";
            this.BtnOperacionesCambioPersona.UseVisualStyleBackColor = true;
            this.BtnOperacionesCambioPersona.Click += new System.EventHandler(this.BtnOperacionesCambioPersona_Click);
            // 
            // BtnRechazarSeleccionados
            // 
            this.BtnRechazarSeleccionados.Location = new System.Drawing.Point(462, 431);
            this.BtnRechazarSeleccionados.Name = "BtnRechazarSeleccionados";
            this.BtnRechazarSeleccionados.Size = new System.Drawing.Size(150, 25);
            this.BtnRechazarSeleccionados.TabIndex = 32;
            this.BtnRechazarSeleccionados.Text = "Rechazar seleccionados";
            this.BtnRechazarSeleccionados.UseVisualStyleBackColor = true;
            this.BtnRechazarSeleccionados.Click += new System.EventHandler(this.BtnRechazarSeleccionados_Click);
            // 
            // labelTipoOperacion
            // 
            this.labelTipoOperacion.AutoSize = true;
            this.labelTipoOperacion.Location = new System.Drawing.Point(23, 74);
            this.labelTipoOperacion.Name = "labelTipoOperacion";
            this.labelTipoOperacion.Size = new System.Drawing.Size(35, 13);
            this.labelTipoOperacion.TabIndex = 33;
            this.labelTipoOperacion.Text = "label1";
            // 
            // FormAutorizaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelTipoOperacion);
            this.Controls.Add(this.BtnRechazarSeleccionados);
            this.Controls.Add(this.BtnOperacionesCambioPersona);
            this.Controls.Add(this.BtnOperacionesCambioCredencial);
            this.Controls.Add(this.BtnAutorizarSeleccionados);
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
        private Button BtnAutorizarSeleccionados;
        private Button BtnOperacionesCambioCredencial;
        private Button BtnOperacionesCambioPersona;
        private Button BtnRechazarSeleccionados;
        private Label labelTipoOperacion;
    }
}
