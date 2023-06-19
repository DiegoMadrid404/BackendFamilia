// ------------------------------------------------------------------------------------
// <copyright file="IPadresDTO.cs" company="DiegoMadrid26@gmail.com">
// Copyright (c) DiegoMadrid26@gmail.com. All rights reserved.
// </copyright>
// <author>Diego Madrid</author>
// ------------------------------------------------------------------------------------
namespace Proyecto.IC.DTO.Repositorio
{
	using System;

	/// <summary>
	/// Interface que define las propiedades de Padres
	/// </summary>
	public interface IPadresDTO
	{
		/// <summary>
		/// Obtiene o establece el Identificacion
		/// </summary>
		int Identificacion { get; set; }

		/// <summary>
		/// Obtiene o establece el Nombres
		/// </summary>
		string Nombres { get; set; }

		/// <summary>
		/// Obtiene o establece el Apellidos
		/// </summary>
		string Apellidos { get; set; }

		/// <summary>
		/// Obtiene o establece el Fecha Nacimiento
		/// </summary>
		DateTime FechaNacimiento { get; set; }

		/// <summary>
		/// Obtiene o establece el Genero
		/// </summary>
		string Genero { get; set; }

		/// <summary>
		/// Obtiene o establece el Tipo Empleo
		/// </summary>
		string TipoEmpleo { get; set; }

		/// <summary>
		/// Obtiene o establece el Experiencia Laboral
		/// </summary>
		int? ExperienciaLaboral { get; set; }

		/// <summary>
		/// Obtiene o establece el Observaciones
		/// </summary>
		string Observaciones { get; set; }
	}
}
