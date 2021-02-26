using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Users
    {
        private TAREA3Entities entities;

        public Users()
        {
            entities = new TAREA3Entities();
        }

        public int crearUsuario(Usuarios u)
        {
            entities.Usuarios.Add(u);
            return entities.SaveChanges();
        }

        public List<Usuarios> BuscarUsuario(string usu)
        {
            var query = from c in entities.Usuarios
                        where c.Identificacion == usu
                        select c;
            return query.ToList<Usuarios>();
        }
    }
}
