// ------------------------------------------------------------------------------------
// <copyright file="IPadresAccion.cs" company="DiegoMadrid26@gmail.com">
// Copyright (c) DiegoMadrid26@gmail.com. All rights reserved.
// </copyright>
// <author>Diego Madrid</author>
// ------------------------------------------------------------------------------------
namespace Proyecto.IC.Acciones.Repositorio
{
	using System;
	using System.Collections.Generic;
	using System.Linq.Expressions;
	using System.Threading.Tasks;
	using Proyecto.IC.DTO.Repositorio;
	using Proyecto.IC.Utilidades.Genericos;
	using Proyecto.IC.Utilidades.Auxiliares;

	/// <summary>
	/// Interface que define las acciones que se implmentara en todas las capas de IPadresAccion
	/// </summary>
	public interface IPadresAccion
	{
		/// <summary>
		/// Metodo guardar padres
		/// </summary>
		/// <param name="padres">Entidad a guardar</param>
		/// <returns>Respuesta tipo Padres </returns>
		Task<Respuesta<IPadresDTO>> GuardarPadresAsync(IPadresDTO padres);
		/// <summary>
		/// Metodo Guardar lista padres
		/// </summary>
		/// <param name="listaPadres">Lista de entidades a guardar</param>
		/// <returns>Respuesta tipo Padres </returns>
		Task<Respuesta<IPadresDTO>> GuardarListaPadresAsync(List<IPadresDTO> listaPadres);
		/// <summary>
		/// Metodo editar padres
		/// </summary>
		/// <param name="padres">Entidad a editar</param>
		/// <returns>Respuesta tipo Padres </returns>
		Task<Respuesta<IPadresDTO>> EditarPadresAsync(IPadresDTO padres);
		/// <summary>
		/// Metodo consultar lista padres
		/// </summary>
		/// <returns>Respuesta tipo Padres </returns>
		Task<Respuesta<IPadresDTO>> ConsultarListaPadresAsync();
		/// <summary>
		/// Metodo consultar por llave padres
		/// </summary>
		/// <param name="padres">Entidad a consultar</param>
		/// <returns>Respuesta tipo Padres </returns>
		Task<Respuesta<IPadresDTO>> ConsultarPadresLlaveAsync(IPadresDTO padres);
		/// <summary>
		/// Metodo eliminar padres
		/// </summary>
		/// <param name="padres">Entidad a eliminar</param>
		/// <returns>Respuesta tipo Padres </returns>
		Task<Respuesta<IPadresDTO>> EliminarPadresAsync(IPadresDTO padres);
	}


	/// <summary>
	/// Interface que define las acciones de la capa de repositorioIPadresAccion
	/// </summary>
	public interface IPadresRepositorioAccion:IPadresAccion
	{
		/// <summary>
		/// Metodo editar padres por query 
		/// </summary>
		/// <param name="filtro">Filtro de las entidades </param>
		/// <param name="valor">Entidad a mofificar</param>
		/// <param name="propiedades">Propiedades a modificar</param>
		/// <returns>Respuesta tipo Padres </returns>
		Task<Respuesta<IPadresDTO>> EditarPorQueryPadresAsync(Expression<Func<IPadresDTO, bool>> filtro, IPadresDTO valor, List<string> propiedades);
		/// <summary>
		/// Metodo consultar lista padres por filtro 
		/// </summary>
		/// <param name="filtro">Filtro de las entidades </param>
		/// <returns>Respuesta tipo Padres </returns>
		Task<Respuesta<IPadresDTO>> ConsultarListaPadresPorFiltroAsync(Expression<Func<IPadresDTO, bool>> filtro);
		/// <summary>
		/// Metodo editar  padres por filtro 
		/// </summary>
		/// <param name="padres">Entidad con los datos a editar</param>
		/// <param name="propiedades">Propiedades a modificar</param>
		/// <returns>Respuesta tipo Padres </returns>
		Task<Respuesta<IPadresDTO>> EditarPadresPorFiltroAsync(IPadresDTO padres, params string[] propiedades);
		/// <summary>
		/// Metodo eliminar lista padres 
		/// </summary>
		/// <param name="lista">Lista de entidad a eliminar</param>
		/// <returns>Respuesta tipo Padres </returns>
		Task<Respuesta<IPadresDTO>> EliminarListaPadresAsync(List<IPadresDTO> lista);
		/// <summary>
		/// Metodo editar padres lista 
		/// </summary>
		/// <param name="lista"> Lista con entidades a modificar</param>
		/// <returns>Respuesta tipo Padres </returns>
		Task<Respuesta<IPadresDTO>> EditarListaPadresAsync(List<IPadresDTO> lista);
	}


	/// <summary>
	/// Interface que define las acciones de la capa de negocioIPadresAccion
	/// </summary>
	public interface IPadresNegocioAccion:IPadresAccion
	{
	}
}
