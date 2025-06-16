using Datos.Ventas;
using Newtonsoft.Json;
using Persistencia.WebService.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class VentaPersistencia:IVentaPersistencia
    {
        public bool GuardarVenta(Venta venta)
        {
            // Aquí se implementaría la lógica para guardar la venta en el servicio web.

            string json = JsonConvert.SerializeObject(venta);
            HttpResponseMessage response = WebHelper.Post("/api/Venta/AgregarVenta", json);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
