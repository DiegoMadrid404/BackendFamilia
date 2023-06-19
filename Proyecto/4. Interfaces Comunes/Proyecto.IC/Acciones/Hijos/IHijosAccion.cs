// ------------------------------------------------------------------------------------
// <copyright file="IHijosAccion.cs" company="DiegoMadrid26@gmail.com">
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
	/// Interface que define las acciones que se implmentara en todas las capas de IHijosAccion
	/// </summary>
	public interface IHijosAccion
	{
		/// <summary>
		/// Metodo guardar hijos
		/// </summary>
		/// <param name="hijos">Entidad a guardar</param>
		/// <returns>Respuesta tipo Hijos </returns>
		Task<Respuesta<IHijosDTO>> GuardarHijosAsync(IHijosDTO hijos);
		/// <summary>
		/// Metodo Guardar lista hijos
		/// </summary>
		/// <param name="listaHijos">Lista de entidades a guardar</param>
		/// <returns>Respuesta tipo Hijos </returns>
		Task<Respuesta<IHijosDTO>> GuardarListaHijosAsync(List<IHijosDTO> listaHijos);
		/// <summary>
		/// Metodo editar hijos
		/// </summary>
		/// <param name="hijos">Entidad a editar</param>
		/// <returns>Respuesta tipo Hijos </returns>
		Task<Respuesta<IHijosDTO>> EditarHijosAsync(IHijosDTO hijos);
		/// <summary>
		/// Metodo consultar lista hijos
		/// </summary>
		/// <returns>Respuesta tipo Hijos </returns>
		Task<Respuesta<IHijosDTO>> ConsultarListaHijosAsync();
		/// <summary>
		/// Metodo consultar por llave hijos
		/// </summary>
		/// <param name="hijos">Entidad a consultar</param>
		/// <returns>Respuesta tipo Hijos </returns>
		Task<Respuesta<IHijosDTO>> ConsultarHijosLlaveAsync(IHijosDTO hijos);
		/// <summary>
		/// Metodo eliminar hijos
		/// </summary>
		/// <param name="hijos">Entidad a eliminar</param>
		/// <returns>Respuesta tipo Hijos </returns>
		Task<Respuesta<IHijosDTO>> EliminarHijosAsync(IHijosDTO hijos);
	}


	/// <summary>
	/// Interface que define las acciones de la capa de repositorioIHijosAccion
	/// </summary>
	public interface IHijosRepositorioAccion:IHijosAccion
	{
		/// <summary>
		/// Metodo editar hijos por query 
		/// </summary>
		/// <param name="filtro">Filtro de las entidades </param>
		/// <param name="valor">Entidad a mofificar</param>
		/// <param name="propiedades">Propiedades a modificar</param>
		/// <returns>Respuesta tipo Hijos </returns>
		Task<Respuesta<IHijosDTO>> EditarPorQueryHijosAsync(Expression<Func<IHijosDTO, bool>> filtro, IHijosDTO valor, List<string> propiedades);
		/// <summary>
		/// Metodo consultar lista hijos por filtro 
		/// </summary>
		/// <param name="filtro">Filtro de las entidades </param>
		/// <returns>Respuesta tipo Hijos </returns>
		Task<Respuesta<IHijosDTO>> ConsultarListaHijosPorFiltroAsync(Expression<Func<IHijosDTO, bool>> filtro);
		/// <summary>
		/// Metodo editar  hijos por filtro 
		/// </summary>
		/// <param name="hijos">Entidad con los datos a editar</param>
		/// <param name="propiedades">Propiedades a modificar</param>
		/// <returns>Respuesta tipo Hijos </returns>
		Task<Respuesta<IHijosDTO>> EditarHijosPorFiltroAsync(IHijosDTO hijos, params string[] propiedades);
		/// <summary>
		/// Metodo eliminar lista hijos 
		/// </summary>
		/// <param name="lista">Lista de entidad a eliminar</param>
		/// <returns>Respuesta tipo Hijos </returns>
		Task<Respuesta<IHijosDTO>> EliminarListaHijosAsync(List<IHijosDTO> lista);
		/// <summary>
		/// Metodo editar hijos lista 
		/// </summary>
		/// <param name="lista"> Lista con entidades a modificar</param>
		/// <returns>Respuesta tipo Hijos </returns>
		Task<Respuesta<IHijosDTO>> EditarListaHijosAsync(List<IHijosDTO> lista);
	}


	/// <summary>
	/// Interface que define las acciones de la capa de negocioIHijosAccion
	/// </summary>
	public interface IHijosNegocioAccion:IHijosAccion
	{
	}
}
