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
            this.btnDesbloquearCredencial.Location = new System.Drawing.Point(287, 203);
            this.btnDesbloquearCredencial.Margin = new System.Windows.Forms.Padding(2);
            this.btnDesbloquearCredencial.Name = "btnDesbloquearCredencial";
            this.btnDesbloquearCredencial.Size = new System.Drawing.Size(100, 25);
            this.btnDesbloquearCredencial.TabIndex = 17;
            this.btnDesbloquearCredencial.Text = "Desbloquear";
            this.btnDesbloquearCredencial.UseVisualStyleBackColor = true;
            this.btnDesbloquearCredencial.Click += new System.EventHandler(this.btnDesbloqueoCredencial_Click);
            // 
            // labelContraseniaNueva
            // 
            this.labelContraseniaNueva.AutoSize = true;
            this.labelContraseniaNueva.Location = new System.Drawing.Point(65, 122);
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
            this.txtContraseniaNueva.Location = new System.Drawing.Point(243, 122);
            this.txtContraseniaNueva.Margin = new System.Windows.Forms.Padding(2);
            this.txtContraseniaNueva.Name = "txtContraseniaNueva";
            this.txtContraseniaNueva.Size = new System.Drawing.Size(144, 20);
            this.txtContraseniaNueva.TabIndex = 14;
            // 
            // txtLegajo
            // 
            this.txtLegajo.Location = new System.Drawing.Point(243, 77);
            this.txtLegajo.Margin = new System.Windows.Forms.Padding(2);
            this.txtLegajo.Name = "txtLegajo";
            this.txtLegajo.Size = new System.Drawing.Size(144, 20);
            this.txtLegajo.TabIndex = 13;
            // 
            // FormDesbloquearCredencial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
    }
}
