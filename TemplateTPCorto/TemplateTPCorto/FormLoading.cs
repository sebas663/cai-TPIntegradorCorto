using System.Windows.Forms;

namespace TemplateTPCorto
{
    /// <summary>
    /// Formulario modal utilizado para mostrar un mensaje de carga mientras se ejecuta una operación.
    /// </summary>
    public partial class FormLoading : Form
    {
        /// <summary>
        /// Inicializa una nueva instancia del formulario <see cref="FormLoading"/>.
        /// </summary>
        public FormLoading()
        {
            InitializeComponent();
            InicializarFormulario();
        }

        /// <summary>
        /// Configura los controles y la apariencia del formulario de carga.
        /// </summary>
        private void InicializarFormulario()
        {
            // Estilo de ventana: fija, sin botones de cerrar
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.ControlBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Width = 400;
            this.Height = 300;
            this.TopMost = true;
            this.Text = "Cargando...";

            // Etiqueta centrada que indica al usuario que espere
            Label label = new Label();
            label.Text = "Por favor espere...";
            label.AutoSize = false;
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label.Dock = DockStyle.Fill;
            label.Font = new System.Drawing.Font("Segoe UI", 10F);

            this.Controls.Add(label);
        }
    }
}