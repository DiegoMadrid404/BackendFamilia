// ------------------------------------------------------------------------------------
// <copyright file="PadresBO.cs" company="DiegoMadrid26@gmail.com">
// Copyright (c) DiegoMadrid26@gmail.com. All rights reserved.
// </copyright>
// <author>Diego Madrid</author>
// ------------------------------------------------------------------------------------
namespace Proyecto.Negocio.Clases.BO.Repositorio
{
	using Proyecto.IC.DTO.Repositorio;
	using System;

	/// <summary>
	/// clase para las propiedades de la entidad Padres
	/// </summary>
	public class PadresBO : IPadresDTO
	{
		/// <summary>
		/// Obtiene o establece el Identificacion
		/// </summary>
		public int Identificacion { get; set; }

		/// <summary>
		/// Obtiene o establece el Nombres
		/// </summary>
		public string Nombres { get; set; }

		/// <summary>
		/// Obtiene o establece el Apellidos
		/// </summary>
		public string Apellidos { get; set; }

		/// <summary>
		/// Obtiene o establece el Fecha Nacimiento
		/// </summary>
		public DateTime FechaNacimiento { get; set; }

		/// <summary>
		/// Obtiene o establece el Genero
		/// </summary>
		public string Genero { get; set; }

		/// <summary>
		/// Obtiene o establece el Tipo Empleo
		/// </summary>
		public string TipoEmpleo { get; set; }

		/// <summary>
		/// Obtiene o establece el Experiencia Laboral
		/// </summary>
		public int? ExperienciaLaboral { get; set; }

		/// <summary>
		/// Obtiene o establece el Observaciones
		/// </summary>
		public string Observaciones { get; set; }

	}
}
