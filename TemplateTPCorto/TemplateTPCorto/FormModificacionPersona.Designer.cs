namespace TemplateTPCorto
{
    partial class FormModificacionPersona
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
            this.btnModificar = new System.Windows.Forms.Button();
            this.labelLegajo = new System.Windows.Forms.Label();
            this.txtLegajo = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.labelNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.labelApellido = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.labelFechaIngreso = new System.Windows.Forms.Label();
            this.dateFechaIngreso = new System.Windows.Forms.DateTimePicker();
            this.labelDni = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtTitulo
            // 
            this.txtTitulo.AutoSize = true;
            this.txtTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitulo.Location = new System.Drawing.Point(295, 0);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(177, 24);
            this.txtTitulo.TabIndex = 26;
            this.txtTitulo.Text = "Modificar persona";
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(243, 408);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(2);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(100, 25);
            this.btnModificar.TabIndex = 25;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // labelLegajo
            // 
            this.labelLegajo.AutoSize = true;
            this.labelLegajo.Location = new System.Drawing.Point(65, 50);
            this.labelLegajo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLegajo.Name = "labelLegajo";
            this.labelLegajo.Size = new System.Drawing.Size(39, 13);
            this.labelLegajo.TabIndex = 23;
            this.labelLegajo.Text = "Legajo";
            // 
            // txtLegajo
            // 
            this.txtLegajo.Location = new System.Drawing.Point(144, 47);
            this.txtLegajo.Margin = new System.Windows.Forms.Padding(2);
            this.txtLegajo.Name = "txtLegajo";
            this.txtLegajo.Size = new System.Drawing.Size(144, 20);
            this.txtLegajo.TabIndex = 21;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(332, 44);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 25);
            this.btnBuscar.TabIndex = 27;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(65, 109);
            this.labelNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(44, 13);
            this.labelNombre.TabIndex = 29;
            this.labelNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(180, 106);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(198, 20);
            this.txtNombre.TabIndex = 28;
            // 
            // labelApellido
            // 
            this.labelApellido.AutoSize = true;
            this.labelApellido.Location = new System.Drawing.Point(65, 153);
            this.labelApellido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelApellido.Name = "labelApellido";
            this.labelApellido.Size = new System.Drawing.Size(44, 13);
            this.labelApellido.TabIndex = 31;
            this.labelApellido.Text = "Apellido";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(180, 153);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(2);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(198, 20);
            this.txtApellido.TabIndex = 30;
            // 
            // labelFechaIngreso
            // 
            this.labelFechaIngreso.AutoSize = true;
            this.labelFechaIngreso.Location = new System.Drawing.Point(65, 246);
            this.labelFechaIngreso.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFechaIngreso.Name = "labelFechaIngreso";
            this.labelFechaIngreso.Size = new System.Drawing.Size(89, 13);
            this.labelFechaIngreso.TabIndex = 35;
            this.labelFechaIngreso.Text = "Fecha de ingreso";
            // 
            // dateFechaIngreso
            // 
            this.dateFechaIngreso.Location = new System.Drawing.Point(180, 246);
            this.dateFechaIngreso.Name = "dateFechaIngreso";
            this.dateFechaIngreso.Size = new System.Drawing.Size(198, 20);
            this.dateFechaIngreso.TabIndex = 34;
            // 
            // labelDni
            // 
            this.labelDni.AutoSize = true;
            this.labelDni.Location = new System.Drawing.Point(65, 197);
            this.labelDni.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDni.Name = "labelDni";
            this.labelDni.Size = new System.Drawing.Size(26, 13);
            this.labelDni.TabIndex = 37;
            this.labelDni.Text = "DNI";
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(180, 197);
            this.txtDni.Margin = new System.Windows.Forms.Padding(2);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(198, 20);
            this.txtDni.TabIndex = 36;
            // 
            // FormModificacionPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelDni);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.labelFechaIngreso);
            this.Controls.Add(this.dateFechaIngreso);
            this.Controls.Add(this.labelApellido);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.labelLegajo);
            this.Controls.Add(this.txtLegajo);
            this.Name = "FormModificacionPersona";
            this.Size = new System.Drawing.Size(865, 471);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtTitulo;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Label labelLegajo;
        private System.Windows.Forms.TextBox txtLegajo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label labelApellido;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label labelFechaIngreso;
        private System.Windows.Forms.DateTimePicker dateFechaIngreso;
        private System.Windows.Forms.Label labelDni;
        private System.Windows.Forms.TextBox txtDni;
    }
}
