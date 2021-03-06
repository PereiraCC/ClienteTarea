﻿using Datos.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Users
    {
        private const string SERVICE_BASE_URL = "http://localhost/ApiTarea/api/Usuarios";

        public Users() { }

        //Este metodo hace la peticion http a la api para crear un usuario
        public string crearUsuario(ModelUsuario usuario)
        {
            try
            {
                string json = usuario.ToJsonString();
                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {
                        return await client.PostAsync(
                            SERVICE_BASE_URL,
                            new StringContent(json, Encoding.UTF8, "application/json")
                        );
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.Created)
                    {
                        return "1";
                    }
                    else if (message.StatusCode == System.Net.HttpStatusCode.Conflict)
                    {
                        return "El usuario ya se encuentra registrado";
                    }
                    else
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;
                        ModelError error = JsonConvert.DeserializeObject<ModelError>(mens);
                        return error.Exceptionmessage;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Este metodo hace la peticion http a la api para validar las crendenciales de un usuario
        public string ValidarInicioSesion(ModelUsuario usuario)
        {
            try
            {
                string json = usuario.ToJsonString();
                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {
                        return await client.PostAsync(
                            SERVICE_BASE_URL + "/Login",
                            new StringContent(json, Encoding.UTF8, "application/json")
                        );
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;
                        return mens;
                    }
                    else if (message.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return "El usuario no existe";
                    }
                    else 
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;
                        ModelError error = JsonConvert.DeserializeObject<ModelError>(mens);
                        return "Error: " + error.Exceptionmessage;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Este metodo hace la peticion http a la api para cerrar la sesion de un usuario
        public string CerrarSesion(ModelUsuario usuario)
        {
            try
            {
                string json = usuario.ToJsonString();
                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {
                        return await client.PostAsync(
                            SERVICE_BASE_URL + "/SingOut",
                            new StringContent(json, Encoding.UTF8, "application/json")
                        );
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return "1";
                    }
                    else if (message.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return "El usuario no existe";
                    }
                    else
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;
                        ModelError error = JsonConvert.DeserializeObject<ModelError>(mens);
                        return "Error: " + error.Exceptionmessage;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
