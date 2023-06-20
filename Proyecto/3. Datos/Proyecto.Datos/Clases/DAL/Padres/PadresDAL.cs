// ------------------------------------------------------------------------------------
// <copyright file="PadresDAL.cs" company="DiegoMadrid26@gmail.com">
// Copyright (c) DiegoMadrid26@gmail.com. All rights reserved.
// </copyright>
// <author>Diego Madrid</author>
// ------------------------------------------------------------------------------------
namespace Proyecto.Datos.Clases.DAL.Repositorio
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Threading.Tasks;
	using Proyecto.Datos.Contexto;
	using Proyecto.Datos.Contexto.Repositorio;
	using Proyecto.IC.Acciones.Repositorio;
	using Proyecto.IC.DTO.Repositorio;
	using Proyecto.Datos.Utilidades;
	using Proyecto.IC.Utilidades.Genericos;
	using Proyecto.IC.Utilidades.Auxiliares;

	/// <summary>
	/// Clase con las acciones de repositorio para la entidad Padres
	/// </summary>
	public class PadresDAL : AccesoComunDAL<ContextoProyecto>, IPadresRepositorioAccion
	{
		/// <summary>
		/// Objeto para entidad respuesta
		/// </summary>
		Respuesta<IPadresDTO> respuesta;

		/// <summary>
		/// Objeto para repositorio Padres
		/// </summary>
		RepositorioGenerico<Padres> repositorio;

		/// <summary>
		/// Inicializa una nueva instancia de la clase PadresDAL
		/// </summary>
		public PadresDAL()
		{
			this.respuesta = new Respuesta<IPadresDTO>();
			this.repositorio = new RepositorioGenerico<Padres>(ContextoBD);
		}

		/// <summary>
		/// Metodo editar padres
		/// </summary>
		/// <param name="padres">Entidad a editar</param>
		/// <returns>Respuesta tipo Padres </returns>
		public async Task<Respuesta<IPadresDTO>> EditarPadresAsync(IPadresDTO padres)
		{
			return await this.EjecutarTransaccionAsync<Respuesta<IPadresDTO>, PadresDAL>(async () =>
			{
				Padres PadresEntidad = repositorio.BuscarPor(entidad => entidad
					.Identificacion == padres.Identificacion).FirstOrDefault();
				Mapeador.MapearObjetosPorPropiedad(padres, PadresEntidad);
				repositorio.Editar(PadresEntidad);
				repositorio.Guardar();
				return respuesta;
			});
		}

		/// <summary>
		/// Metodo editar  padres por filtro 
		/// </summary>
		/// <param name="padres">Entidad con los datos a editar</param>
		/// <param name="propiedades">Propiedades a modificar</param>
		/// <returns>Respuesta tipo Padres </returns>
		public async Task<Respuesta<IPadresDTO>> EditarPadresPorFiltroAsync(IPadresDTO padres, params string[] propiedades)
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IPadresDTO>, PadresDAL>(async () =>
            {
                Padres padresEntidad = repositorio.BuscarPor(entidad => entidad
                .Identificacion == padres.Identificacion).FirstOrDefault();
                Mapeador.MapearObjetosPorPropiedadPorFiltro(padres, padresEntidad, propiedades);
                repositorio.Editar(padresEntidad);
                      repositorio.Guardar();
                return respuesta;
            });
        }


		/// <summary>
		/// Metodo editar padres por query 
		/// </summary>
		/// <param name="filtro">Filtro de las entidades </param>
		/// <param name="valor">Entidad a mofificar</param>
		/// <param name="propiedades">Propiedades a modificar</param>
		/// <returns>Respuesta tipo Padres </returns>
		public async Task<Respuesta<IPadresDTO>> EditarPorQueryPadresAsync(Expression<Func<IPadresDTO, bool>> filtro, IPadresDTO valor, List<string> propiedades)
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IPadresDTO>, PadresDAL>(async () =>
            {
          Padres PadresEntidad = Mapeador.MapearEntidadDTO(valor, new Padres());
                Expression<Func<Padres, bool>> filtros = Mapeador.MapearExpresion<IPadresDTO, Padres>(filtro);
                await repositorio.EditarPorQueryAsync(filtros, PadresEntidad, propiedades);
                await repositorio.GuardarAsync();
                return respuesta;
            });
        }


		/// <summary>
		/// Metodo editar padres lista 
		/// </summary>
		/// <param name="lista"> Lista con entidades a modificar</param>
		/// <returns>Respuesta tipo Padres </returns>
		public async Task<Respuesta<IPadresDTO>> EditarListaPadresAsync(List<IPadresDTO> lista)
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IPadresDTO>, PadresDAL>(async () =>
            {
                List<Padres> listaPadres = new List<Padres>();
                listaPadres = Mapeador.MapearALista<IPadresDTO, Padres>(lista);
               await repositorio.EditarListaAsync(listaPadres);
               await repositorio.GuardarAsync();
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
            return await this.EjecutarTransaccionAsync<Respuesta<IPadresDTO>, PadresDAL>(async () =>
            {
				Padres PadresEntidad = repositorio.BuscarPor(entidad => entidad
					.Identificacion == identificacion).FirstOrDefault();
 				repositorio.Eliminar(PadresEntidad);
                repositorio.Guardar();
                return respuesta;
            });
        }


		/// <summary>
		/// Metodo eliminar lista padres 
		/// </summary>
		/// <param name="lista">Lista de entidad a eliminar</param>
		/// <returns>Respuesta tipo Padres </returns>
        public async Task<Respuesta<IPadresDTO>> EliminarListaPadresAsync(List<IPadresDTO> lista)
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IPadresDTO>, PadresDAL>(async () =>
            {
                List<Padres> listaPadres = new List<Padres>();
                listaPadres = Mapeador.MapearALista<IPadresDTO, Padres>(lista);
               await repositorio.EliminarListaAsync(listaPadres);
               await repositorio.GuardarAsync();
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
            return await this.EjecutarTransaccionAsync<Respuesta<IPadresDTO>, PadresDAL>(async () =>
            {
                Padres PadresEntidad = Mapeador.MapearEntidadDTO(padres, new Padres());
               await repositorio.AgregarAsync(PadresEntidad);
               await repositorio.GuardarAsync();
                respuesta.Entidades.Add(PadresEntidad);
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
            return await this.EjecutarTransaccionAsync<Respuesta<IPadresDTO>, PadresDAL>(async () =>
            {
                List<Padres> listaPadresEntidad = Mapeador.MapearALista<IPadresDTO, Padres>(listaPadres);
               await repositorio.AgregarListaAsync(listaPadresEntidad);
                respuesta.Entidades.AddRange(listaPadresEntidad);
                return respuesta;
            });
        }

		/// <summary>
		/// Metodo consultar lista padres
		/// </summary>
		/// <returns>Respuesta tipo Padres </returns>
        public async Task<Respuesta<IPadresDTO>> ConsultarListaPadresAsync()
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IPadresDTO>, PadresDAL>(async () =>
            {
                respuesta.Entidades = repositorio.BuscarTodos().ToList<IPadresDTO>();
                return respuesta;

            });
        }

		/// <summary>
		/// Metodo consultar lista padres por filtro 
		/// </summary>
		/// <param name="padres">Entidad con los datos a filtrar</param>
		/// <param name="filtro">Filtro de las entidades </param>
		/// <returns>Respuesta tipo Padres </returns>
        public async Task<Respuesta<IPadresDTO>> ConsultarListaPadresPorFiltroAsync(Expression<Func<IPadresDTO, bool>> filtro)
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IPadresDTO>, PadresDAL>(async () =>
            {
                respuesta.Entidades = repositorio.BuscarPor(Mapeador.MapearExpresion<IPadresDTO, Padres>(filtro)).ToList<IPadresDTO>();
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
            return await this.EjecutarTransaccionAsync<Respuesta<IPadresDTO>, PadresDAL>(async () =>
            {
                respuesta.Entidades = (from entidad in ContextoBD.Padres
                                       where entidad.Identificacion == padres.Identificacion
                                       select entidad).ToList<IPadresDTO>();

                return respuesta;

            });
        }
    }
}

