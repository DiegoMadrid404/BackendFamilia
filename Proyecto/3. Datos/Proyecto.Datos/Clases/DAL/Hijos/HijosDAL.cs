// ------------------------------------------------------------------------------------
// <copyright file="HijosDAL.cs" company="DiegoMadrid26@gmail.com">
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
	/// Clase con las acciones de repositorio para la entidad Hijos
	/// </summary>
	public class HijosDAL : AccesoComunDAL<ContextoProyecto>, IHijosRepositorioAccion
	{
		/// <summary>
		/// Objeto para entidad respuesta
		/// </summary>
		Respuesta<IHijosDTO> respuesta;

		/// <summary>
		/// Objeto para repositorio Hijos
		/// </summary>
		RepositorioGenerico<Hijos> repositorio;

		/// <summary>
		/// Inicializa una nueva instancia de la clase HijosDAL
		/// </summary>
		public HijosDAL()
		{
			this.respuesta = new Respuesta<IHijosDTO>();
			this.repositorio = new RepositorioGenerico<Hijos>(ContextoBD);
		}

		/// <summary>
		/// Metodo editar hijos
		/// </summary>
		/// <param name="hijos">Entidad a editar</param>
		/// <returns>Respuesta tipo Hijos </returns>
		public async Task<Respuesta<IHijosDTO>> EditarHijosAsync(IHijosDTO hijos)
		{
			return await this.EjecutarTransaccionAsync<Respuesta<IHijosDTO>, HijosDAL>(async () =>
			{
				Hijos HijosEntidad = repositorio.BuscarPor(entidad => entidad
					.Identificacion == hijos.Identificacion).FirstOrDefault();
				Mapeador.MapearObjetosPorPropiedad(hijos, HijosEntidad);
				repositorio.Editar(HijosEntidad);
				repositorio.Guardar();
				return respuesta;
			});
		}

		/// <summary>
		/// Metodo editar  hijos por filtro 
		/// </summary>
		/// <param name="hijos">Entidad con los datos a editar</param>
		/// <param name="propiedades">Propiedades a modificar</param>
		/// <returns>Respuesta tipo Hijos </returns>
		public async Task<Respuesta<IHijosDTO>> EditarHijosPorFiltroAsync(IHijosDTO hijos, params string[] propiedades)
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IHijosDTO>, HijosDAL>(async () =>
            {
                Hijos hijosEntidad = repositorio.BuscarPor(entidad => entidad
                .Identificacion == hijos.Identificacion).FirstOrDefault();
                Mapeador.MapearObjetosPorPropiedadPorFiltro(hijos, hijosEntidad, propiedades);
                repositorio.Editar(hijosEntidad);
                      repositorio.Guardar();
                return respuesta;
            });
        }


		/// <summary>
		/// Metodo editar hijos por query 
		/// </summary>
		/// <param name="filtro">Filtro de las entidades </param>
		/// <param name="valor">Entidad a mofificar</param>
		/// <param name="propiedades">Propiedades a modificar</param>
		/// <returns>Respuesta tipo Hijos </returns>
		public async Task<Respuesta<IHijosDTO>> EditarPorQueryHijosAsync(Expression<Func<IHijosDTO, bool>> filtro, IHijosDTO valor, List<string> propiedades)
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IHijosDTO>, HijosDAL>(async () =>
            {
          Hijos HijosEntidad = Mapeador.MapearEntidadDTO(valor, new Hijos());
                Expression<Func<Hijos, bool>> filtros = Mapeador.MapearExpresion<IHijosDTO, Hijos>(filtro);
                await repositorio.EditarPorQueryAsync(filtros, HijosEntidad, propiedades);
                await repositorio.GuardarAsync();
                return respuesta;
            });
        }


		/// <summary>
		/// Metodo editar hijos lista 
		/// </summary>
		/// <param name="lista"> Lista con entidades a modificar</param>
		/// <returns>Respuesta tipo Hijos </returns>
		public async Task<Respuesta<IHijosDTO>> EditarListaHijosAsync(List<IHijosDTO> lista)
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IHijosDTO>, HijosDAL>(async () =>
            {
                List<Hijos> listaHijos = new List<Hijos>();
                listaHijos = Mapeador.MapearALista<IHijosDTO, Hijos>(lista);
               await repositorio.EditarListaAsync(listaHijos);
               await repositorio.GuardarAsync();
                return respuesta;
            });
        }

		/// <summary>
		/// Metodo eliminar hijos
		/// </summary>
		/// <param name="hijos">Entidad a eliminar</param>
		/// <returns>Respuesta tipo Hijos </returns>
        public async Task<Respuesta<IHijosDTO>> EliminarHijosAsync(int identificacion )
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IHijosDTO>, HijosDAL>(async () =>
            {
				Hijos HijosEntidad = repositorio.BuscarPor(entidad => entidad
					.Identificacion == identificacion).FirstOrDefault();
  				repositorio.Eliminar(HijosEntidad);
                repositorio.Guardar();
                return respuesta;
            });
        }


		/// <summary>
		/// Metodo eliminar lista hijos 
		/// </summary>
		/// <param name="lista">Lista de entidad a eliminar</param>
		/// <returns>Respuesta tipo Hijos </returns>
        public async Task<Respuesta<IHijosDTO>> EliminarListaHijosAsync(List<IHijosDTO> lista)
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IHijosDTO>, HijosDAL>(async () =>
            {
                List<Hijos> listaHijos = new List<Hijos>();
                listaHijos = Mapeador.MapearALista<IHijosDTO, Hijos>(lista);
               await repositorio.EliminarListaAsync(listaHijos);
               await repositorio.GuardarAsync();
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
            return await this.EjecutarTransaccionAsync<Respuesta<IHijosDTO>, HijosDAL>(async () =>
            {
                Hijos HijosEntidad = Mapeador.MapearEntidadDTO(hijos, new Hijos());
               await repositorio.AgregarAsync(HijosEntidad);
               await repositorio.GuardarAsync();
                respuesta.Entidades.Add(HijosEntidad);
                return respuesta;

            });
        }

		/// <summary>
		/// Metodo Guardar lista hijos
		/// </summary>
		/// <param name="listaHijos">Lista de entidades a guardar</param>
		/// <returns>Respuesta tipo Hijos </returns>
        public async Task<Respuesta<IHijosDTO>> GuardarListaHijosAsync(List<IHijosDTO> listaHijos)
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IHijosDTO>, HijosDAL>(async () =>
            {
                List<Hijos> listaHijosEntidad = Mapeador.MapearALista<IHijosDTO, Hijos>(listaHijos);
               await repositorio.AgregarListaAsync(listaHijosEntidad);
                respuesta.Entidades.AddRange(listaHijosEntidad);
                return respuesta;
            });
        }

		/// <summary>
		/// Metodo consultar lista hijos
		/// </summary>
		/// <returns>Respuesta tipo Hijos </returns>
        public async Task<Respuesta<IHijosDTO>> ConsultarListaHijosAsync()
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IHijosDTO>, HijosDAL>(async () =>
            {
                respuesta.Entidades = repositorio.BuscarTodos().ToList<IHijosDTO>();
                return respuesta;

            });
        }

		/// <summary>
		/// Metodo consultar lista hijos por filtro 
		/// </summary>
		/// <param name="hijos">Entidad con los datos a filtrar</param>
		/// <param name="filtro">Filtro de las entidades </param>
		/// <returns>Respuesta tipo Hijos </returns>
        public async Task<Respuesta<IHijosDTO>> ConsultarListaHijosPorFiltroAsync(Expression<Func<IHijosDTO, bool>> filtro)
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IHijosDTO>, HijosDAL>(async () =>
            {
                respuesta.Entidades = repositorio.BuscarPor(Mapeador.MapearExpresion<IHijosDTO, Hijos>(filtro)).ToList<IHijosDTO>();
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
            return await this.EjecutarTransaccionAsync<Respuesta<IHijosDTO>, HijosDAL>(async () =>
            {
                respuesta.Entidades = (from entidad in ContextoBD.Hijos
                                       where entidad.Identificacion == hijos.Identificacion
                                       select entidad).ToList<IHijosDTO>();

                return respuesta;

            });
        }
    }
}

