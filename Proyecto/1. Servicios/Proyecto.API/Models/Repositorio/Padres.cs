// ------------------------------------------------------------------------------------
// <copyright file="Padres.cs" company="DiegoMadrid26@gmail.com">
// Copyright (c) DiegoMadrid26@gmail.com. All rights reserved.
// </copyright>
// <author>Diego Madrid</author>
// ------------------------------------------------------------------------------------
namespace Proyecto.API.Models.Repositorio
{
	using Proyecto.IC.DTO.Repositorio;
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// clase para las propiedades de la entidad Padres
    /// </summary>
    public class Padres : IPadresDTO
	{
        /// <summary>
        /// Obtiene o establece el Identificacion
        /// </summary>
        [Required(ErrorMessage = "El campo Identificacón es requerido.")]
        public int Identificacion { get; set; }

        /// <summary>
        /// Obtiene o establece el Nombres
        /// </summary>
        [Required(ErrorMessage = "El campo Nombres es requerido.")]
        public string Nombres { get; set; }

        /// <summary>
        /// Obtiene o establece el Apellidos
        /// </summary>
        [Required(ErrorMessage = "El campo Apellidos es requerido.")]
        public string Apellidos { get; set; }

        /// <summary>
        /// Obtiene o establece el Fecha Nacimiento
        /// </summary>
        [Required(ErrorMessage = "El campo Fecha de nacimiento es requerido.")]
        [DataType(DataType.Date)] 
        public DateTime FechaNacimiento { get; set; }

        /// <summary>
        /// Obtiene o establece el Genero
        /// </summary>
        [Required(ErrorMessage = "El campo Genero es requerido.")]
        [RegularExpression("^[MFmf]$", ErrorMessage = "El campo Genero solo puede  ser la letra (M) Masculino ó (F) Femenino.")]
        public string Genero { get; set; }

        /// <summary>
        /// Obtiene o establece el Tipo Empleo
        /// </summary>
        [Required(ErrorMessage = "El campo Tipo Empleo es requerido.")]
        [RegularExpression("^[EeIi]$", ErrorMessage = "El campo Tipo Empleo solo puede  ser la letra (E) Empleado ó (I) Independiente.")]
        public string TipoEmpleo { get; set; }

        /// <summary>
        /// Obtiene o establece el Experiencia Laboral
        /// </summary>
        [RegularExpression("^([0-9]|1[0-9]|2[0-9]|30)$", ErrorMessage = "El campo Experiencia Laboral debe ser un número entero entre 0 y 30.")]
        public int? ExperienciaLaboral { get; set; }

        /// <summary>
        /// Obtiene o establece el Observaciones
        /// </summary>
        [StringLength(500, ErrorMessage = "El campo Observaciones debe tener como máximo 500 caracteres.")]
        public string Observaciones { get; set; }

	}
}
