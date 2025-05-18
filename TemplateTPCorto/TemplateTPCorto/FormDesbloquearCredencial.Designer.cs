namespace TemplateTPCorto
{
    partial class FormDesbloquearCredencial
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
            this.btnDesbloquearCredencial = new System.Windows.Forms.Button();
            this.labelContraseniaNueva = new System.Windows.Forms.Label();
            this.labelLegajo = new System.Windows.Forms.Label();
            this.txtContraseniaNueva = new System.Windows.Forms.TextBox();
            this.txtLegajo = new System.Windows.Forms.TextBox();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTitulo
            // 
            this.txtTitulo.AutoSize = true;
            this.txtTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitulo.Location = new System.Drawing.Point(305, 0);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(233, 24);
            this.txtTitulo.TabIndex = 20;
            this.txtTitulo.Text = "Desbloquear credencial";
            // 
            // btnDesbloquearCredencial
            // 
            this.btnDesbloquearCredencial.Location = new System.Drawing.Point(224, 200);
            this.btnDesbloquearCredencial.Margin = new System.Windows.Forms.Padding(2);
            this.btnDesbloquearCredencial.Name = "btnDesbloquearCredencial";
            this.btnDesbloquearCredencial.Size = new System.Drawing.Size(100, 25);
            this.btnDesbloquearCredencial.TabIndex = 17;
            this.btnDesbloquearCredencial.Text = "Desbloquear";
            this.btnDesbloquearCredencial.UseVisualStyleBackColor = true;
            this.btnDesbloquearCredencial.Click += new System.EventHandler(this.BtnDesbloqueoCredencial_Click);
            // 
            // labelContraseniaNueva
            // 
            this.labelContraseniaNueva.AutoSize = true;
            this.labelContraseniaNueva.Location = new System.Drawing.Point(65, 145);
            this.labelContraseniaNueva.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelContraseniaNueva.Name = "labelContraseniaNueva";
            this.labelContraseniaNueva.Size = new System.Drawing.Size(94, 13);
            this.labelContraseniaNueva.TabIndex = 16;
            this.labelContraseniaNueva.Text = "Contraseña nueva";
            // 
            // labelLegajo
            // 
            this.labelLegajo.AutoSize = true;
            this.labelLegajo.Location = new System.Drawing.Point(65, 80);
            this.labelLegajo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLegajo.Name = "labelLegajo";
            this.labelLegajo.Size = new System.Drawing.Size(39, 13);
            this.labelLegajo.TabIndex = 15;
            this.labelLegajo.Text = "Legajo";
            // 
            // txtContraseniaNueva
            // 
            this.txtContraseniaNueva.Location = new System.Drawing.Point(180, 142);
            this.txtContraseniaNueva.Margin = new System.Windows.Forms.Padding(2);
            this.txtContraseniaNueva.Name = "txtContraseniaNueva";
            this.txtContraseniaNueva.Size = new System.Drawing.Size(144, 20);
            this.txtContraseniaNueva.TabIndex = 14;
            // 
            // txtLegajo
            // 
            this.txtLegajo.Location = new System.Drawing.Point(180, 74);
            this.txtLegajo.Margin = new System.Windows.Forms.Padding(2);
            this.txtLegajo.Name = "txtLegajo";
            this.txtLegajo.Size = new System.Drawing.Size(144, 20);
            this.txtLegajo.TabIndex = 13;
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Location = new System.Drawing.Point(65, 112);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(35, 13);
            this.labelUsuario.TabIndex = 21;
            this.labelUsuario.Text = "label1";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(366, 71);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 25);
            this.btnBuscar.TabIndex = 28;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // FormDesbloquearCredencial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.labelUsuario);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.btnDesbloquearCredencial);
            this.Controls.Add(this.labelContraseniaNueva);
            this.Controls.Add(this.labelLegajo);
            this.Controls.Add(this.txtContraseniaNueva);
            this.Controls.Add(this.txtLegajo);
            this.Name = "FormDesbloquearCredencial";
            this.Size = new System.Drawing.Size(838, 461);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtTitulo;
        private System.Windows.Forms.Button btnDesbloquearCredencial;
        private System.Windows.Forms.Label labelContraseniaNueva;
        private System.Windows.Forms.Label labelLegajo;
        private System.Windows.Forms.TextBox txtContraseniaNueva;
        private System.Windows.Forms.TextBox txtLegajo;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.Button btnBuscar;
    }
}
