// ------------------------------------------------------------------------------------
// <copyright file="PadresBL.cs" company="DiegoMadrid26@gmail.com">
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
	using Proyecto.Datos.Clases.DAL.Repositorio;
	using Proyecto.IC.Acciones.Repositorio;
	using Proyecto.IC.DTO.Repositorio;
	using Proyecto.IC.Recursos;
	using Proyecto.IC.Utilidades.Genericos;
	using Proyecto.IC.Enumeraciones;

	/// <summary>
	/// Clase con las acciones de negocio de la entidad Padres
	/// </summary>
	public class PadresBL : AccesoComunBL, IPadresNegocioAccion
	{

		#region ATRIBUTOS
		/// <summary>
		/// Objeto para repositorio Padres
		/// <summary>
		/// Objeto para acciones Padres
		/// </summary>
		private Lazy<IPadresRepositorioAccion> padresRepositorioAccion;

		/// <summary>
		/// Objeto para entidad respuesta
		/// </summary>
		Respuesta<IPadresDTO> respuesta;

		#endregion ATRIBUTOS
		#region CONSTRUCTORES
		/// <summary>
		/// Inicializa una nueva instancia de la clase PadresBL
		/// </summary>
		/// <param name="argPadresRepositorioAccion">Acciones entidad Padres</param>
		public PadresBL(Lazy<IPadresRepositorioAccion> argPadresRepositorioAccion = null)
		{
			this.respuesta = new Respuesta<IPadresDTO>();
			this.padresRepositorioAccion = argPadresRepositorioAccion ?? new Lazy<IPadresRepositorioAccion>(() => new PadresDAL());
		}

		#endregion CONSTRUCTORES
		#region METODOS PUBLICOS
		/// <summary>
		/// Metodo consultar lista padres
		/// </summary>
		/// <returns>Respuesta tipo Padres </returns>
		public async Task<Respuesta<IPadresDTO>> ConsultarListaPadresAsync()
		{

			return await this.EjecutarTransaccionBDAsync<Respuesta<IPadresDTO>, PadresBL>(
			System.Transactions.IsolationLevel.ReadUncommitted,
			async () =>
			{
				 respuesta= await this.padresRepositorioAccion.Value.ConsultarListaPadresAsync();
				 respuesta.Resultado = true;
				 respuesta.TipoNotificacion = TipoNotificacion.Exitoso;
				 return respuesta;

			});

		}
		/// <summary>
		/// Metodo consultar por llave padres
		/// </summary>
		/// <param name="padres">Entidad a consultar</param>
		/// <returns>Respuesta tipo Padres </returns>
		public async Task<Respuesta<IPadresDTO>> ConsultarPadresLlaveAsync(IPadresDTO padres)
		{
			return await this.EjecutarTransaccionBDAsync<Respuesta<IPadresDTO>, PadresBL>(
			System.Transactions.IsolationLevel.ReadUncommitted,
			async () =>
			{
				 respuesta= await this.padresRepositorioAccion.Value.ConsultarPadresLlaveAsync(padres);
				 respuesta.Resultado = true;
				 respuesta.TipoNotificacion = TipoNotificacion.Exitoso;
				 return respuesta;

			});
		}

		/// <summary>
		/// Metodo editar padres
		/// </summary>
		/// <param name="padres">Entidad a editar</param>
		/// <returns>Respuesta tipo Padres </returns>
		public async Task<Respuesta<IPadresDTO>> EditarPadresAsync(IPadresDTO padres)
		{
			return await this.EjecutarTransaccionBDAsync<Respuesta<IPadresDTO>, PadresBL>(
			System.Transactions.IsolationLevel.ReadUncommitted,
			async () =>
			{
				 respuesta= await this.padresRepositorioAccion.Value.EditarPadresAsync(padres);
				 respuesta.Resultado = true;
				 respuesta.TipoNotificacion = TipoNotificacion.Exitoso;
				 respuesta.Mensajes.Add(rcsMensajesComunes.MensajeCreacionEdicionExitosa);
				 return respuesta;

			});
		}


		/// <summary>
		/// Metodo eliminar padres
		/// </summary>
		/// <param name="padres">Entidad a eliminar</param>
		/// <returns>Respuesta tipo Padres </returns>
		public async Task<Respuesta<IPadresDTO>> EliminarPadresAsync(int identificacion)
		{
			return await this.EjecutarTransaccionBDAsync<Respuesta<IPadresDTO>, PadresBL>(
			System.Transactions.IsolationLevel.ReadUncommitted,
			async () =>
			{
				 respuesta= await this.padresRepositorioAccion.Value.EliminarPadresAsync(identificacion);
				 respuesta.Resultado = true;
				 respuesta.TipoNotificacion = TipoNotificacion.Exitoso;
				 respuesta.Mensajes.Add(rcsMensajesComunes.MensajeEntidadEliminadaConExito);
				 return respuesta;

			});
		}

		/// <summary>
		/// Metodo guardar padres
		/// </summary>
		/// <param name="padres">Entidad a guardar</param>
		/// <returns>Respuesta tipo Padres </returns>
		public async Task<Respuesta<IPadresDTO>> GuardarPadresAsync(IPadresDTO padres)
		{
			return await this.EjecutarTransaccionBDAsync<Respuesta<IPadresDTO>, PadresBL>(
			System.Transactions.IsolationLevel.ReadUncommitted,
			async () =>
			{
				 respuesta= await this.padresRepositorioAccion.Value.GuardarPadresAsync(padres);
				 respuesta.Resultado = true;
				 respuesta.TipoNotificacion = TipoNotificacion.Exitoso;
				 respuesta.Mensajes.Add(rcsMensajesComunes.MensajeCreacionEdicionExitosa);
				 return respuesta;

			});
		}

		/// <summary>
		/// Metodo Guardar lista padres
		/// </summary>
		/// <param name="listaPadres">Lista de entidades a guardar</param>
		/// <returns>Respuesta tipo Padres </returns>
		public async Task<Respuesta<IPadresDTO>> GuardarListaPadresAsync(List<IPadresDTO> listaPadres)
		{
			return await this.EjecutarTransaccionBDAsync<Respuesta<IPadresDTO>, PadresBL>(
			System.Transactions.IsolationLevel.ReadUncommitted,
			async () =>
			{
				 respuesta= await this.padresRepositorioAccion.Value.GuardarListaPadresAsync(listaPadres);
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

