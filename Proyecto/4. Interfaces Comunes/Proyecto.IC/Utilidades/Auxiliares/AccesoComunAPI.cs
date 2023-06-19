/// <summary>
/// Archivo para la clase de metodos genericos de acceso comun
/// </summary>
/// <remarks>
/// Autor: Diego Madrid
/// </remarks> 

namespace Proyecto.IC.Utilidades.Auxiliares
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Proyecto.IC.Enumeraciones;
    using Proyecto.IC.Recursos;
    using Proyecto.IC.Utilidades.Auxiliares.Comunes;
    using Proyecto.IC.Utilidades.Auxiliares.Ejecucion;
    using Proyecto.IC.Utilidades.Genericos;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;
    using UtilitariosNet.Clases.Comunes;

    public class AccesoComunAPI : ControllerBase
    {
        private Guid idCorrelacion;

        public Guid IdCorrelacion
        {
            get { return idCorrelacion; }
        }

        private string cuerpoSolicitud;

        public string CuerpoSolicitud
        {
            get { return cuerpoSolicitud; }
            set { cuerpoSolicitud = value; }
        }

        public AccesoComunAPI()
        {
            idCorrelacion = Guid.NewGuid();
        }

        public T EjecutarTransaccionAPI<T, C>(Func<T> cuerpoEjecutar) where C : class
        {
            T retorno = default;
            cuerpoSolicitud = GetBody(HttpContext.Request);

            retorno = UtilitariosEjecucion.EjecutarTransaccion<T, C>(() =>
            {
                return cuerpoEjecutar();
            }, (ex) =>
            {
                Type t = typeof(T);
                if (cuerpoEjecutar.GetType().GenericTypeArguments[0].Name == t.Name)
                {
                    ex = ex.InnerException.EsNulo() ? ex : ex.GetBaseException();

                    if (ex is ExcepcionControladaException)
                    {
                        if (t == typeof(HttpResponseMessage))
                        {
                            retorno = (T)Activator.CreateInstance(typeof(T));
                            Respuesta<bool> respuesta = new Respuesta<bool>();
                            respuesta.Resultado = false;
                            respuesta.TipoNotificacion = TipoNotificacion.Advertencia;
                            respuesta.Mensajes.Add(ex.Message);
                            retorno.GetType().GetProperty("Content").SetValue(retorno, new BadRequestObjectResult(respuesta), null);
                            return retorno;
                        }

                        retorno = CrearRespuesta<T>(ex, TipoNotificacion.Advertencia);
                    }
                    else
                    {
                        UtilidadesComunes extrarMetodo = new UtilidadesComunes();
                        var metodo = extrarMetodo.ObtenerMetodoEjecucion(typeof(C));
                        //ExcepcionProxy excepcionProxy = new ExcepcionProxy(ConfigurationManager.AppSettings[rcsUtilitarios.UrlServicioExcepciones]);

                        var excepcion = new Excepcion()
                        {
                            IdExcepcion = 1,
                            MensajeExcepcion = ex.Message.ToString(),
                            FechaExcepcion = DateTime.Now,
                            Correlacion = IdCorrelacion,
                            OrigenExcepcion = metodo.ToString(),
                            TipoExcepcion = ex.GetType().ToString(),
                            TrazaExcepcion = ex.ObtenerDetallesExcepcion(true),
                            IdentificadorAplicacion = UtilidadesComunes.TraerIdAplicacion(),
                            DatosEjecucion = CuerpoSolicitud
                        };

                        retorno = CrearRespuestaError<T>(TipoNotificacion.Error, IdCorrelacion);
                    }
                }
                return retorno;
            }, null);

            return retorno;
        }

        public async Task<T> EjecutarTransaccionAPIAsync<T, C>(Func<Task<T>> cuerpoEjecutar) where C : class
        {
            T retorno = default;
            cuerpoSolicitud = GetBody(HttpContext.Request);

            retorno = await UtilitariosEjecucion.EjecutarAsync<T, C>(async () =>
            {
                return await cuerpoEjecutar();
            }, async (ex) =>
            {
                Type t = typeof(T);
                if (cuerpoEjecutar.GetType().GenericTypeArguments[0].Name == t.Name)
                {
                    ex = ex.InnerException.EsNulo() ? ex : ex.GetBaseException();

                    if (ex is ExcepcionControladaException)
                    {
                        retorno = CrearRespuesta<T>(ex, TipoNotificacion.Advertencia);
                    }
                    else
                    {
                        UtilidadesComunes extrarMetodo = new UtilidadesComunes();
                        var metodo = extrarMetodo.ObtenerMetodoEjecucion(typeof(C));
                        //ExcepcionProxy excepcionProxy = new ExcepcionProxy(ConfigurationManager.AppSettings[rcsUtilitarios.UrlServicioExcepciones]);

                        var excepcion = new Excepcion()
                        {
                            IdExcepcion = 1,
                            MensajeExcepcion = ex.Message.ToString(),
                            FechaExcepcion = DateTime.Now,
                            Correlacion = IdCorrelacion,
                            OrigenExcepcion = metodo.ToString(),
                            TipoExcepcion = ex.GetType().ToString(),
                            TrazaExcepcion = ex.ObtenerDetallesExcepcion(true),
                            IdentificadorAplicacion = UtilidadesComunes.TraerIdAplicacion(),
                            DatosEjecucion = CuerpoSolicitud
                        };
                        //Task.Factory.StartNew(() => excepcionProxy.GuardarExcepcion(excepcion));
                        retorno = CrearRespuestaError<T>(TipoNotificacion.Error, IdCorrelacion);
                    }
                }
                return retorno;
            }, null);

            return retorno;
        }

        public Respuesta<T> ValidarModelo<T>(T entity)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(entity);

            bool isValid = Validator.TryValidateObject(entity, validationContext, validationResults, true);

            if (!isValid)
            {
                var errorMessages = new List<string>();
                foreach (var validationResult in validationResults)
                {
                    errorMessages.Add(validationResult.ErrorMessage);
                }

                return new Respuesta<T> { Mensajes = errorMessages, TipoNotificacion = TipoNotificacion.Advertencia, Resultado = false };
            }

            return null; // O devuelve null si la entidad es válida
        }

        private static T CrearRespuesta<T>(Exception ex, TipoNotificacion tipoNotificacion)
        {
            T retorno = (T)Activator.CreateInstance(typeof(T));
            retorno.GetType().GetProperty("Resultado").SetValue(retorno, false, null); ;
            retorno.GetType().GetProperty("TipoNotificacion").SetValue(retorno, tipoNotificacion, null);
            retorno.GetType().GetProperty("Mensajes").SetValue(retorno, new List<string> { ex.Message }, null);
            return retorno;
        }

        private static T CrearRespuestaError<T>(TipoNotificacion tipoNotificacion, Guid Correlacion)
        {
            T retorno = (T)Activator.CreateInstance(typeof(T));
            retorno.GetType().GetProperty("Resultado").SetValue(retorno, false, null); ;
            retorno.GetType().GetProperty("TipoNotificacion").SetValue(retorno, tipoNotificacion, null);
            retorno.GetType().GetProperty("Mensajes").SetValue(retorno, new List<string> { string.Format(rcsUtilitarios.ErrorExcepcionNoControlada, Correlacion) }, null);
            return retorno;
        }

        private static string GetBody(HttpRequest solicitud)
        {
            string cuerpo = string.Empty;

            using (StreamReader lector = new StreamReader(solicitud.Body))
            {
                cuerpo = lector.ReadToEndAsync().Result;

                if (string.IsNullOrEmpty(cuerpo))
                {
                    cuerpo = solicitud.QueryString.ToString();
                }
            }

            return cuerpo;
        }
    }
}