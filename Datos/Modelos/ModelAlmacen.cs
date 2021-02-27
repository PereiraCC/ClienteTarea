using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Modelos
{
    public class ModelAlmacen
    {
        public int idAlmacen { get; set; }

        public string Descripcion { get; set; }

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }

        public override string ToString()
        {
            return ToJsonString();
        }
    }
}
