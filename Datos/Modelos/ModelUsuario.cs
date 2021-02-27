using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Modelos
{
    public class ModelUsuario
    {
        public string Identificacion { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public string pass { get; set; }
        
        public string ticket { get; set; }

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
