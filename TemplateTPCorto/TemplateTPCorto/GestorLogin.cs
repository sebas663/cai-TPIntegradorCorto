using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemplateTPCorto
{
    public class GestorLogin
    {
        private readonly string archivoCredenciales = "credenciales.csv";
        private readonly string archivoIntentos = "login_intentos.csv";
        private readonly string archivoBloqueados = "usuario_bloqueado.csv";

        public bool ValidarCredenciales(string usuario, string password)
        {
            if (!File.Exists(archivoCredenciales))
            {
                MessageBox.Show("No se encontró el archivo de credenciales.");
                return false;
            }

            using (StreamReader sr = new StreamReader(archivoCredenciales))
            {
                while (!sr.EndOfStream)
                {
                    string[] linea = sr.ReadLine().Split(';');

                    if (linea.Length >= 2)
                    {
                        string usuarioArchivo = linea[1].Trim();
                        string contraseñaArchivo = linea[2].Trim();

                        if (usuarioArchivo.Equals(usuario, StringComparison.OrdinalIgnoreCase) &&
                            contraseñaArchivo == password)
                        {
                            return true; // Login correcto
                        }
                    }
                }
            }

            return false; // Login fallido
        }

        public bool EstaBloqueado(string usuario)
        {
            if (!File.Exists(archivoBloqueados))
                return false;

            var lineas = File.ReadAllLines(archivoBloqueados);
            return lineas.Any(linea => linea.Trim().Equals(usuario, StringComparison.OrdinalIgnoreCase));
        }

        public void RegistrarIntentoFallido(string usuario)
        {
            List<string> lineasActualizadas = new List<string>();
            bool encontrado = false;

            if (File.Exists(archivoIntentos))
            {
                foreach (var linea in File.ReadAllLines(archivoIntentos))
                {
                    string[] partes = linea.Split(';');
                    if (partes.Length == 2)
                    {
                        string usuarioArchivo = partes[0].Trim();
                        int intentos = int.Parse(partes[1]);

                        if (usuarioArchivo.Equals(usuario, StringComparison.OrdinalIgnoreCase))
                        {
                            intentos++;
                            encontrado = true;

                            if (intentos >= 3)
                            {
                                BloquearUsuario(usuario);
                                MessageBox.Show("Usuario bloqueado por exceder el número de intentos.");
                            }

                            lineasActualizadas.Add($"{usuarioArchivo};{intentos}");
                        }
                        else
                        {
                            lineasActualizadas.Add(linea);
                        }
                    }
                }
            }

            if (!encontrado)
            {
                lineasActualizadas.Add($"{usuario};1");
            }

            File.WriteAllLines(archivoIntentos, lineasActualizadas);
        }

        private void BloquearUsuario(string usuario)
        {
            if (!File.Exists(archivoBloqueados) ||
                !File.ReadAllLines(archivoBloqueados).Any(u => u.Equals(usuario, StringComparison.OrdinalIgnoreCase)))
            {
                File.AppendAllText(archivoBloqueados, usuario + Environment.NewLine);
            }
        }

        public void LimpiarIntentos(string usuario)
        {
            if (!File.Exists(archivoIntentos)) return;

            var lineasFiltradas = File.ReadAllLines(archivoIntentos)
                .Where(l => !l.StartsWith(usuario + ";", StringComparison.OrdinalIgnoreCase));

            File.WriteAllLines(archivoIntentos, lineasFiltradas);
        }
    }
}
}
