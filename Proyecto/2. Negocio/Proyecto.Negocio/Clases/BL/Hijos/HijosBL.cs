// ------------------------------------------------------------------------------------
// <copyright file="HijosBL.cs" company="DiegoMadrid26@gmail.com">
// Copyright (c) DiegoMadrid26@gmail.com. All rights reserved.
// </copyright>
// <author>Diego Madrid</author>
// ------------------------------------------------------------------------------------
namespace Proyecto.Negocio.Clases.BL
{
    using System;
    using System.Collections.Generic;
    using Proyecto.Negocio.Utilidades;

    using System.Threading.Tasks;
    using Proyecto.IC.Acciones.Repositorio;
    using Proyecto.IC.DTO.Repositorio;
    using Proyecto.IC.Recursos;
    using Proyecto.IC.Utilidades.Genericos;
    using Proyecto.IC.Enumeraciones;
    using Proyecto.Datos.Clases.DAL.Repositorio;
    using Proyecto.Datos.Contexto.Repositorio;
    using System.Linq;
    using Proyecto.Negocio.Recursos;

    /// <summary>
    /// Clase con las acciones de negocio de la entidad Hijos
    /// </summary>
    public class HijosBL : AccesoComunBL, IHijosNegocioAccion
    {

        #region ATRIBUTOS
        /// <summary>
        /// Objeto para repositorio Hijos
        /// <summary>
        /// Objeto para acciones Hijos
        /// </summary>
        private Lazy<IHijosRepositorioAccion> hijosRepositorioAccion;
        private Lazy<IPadresRepositorioAccion> padresRepositorioAccion;

        /// <summary>
        /// Objeto para entidad respuesta
        /// </summary>
        Respuesta<IHijosDTO> respuesta;

        #endregion ATRIBUTOS
        #region CONSTRUCTORES
        /// <summary>
        /// Inicializa una nueva instancia de la clase HijosBL
        /// </summary>
        /// <param name="argHijosRepositorioAccion">Acciones entidad Hijos</param>
        public HijosBL(Lazy<IHijosRepositorioAccion> argHijosRepositorioAccion = null,
                       Lazy<IPadresRepositorioAccion> argpadresRepositorioAccion = null)

        {
            this.respuesta = new Respuesta<IHijosDTO>();
            this.hijosRepositorioAccion = argHijosRepositorioAccion ?? new Lazy<IHijosRepositorioAccion>(() => new HijosDAL());
            this.padresRepositorioAccion = argpadresRepositorioAccion ?? new Lazy<IPadresRepositorioAccion>(() => new PadresDAL());
        }

        #endregion CONSTRUCTORES
        #region METODOS PUBLICOS
        /// <summary>
        /// Metodo consultar lista hijos
        /// </summary>
        /// <returns>Respuesta tipo Hijos </returns>
        public async Task<Respuesta<IHijosDTO>> ConsultarListaHijosAsync()
        {

            return await this.EjecutarTransaccionBDAsync<Respuesta<IHijosDTO>, HijosBL>(
            System.Transactions.IsolationLevel.ReadUncommitted,
            async () =>
            {
                respuesta = await this.hijosRepositorioAccion.Value.ConsultarListaHijosAsync();
                respuesta.Resultado = true;
                respuesta.TipoNotificacion = TipoNotificacion.Exitoso;
                return respuesta;

            });

        }
        /// <summary>
        /// Metodo consultar por llave hijos
        /// </summary>
        /// <param name="hijos">Entidad a consultar</param>
        /// <returns>Respuesta tipo Hijos </returns>
        public async Task<Respuesta<IHijosDTO>> ConsultarHijosLlaveAsync(IHijosDTO hijos)
        {
            return await this.EjecutarTransaccionBDAsync<Respuesta<IHijosDTO>, HijosBL>(
            System.Transactions.IsolationLevel.ReadUncommitted,
            async () =>
            {
                respuesta = await this.hijosRepositorioAccion.Value.ConsultarHijosLlaveAsync(hijos);
                respuesta.Resultado = true;
                respuesta.TipoNotificacion = TipoNotificacion.Exitoso;
                return respuesta;

            });
        }

