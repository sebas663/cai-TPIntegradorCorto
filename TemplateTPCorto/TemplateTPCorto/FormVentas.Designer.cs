using System.Drawing;
using System.Windows.Forms;

namespace TemplateTPCorto
{
    partial class FormVentas
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
            this.cmbClientes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCategoriaProductos = new System.Windows.Forms.ComboBox();
            this.lstProducto = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lablSubTotal = new System.Windows.Forms.Label();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnCargar = new System.Windows.Forms.Button();
            this.btnListarProductos = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.btnModificarCant = new System.Windows.Forms.Button();
            this.txtModificarCantidad = new System.Windows.Forms.TextBox();
            this.btnVaciarCarro = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbClientes
            // 
            this.cmbClientes.FormattingEnabled = true;
            this.cmbClientes.Location = new System.Drawing.Point(140, 51);
            this.cmbClientes.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.cmbClientes.Name = "cmbClientes";
            this.cmbClientes.Size = new System.Drawing.Size(160, 21);
            this.cmbClientes.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Clientes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 100);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Categoria Productos";
            // 
            // cboCategoriaProductos
            // 
            this.cboCategoriaProductos.FormattingEnabled = true;
            this.cboCategoriaProductos.Location = new System.Drawing.Point(141, 100);
            this.cboCategoriaProductos.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.cboCategoriaProductos.Name = "cboCategoriaProductos";
            this.cboCategoriaProductos.Size = new System.Drawing.Size(92, 21);
            this.cboCategoriaProductos.TabIndex = 3;
            this.cboCategoriaProductos.SelectedIndexChanged += new System.EventHandler(this.cboCategoriaProductos_SelectedIndexChanged);
            // 
            // lstProducto
            // 
            this.lstProducto.FormattingEnabled = true;
            this.lstProducto.Location = new System.Drawing.Point(20, 140);
            this.lstProducto.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.lstProducto.Name = "lstProducto";
            this.lstProducto.Size = new System.Drawing.Size(339, 212);
            this.lstProducto.TabIndex = 4;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(383, 66);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(290, 251);
            this.listBox1.TabIndex = 5;
            this.listBox1.Click += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listBox1_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(380, 329);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "SubTotal";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(380, 373);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Total";
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.Location = new System.Drawing.Point(0, 0);
            this.lblSubTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(75, 19);
            this.lblSubTotal.TabIndex = 14;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(475, 373);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(13, 13);
            this.lblTotal.TabIndex = 9;
            this.lblTotal.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 370);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Cantidad";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(73, 367);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(50, 20);
            this.txtCantidad.TabIndex = 11;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(20, 390);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(100, 25);
            this.btnAgregar.TabIndex = 12;
            this.btnAgregar.Text = "Agregar a carro";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lablSubTotal
            // 
            this.lablSubTotal.AutoSize = true;
            this.lablSubTotal.Location = new System.Drawing.Point(475, 329);
            this.lablSubTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lablSubTotal.Name = "lablSubTotal";
            this.lablSubTotal.Size = new System.Drawing.Size(13, 13);
            this.lablSubTotal.TabIndex = 13;
            this.lablSubTotal.Text = "0";
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(680, 253);
            this.btnQuitar.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(103, 25);
            this.btnQuitar.TabIndex = 15;
            this.btnQuitar.Text = "Quitar producto";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(464, 398);
            this.btnCargar.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(119, 25);
            this.btnCargar.TabIndex = 16;
            this.btnCargar.Text = "Cargar Venta";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // btnListarProductos
            // 
            this.btnListarProductos.Location = new System.Drawing.Point(248, 100);
            this.btnListarProductos.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnListarProductos.Name = "btnListarProductos";
            this.btnListarProductos.Size = new System.Drawing.Size(111, 25);
            this.btnListarProductos.TabIndex = 17;
            this.btnListarProductos.Text = "Listar productos";
            this.btnListarProductos.UseVisualStyleBackColor = true;
            this.btnListarProductos.Click += new System.EventHandler(this.btnListarProductos_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(380, 349);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Descuento";
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Location = new System.Drawing.Point(475, 349);
            this.lblDescuento.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(13, 13);
            this.lblDescuento.TabIndex = 1;
            this.lblDescuento.Text = "0";
            // 
            // btnModificarCant
            // 
            this.btnModificarCant.Location = new System.Drawing.Point(680, 217);
            this.btnModificarCant.Margin = new System.Windows.Forms.Padding(2);
            this.btnModificarCant.Name = "btnModificarCant";
            this.btnModificarCant.Size = new System.Drawing.Size(103, 25);
            this.btnModificarCant.TabIndex = 18;
            this.btnModificarCant.Text = "Modificar carro";
            this.btnModificarCant.UseVisualStyleBackColor = true;
            this.btnModificarCant.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // txtModificarCantidad
            // 
            this.txtModificarCantidad.Location = new System.Drawing.Point(734, 194);
            this.txtModificarCantidad.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtModificarCantidad.Name = "txtModificarCantidad";
            this.txtModificarCantidad.Size = new System.Drawing.Size(50, 20);
            this.txtModificarCantidad.TabIndex = 19;
            // 
            // btnVaciarCarro
            // 
            this.btnVaciarCarro.Location = new System.Drawing.Point(680, 291);
            this.btnVaciarCarro.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnVaciarCarro.Name = "btnVaciarCarro";
            this.btnVaciarCarro.Size = new System.Drawing.Size(103, 25);
            this.btnVaciarCarro.TabIndex = 20;
            this.btnVaciarCarro.Text = "Vaciar carro";
            this.btnVaciarCarro.UseVisualStyleBackColor = true;
            this.btnVaciarCarro.Click += new System.EventHandler(this.btnVaciarCarro_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(680, 197);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Cantidad";
            // 
            // FormVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnVaciarCarro);
            this.Controls.Add(this.txtModificarCantidad);
            this.Controls.Add(this.btnModificarCant);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblDescuento);
            this.Controls.Add(this.btnListarProductos);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.lablSubTotal);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblSubTotal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lstProducto);
            this.Controls.Add(this.cboCategoriaProductos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbClientes);
            this.Location = new System.Drawing.Point(200, 75);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "FormVentas";
            this.Size = new System.Drawing.Size(900, 500);
            this.Load += new System.EventHandler(this.FormVentas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbClientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCategoriaProductos;
        private System.Windows.Forms.ListBox lstProducto;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lablSubTotal;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Button btnListarProductos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDescuento;
        private Button btnModificarCant;
        private TextBox txtModificarCantidad;
        private Button btnVaciarCarro;
        private Label label7;
    }
}