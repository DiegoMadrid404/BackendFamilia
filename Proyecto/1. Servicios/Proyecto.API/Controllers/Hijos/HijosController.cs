// ------------------------------------------------------------------------------------
// <copyright file="HijosController.cs" company="DiegoMadrid26@gmail.com">
// Copyright (c) DiegoMadrid26@gmail.com. All rights reserved.
// </copyright>
// <author>Diego Madrid</author>
// ------------------------------------------------------------------------------------
namespace Proyecto.API.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Proyecto.IC.Utilidades.Auxiliares;
    using Proyecto.IC.Utilidades.Genericos;
    using Proyecto.API.Models.Repositorio;
    using Proyecto.IC.Acciones.Repositorio;
    using Proyecto.Negocio.Clases.BL;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Collections.Generic;

    /// <summary>
    /// Clase con las capaciades Rest de la entidad Hijos
    /// </summary>
    [Route("api/Hijos")]
    public class HijosController : AccesoComunAPI
    {


        /// <summary>
        /// Objeto para negocio Hijos
        /// </summary>
        private Lazy<IHijosNegocioAccion> negocioHijos;


        /// <summary>
        /// Inicializa una nueva instancia de la clase HijosController
        /// </summary>
        public HijosController()
        {
            this.negocioHijos = new Lazy<IHijosNegocioAccion>(
                                        () => new HijosBL());
        }

        /// <summary>
        /// Metodo consultar lista hijos
        /// </summary>
        /// <returns>Respuesta tipo Hijos </returns>
        [HttpGet]
        [Route("ConsultarListaHijos")]
        public async Task<Respuesta<Hijos>> ConsultarListaHijos()
        {
            return await this.EjecutarTransaccionAPI<Task<Respuesta<Hijos>>, HijosController>(async () =>
            {
                return Mapeador.MapearObjetoPorJson<Respuesta<Hijos>>(await negocioHijos.Value.ConsultarListaHijosAsync());
            });
        }

        /// <summary>
        /// Metodo consultar por llave hijos
        /// </summary>
        /// <param name="hijos">Entidad a consultar</param>
        /// <returns>Respuesta tipo Hijos </returns>
        [HttpPost]
        [Route("ConsultarHijosLlave")]
        public async Task<Respuesta<Hijos>> ConsultarHijosLlave([FromBody] Hijos hijos)
        {
            return await this.EjecutarTransaccionAPI<Task<Respuesta<Hijos>>, HijosController>(async () =>
            {
                return Mapeador.MapearObjetoPorJson<Respuesta<Hijos>>(await negocioHijos.Value.ConsultarHijosLlaveAsync(hijos));
            });
        }

        /// <summary>
        /// Metodo guardar hijos
        /// </summary>
        /// <param name="hijos">Entidad a guardar</param>
        /// <returns>Respuesta tipo Hijos </returns>
        [HttpPost]
        [Route("GuardarHijos")]
        [ValidarModelo]
        public async Task<Respuesta<Hijos>> GuardarHijos([FromBody] Hijos hijos)
        {
            return await this.EjecutarTransaccionAPI<Task<Respuesta<Hijos>>, HijosController>(async () =>
            {
                return Mapeador.MapearObjetoPorJson<Respuesta<Hijos>>(await negocioHijos.Value.GuardarHijosAsync(hijos));
            });
        }

        /// <summary>
        /// Metodo editar hijos
        /// </summary>
        /// <param name="hijos">Entidad a editar</param>
        /// <returns>Respuesta tipo Hijos </returns>
        [HttpPut]
        [Route("EditarHijos")]
        [ValidarModelo]
        public async Task<Respuesta<Hijos>> EditarHijos([FromBody] Hijos hijos)
        {
            return await this.EjecutarTransaccionAPI<Task<Respuesta<Hijos>>, HijosController>(async () =>
            {
                return Mapeador.MapearObjetoPorJson<Respuesta<Hijos>>(await negocioHijos.Value.EditarHijosAsync(hijos));
            });
        }

        /// <summary>
        /// Metodo eliminar hijos
        /// </summary>
        /// <param name="hijos">Entidad a eliminar</param>
        /// <returns>Respuesta tipo Hijos </returns>
        [HttpDelete]
        [Route("EliminarHijos/{identificacion}")]
        public async Task<Respuesta<Hijos>> EliminarHijos(int identificacion)
        {
            return await this.EjecutarTransaccionAPI<Task<Respuesta<Hijos>>, HijosController>(async () =>
            {
                return Mapeador.MapearObjetoPorJson<Respuesta<Hijos>>(await negocioHijos.Value.EliminarHijosAsync(identificacion));
            });
        }
    }
}

