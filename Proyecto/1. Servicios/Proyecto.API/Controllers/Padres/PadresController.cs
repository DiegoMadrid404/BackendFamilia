// ------------------------------------------------------------------------------------
// <copyright file="PadresController.cs" company="DiegoMadrid26@gmail.com">
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
	
	/// <summary>
	/// Clase con las capaciades Rest de la entidad Padres
	/// </summary>
	[Route("api/Padres")]
	public class PadresController : AccesoComunAPI
	{


		/// <summary>
		/// Objeto para negocio Padres
		/// </summary>
		private Lazy<IPadresNegocioAccion> negocioPadres;

		
		/// <summary>
		/// Inicializa una nueva instancia de la clase PadresController
		/// </summary>
		public PadresController()
		{
			this.negocioPadres = new Lazy<IPadresNegocioAccion>(
										() => new PadresBL());
		}
		
		/// <summary>
		/// Metodo consultar lista padres
		/// </summary>
		/// <returns>Respuesta tipo Padres </returns>
		[HttpGet]
		[Route("ConsultarListaPadres")]
		public async Task<Respuesta<Padres>> ConsultarListaPadres()
		{
			return await this.EjecutarTransaccionAPI<Task<Respuesta<Padres>>, PadresController>(async () =>
			{
				return Mapeador.MapearObjetoPorJson<Respuesta<Padres>>(await negocioPadres.Value.ConsultarListaPadresAsync());
			});
		}
		
		/// <summary>
		/// Metodo consultar por llave padres
		/// </summary>
		/// <param name="padres">Entidad a consultar</param>
		/// <returns>Respuesta tipo Padres </returns>
		[HttpPost]
		[Route("ConsultarPadresLlave")]
		public async Task<Respuesta<Padres>> ConsultarPadresLlave(Padres padres)
		{
			return await this.EjecutarTransaccionAPI<Task<Respuesta<Padres>>, PadresController>(async () =>
			{
				return Mapeador.MapearObjetoPorJson<Respuesta<Padres>>(await negocioPadres.Value.ConsultarPadresLlaveAsync(padres));
			});
		}
		
		/// <summary>
		/// Metodo guardar padres
		/// </summary>
		/// <param name="padres">Entidad a guardar</param>
		/// <returns>Respuesta tipo Padres </returns>
		[HttpPost]
		[Route("GuardarPadres")]
        [ValidarModelo]
        public async Task<Respuesta<Padres>> GuardarPadres(Padres padres)
		{
			return await this.EjecutarTransaccionAPI<Task<Respuesta<Padres>>, PadresController>(async () =>
			{
				return Mapeador.MapearObjetoPorJson<Respuesta<Padres>>(await negocioPadres.Value.GuardarPadresAsync(padres));
			});
		}
		
		/// <summary>
		/// Metodo editar padres
		/// </summary>
		/// <param name="padres">Entidad a editar</param>
		/// <returns>Respuesta tipo Padres </returns>
		[HttpPut]
		[Route("EditarPadres")]
        [ValidarModelo]
        public async Task<Respuesta<Padres>> EditarPadres(Padres padres)
		{
			return await this.EjecutarTransaccionAPI<Task<Respuesta<Padres>>, PadresController>(async () =>
			{
				return Mapeador.MapearObjetoPorJson<Respuesta<Padres>>(await negocioPadres.Value.EditarPadresAsync(padres));
			});
		}
		
		/// <summary>
		/// Metodo eliminar padres
		/// </summary>
		/// <param name="padres">Entidad a eliminar</param>
		/// <returns>Respuesta tipo Padres </returns>
		[HttpDelete]
		[Route("EliminarPadres")]
		public async Task<Respuesta<Padres>> EliminarPadres(Padres padres)
		{
			return await this.EjecutarTransaccionAPI<Task<Respuesta<Padres>>, PadresController>(async () =>
			{
				return Mapeador.MapearObjetoPorJson<Respuesta<Padres>>(await negocioPadres.Value.EliminarPadresAsync(padres));
			});
		}
	}
}

