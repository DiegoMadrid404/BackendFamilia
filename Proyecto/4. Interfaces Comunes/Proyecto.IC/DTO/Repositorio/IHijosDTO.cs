// ------------------------------------------------------------------------------------
// <copyright file="IHijosDTO.cs" company="DiegoMadrid26@gmail.com">
// Copyright (c) DiegoMadrid26@gmail.com. All rights reserved.
// </copyright>
// <author>Diego Madrid</author>
// ------------------------------------------------------------------------------------
namespace Proyecto.IC.DTO.Repositorio
{
	using System;

	/// <summary>
	/// Interface que define las propiedades de Hijos
	/// </summary>
	public interface IHijosDTO
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
		/// Obtiene o establece el Estudia
		/// </summary>
		string Estudia { get; set; }

		/// <summary>
		/// Obtiene o establece el Estatura
		/// </summary>
		int? Estatura { get; set; }

		/// <summary>
		/// Obtiene o establece el Descripcion Fisica
		/// </summary>
		string DescripcionFisica { get; set; }

		/// <summary>
		/// Obtiene o establece el Identificacion Padre
		/// </summary>
		int? IdentificacionPadre { get; set; }

		/// <summary>
		/// Obtiene o establece el Identificacion Madre
		/// </summary>
		int? IdentificacionMadre { get; set; }
	}
}
