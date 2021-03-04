using Datos;
using Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class ActionsUser
    {
        private Users usuario = new Users();

        public string crearUsuario(string identificacion, string nombre, string apellidos, string password)
        {
            try
            {
                string res = usuario.crearUsuario(new ModelUsuario()
                {
                    Identificacion = identificacion,
                    Nombre = nombre,
                    Apellidos = apellidos,
                    pass = password
                });

                return res;
            }
            catch(Exception ex)
            {
                throw ex;
            }  
        }

        private string EncrytarPassword(string password)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(password);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        private string DesEncrytarPassword(string password)
        {
            string result = string.Empty;
            byte[] dencryted = Convert.FromBase64String(password);
            result = System.Text.Encoding.Unicode.GetString(dencryted);
            return result;
        }

        public string ValidarUsuario(string identificacion, string password)
        {
            try
            {
                string res = usuario.ValidarInicioSesion(new ModelUsuario()
                {
                    Identificacion = identificacion,
                    pass = password
                });

                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string cerrarSesion(string identificacion)
        {
            try
            {
                return usuario.CerrarSesion(new ModelUsuario()
                {
                    Identificacion = identificacion
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string ValidarNulos(string Identificacion, string Nombre, string Apellidos, string Contrasena)
        {
            try
            {
                if (Identificacion.Length != 0)
                {
                    if (Nombre.Length != 0)
                    {
                        if (Apellidos.Length != 0)
                        {
                            if (Contrasena.Length != 0)
                            {
                                return "1";
                            }
                            else
                            {
                                return "El campo de Contraseña es Obligatorio";
                            }
                        }
                        else
                        {
                            return "El campo de Apellidos es Obligatorio";
                        }
                    }
                    else
                    {
                        return "El campo de Nombre es Obligatorio";
                    }
                }
                else
                {
                    return "El campo de Identificacion es Obligatorio";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string validarTexto(string Nombre, string Apellidos)
        {
            try
            {
                Nombre = Nombre.Replace(" ", String.Empty);
                if (Nombre.All(char.IsLetter))
                {
                    Apellidos = Apellidos.Replace(" ", String.Empty);
                    if (Apellidos.All(char.IsLetter))
                    {
                        return "1";
                    }
                    else
                    {
                        return "El campo Apellidos solo permite letras";
                    }
                }
                else
                {
                    return "El campo Nombre solo permite letras";
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string ValidarNumero(string Identificacion)
        {
            try
            {
                Identificacion = Identificacion.Replace(" ", String.Empty);
                if (Identificacion.All(char.IsDigit))
                {
                    return "1";
                }
                else
                {
                    return "El campo identificacion solo permite numeros";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ValidarNulosIndex(string Identificacion, string Contrasena)
        {
            try
            {
                if (Identificacion.Length != 0)
                {

                    if (Contrasena.Length != 0)
                    {
                        return "1";
                    }
                    else
                    {
                        return "El campo de Contraseña es Obligatorio";
                    }
                }
                else
                {
                    return "El campo de Identificacion es Obligatorio";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