        /// <summary>
        /// Metodo editar hijos
        /// </summary>
        /// <param name="hijos">Entidad a editar</param>
        /// <returns>Respuesta tipo Hijos </returns>
        public async Task<Respuesta<IHijosDTO>> EditarHijosAsync(IHijosDTO hijos)
        {
            return await this.EjecutarTransaccionBDAsync<Respuesta<IHijosDTO>, HijosBL>(
            System.Transactions.IsolationLevel.ReadUncommitted,
            async () =>
            {
                Task<bool> existePadre = this.ConsultarIdentifiacionPadresExisteAsync(hijos.IdentificacionPadre);
                Task<bool> existeMaddre = this.ConsultarIdentifiacionPadresExisteAsync(hijos.IdentificacionMadre);
                Task.WaitAll(existePadre, existeMaddre);
                if (!existeMaddre.Result || !existePadre.Result)
                {
                    respuesta.Resultado = false;
                    respuesta.TipoNotificacion = TipoNotificacion.Advertencia;
                    if (!existeMaddre.Result)
                    {
                        respuesta.Mensajes.Add(rcsMensajesNegocio.MadreNoExiste);
                    }
                    if (!existePadre.Result)
                    {
                        respuesta.Mensajes.Add(rcsMensajesNegocio.PadreNoExiste);
                    }
                    return respuesta;
                }
                respuesta = await this.hijosRepositorioAccion.Value.EditarHijosAsync(hijos);
                respuesta.Resultado = true;
                respuesta.TipoNotificacion = TipoNotificacion.Exitoso;
                respuesta.Mensajes.Add(rcsMensajesComunes.MensajeCreacionEdicionExitosa);
                return respuesta;

            });
        }


        /// <summary>
        /// Metodo eliminar hijos
        /// </summary>
        /// <param name="hijos">Entidad a eliminar</param>
        /// <returns>Respuesta tipo Hijos </returns>
        public async Task<Respuesta<IHijosDTO>> EliminarHijosAsync(int identificacion)
        {
            return await this.EjecutarTransaccionBDAsync<Respuesta<IHijosDTO>, HijosBL>(
            System.Transactions.IsolationLevel.ReadUncommitted,
            async () =>
            {
                respuesta = await this.hijosRepositorioAccion.Value.EliminarHijosAsync(identificacion);
                respuesta.Resultado = true;
                respuesta.TipoNotificacion = TipoNotificacion.Exitoso;
                respuesta.Mensajes.Add(rcsMensajesComunes.MensajeEntidadEliminadaConExito);
                return respuesta;

            });
        }

        /// <summary>
        /// Metodo guardar hijos
        /// </summary>
        /// <param name="hijos">Entidad a guardar</param>
        /// <returns>Respuesta tipo Hijos </returns>
        public async Task<Respuesta<IHijosDTO>> GuardarHijosAsync(IHijosDTO hijos)
        {
            return await this.EjecutarTransaccionBDAsync<Respuesta<IHijosDTO>, HijosBL>(
            System.Transactions.IsolationLevel.ReadUncommitted,
            async () =>
            {
                Task<bool> existePadre = this.ConsultarIdentifiacionPadresExisteAsync(hijos.IdentificacionPadre);
                Task<bool> existeMaddre = this.ConsultarIdentifiacionPadresExisteAsync(hijos.IdentificacionMadre);
                Task.WaitAll(existePadre, existeMaddre);
                if (!existeMaddre.Result || !existePadre.Result)
                {
                    respuesta.Resultado = false;
                    respuesta.TipoNotificacion = TipoNotificacion.Advertencia;
                    if (!existeMaddre.Result)
                    {
                        respuesta.Mensajes.Add(rcsMensajesNegocio.MadreNoExiste);
                    }
                    if (!existePadre.Result)
                    {
                        respuesta.Mensajes.Add(rcsMensajesNegocio.PadreNoExiste);
                    }
                    return respuesta;
                }
                respuesta = await this.hijosRepositorioAccion.Value.GuardarHijosAsync(hijos);
                respuesta.Resultado = true;
                respuesta.TipoNotificacion = TipoNotificacion.Exitoso;
                respuesta.Mensajes.Add(rcsMensajesComunes.MensajeCreacionEdicionExitosa);
                return respuesta;

            });
        }

        private async Task<bool> ConsultarIdentifiacionPadresExisteAsync(int? identificacion)
        {
            if (identificacion.HasValue)
            {
                return this.padresRepositorioAccion.Value.ConsultarListaPadresPorFiltroAsync(x => x.Identificacion == identificacion).Result.Entidades.Any();
            }
            return true;
        }

        /// <summary>
        /// Metodo Guardar lista hijos
        /// </summary>
        /// <param name="listaHijos">Lista de entidades a guardar</param>
        /// <returns>Respuesta tipo Hijos </returns>
        public async Task<Respuesta<IHijosDTO>> GuardarListaHijosAsync(List<IHijosDTO> listaHijos)
        {
            return await this.EjecutarTransaccionBDAsync<Respuesta<IHijosDTO>, HijosBL>(
            System.Transactions.IsolationLevel.ReadUncommitted,
            async () =>
            {
                respuesta = await this.hijosRepositorioAccion.Value.GuardarListaHijosAsync(listaHijos);
                respuesta.Resultado = true;
                respuesta.TipoNotificacion = TipoNotificacion.Exitoso;
                respuesta.Mensajes.Add(rcsMensajesComunes.MensajeCreacionEdicionExitosa);
                return respuesta;

            });
        }
        #endregion METODOS PUBLICOS
        #region METODOS PRIVADOS
        #endregion METODOS PRIVADOS
    }
}

