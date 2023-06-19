// ------------------------------------------------------------------------------------
// <copyright file="HijosBO.cs" company="DiegoMadrid26@gmail.com">
// Copyright (c) DiegoMadrid26@gmail.com. All rights reserved.
// </copyright>
// <author>Diego Madrid</author>
// ------------------------------------------------------------------------------------
namespace Proyecto.Negocio.Clases.BO.Repositorio
{
	using Proyecto.IC.DTO.Repositorio;
	using System;

	/// <summary>
	/// clase para las propiedades de la entidad Hijos
	/// </summary>
	public class HijosBO : IHijosDTO
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
		/// Obtiene o establece el Estudia
		/// </summary>
		public string Estudia { get; set; }

		/// <summary>
		/// Obtiene o establece el Estatura
		/// </summary>
		public int? Estatura { get; set; }

		/// <summary>
		/// Obtiene o establece el Descripcion Fisica
		/// </summary>
		public string DescripcionFisica { get; set; }

		/// <summary>
		/// Obtiene o establece el Identificacion Padre
		/// </summary>
		public int? IdentificacionPadre { get; set; }

		/// <summary>
		/// Obtiene o establece el Identificacion Madre
		/// </summary>
		public int? IdentificacionMadre { get; set; }

	}
}
