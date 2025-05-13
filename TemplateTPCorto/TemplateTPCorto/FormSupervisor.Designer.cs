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
            this.btnCerrarSession = new System.Windows.Forms.Button();
            this.txtsupervisorusuario = new System.Windows.Forms.TextBox();
            this.btnsupervisorusuario = new System.Windows.Forms.Button();
            this.btnmodifipersona = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.txtapellido = new System.Windows.Forms.TextBox();
            this.txtdni = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.check1 = new System.Windows.Forms.CheckBox();
            this.check2 = new System.Windows.Forms.CheckBox();
            this.check3 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnCambioContrasenia
            // 
            this.btnCambioContrasenia.Location = new System.Drawing.Point(12, 12);
            this.btnCambioContrasenia.Name = "btnCambioContrasenia";
            this.btnCambioContrasenia.Size = new System.Drawing.Size(170, 25);
            this.btnCambioContrasenia.TabIndex = 1;
            this.btnCambioContrasenia.Text = "Desbloquear Credencial";
            this.btnCambioContrasenia.UseVisualStyleBackColor = true;
            this.btnCambioContrasenia.Click += new System.EventHandler(this.btnCambioContrasenia_Click);
            // 
            // btnModificarPersona
            // 
            this.btnModificarPersona.Location = new System.Drawing.Point(235, 12);
            this.btnModificarPersona.Name = "btnModificarPersona";
            this.btnModificarPersona.Size = new System.Drawing.Size(170, 25);
            this.btnModificarPersona.TabIndex = 5;
            this.btnModificarPersona.Text = "Modificar persona";
            this.btnModificarPersona.UseVisualStyleBackColor = true;
            this.btnModificarPersona.Click += new System.EventHandler(this.btnModificarPersona_Click);
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
            // txtsupervisorusuario
            // 
            this.txtsupervisorusuario.Location = new System.Drawing.Point(124, 67);
            this.txtsupervisorusuario.Name = "txtsupervisorusuario";
            this.txtsupervisorusuario.Size = new System.Drawing.Size(169, 20);
            this.txtsupervisorusuario.TabIndex = 7;
            // 
            // btnsupervisorusuario
            // 
            this.btnsupervisorusuario.Location = new System.Drawing.Point(12, 119);
            this.btnsupervisorusuario.Name = "btnsupervisorusuario";
            this.btnsupervisorusuario.Size = new System.Drawing.Size(162, 22);
            this.btnsupervisorusuario.TabIndex = 8;
            this.btnsupervisorusuario.Text = "Cambiar Contraseña";
            this.btnsupervisorusuario.UseVisualStyleBackColor = true;
            this.btnsupervisorusuario.Click += new System.EventHandler(this.btnsupervisorusuario_Click);
            // 
            // btnmodifipersona
            // 
            this.btnmodifipersona.Location = new System.Drawing.Point(253, 119);
            this.btnmodifipersona.Name = "btnmodifipersona";
            this.btnmodifipersona.Size = new System.Drawing.Size(152, 22);
            this.btnmodifipersona.TabIndex = 9;
            this.btnmodifipersona.Text = "Buscar legajo a modificar";
            this.btnmodifipersona.UseVisualStyleBackColor = true;
            this.btnmodifipersona.Click += new System.EventHandler(this.btnmodifipersona_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Legajo a modificar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(203, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Apellido";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(215, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "DNI";
            // 
            // txtnombre
            // 
            this.txtnombre.Location = new System.Drawing.Point(253, 156);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(152, 20);
            this.txtnombre.TabIndex = 14;
            // 
            // txtapellido
            // 
            this.txtapellido.Location = new System.Drawing.Point(253, 186);
            this.txtapellido.Name = "txtapellido";
            this.txtapellido.Size = new System.Drawing.Size(152, 20);
            this.txtapellido.TabIndex = 15;
            // 
            // txtdni
            // 
            this.txtdni.Location = new System.Drawing.Point(253, 215);
            this.txtdni.Name = "txtdni";
            this.txtdni.Size = new System.Drawing.Size(152, 20);
            this.txtdni.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(253, 241);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 27);
            this.button1.TabIndex = 19;
            this.button1.Text = "Modificar datos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // check1
            // 
            this.check1.AutoSize = true;
            this.check1.Location = new System.Drawing.Point(411, 156);
            this.check1.Name = "check1";
            this.check1.Size = new System.Drawing.Size(99, 17);
            this.check1.TabIndex = 20;
            this.check1.Text = "Modificar dato?";
            this.check1.UseVisualStyleBackColor = true;
            this.check1.CheckedChanged += new System.EventHandler(this.check1_CheckedChanged);
            // 
            // check2
            // 
            this.check2.AutoSize = true;
            this.check2.Location = new System.Drawing.Point(411, 185);
            this.check2.Name = "check2";
            this.check2.Size = new System.Drawing.Size(99, 17);
            this.check2.TabIndex = 21;
            this.check2.Text = "Modificar dato?";
            this.check2.UseVisualStyleBackColor = true;
            this.check2.CheckedChanged += new System.EventHandler(this.check2_CheckedChanged);
            // 
            // check3
            // 
            this.check3.AutoSize = true;
            this.check3.Location = new System.Drawing.Point(411, 218);
            this.check3.Name = "check3";
            this.check3.Size = new System.Drawing.Size(99, 17);
            this.check3.TabIndex = 22;
            this.check3.Text = "Modificar dato?";
            this.check3.UseVisualStyleBackColor = true;
            this.check3.CheckedChanged += new System.EventHandler(this.check3_CheckedChanged);
            // 
            // FormSupervisor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.check3);
            this.Controls.Add(this.check2);
            this.Controls.Add(this.check1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtdni);
            this.Controls.Add(this.txtapellido);
            this.Controls.Add(this.txtnombre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnmodifipersona);
            this.Controls.Add(this.btnsupervisorusuario);
            this.Controls.Add(this.txtsupervisorusuario);
            this.Controls.Add(this.btnCerrarSession);
            this.Controls.Add(this.btnModificarPersona);
            this.Controls.Add(this.btnCambioContrasenia);
            this.Name = "FormSupervisor";
            this.Text = "FormSupervisor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCambioContrasenia;
        private System.Windows.Forms.Button btnModificarPersona;
        private System.Windows.Forms.Button btnCerrarSession;
        private System.Windows.Forms.TextBox txtsupervisorusuario;
        private System.Windows.Forms.Button btnsupervisorusuario;
        private System.Windows.Forms.Button btnmodifipersona;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.TextBox txtapellido;
        private System.Windows.Forms.TextBox txtdni;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox check1;
        private System.Windows.Forms.CheckBox check2;
        private System.Windows.Forms.CheckBox check3;
    }
}