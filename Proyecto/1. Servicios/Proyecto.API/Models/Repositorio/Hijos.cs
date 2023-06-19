// ------------------------------------------------------------------------------------
// <copyright file="Hijos.cs" company="DiegoMadrid26@gmail.com">
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
    /// clase para las propiedades de la entidad Hijos
    /// </summary>
    public class Hijos : IHijosDTO
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
        /// Obtiene o establece el Estudia
        /// </summary>
        [Required(ErrorMessage = "El campo Estudia es requerido.")]
        [RegularExpression("^[SsNn]$", ErrorMessage = "El campo Estudia solo puede ser la letra (S) Si o (N) No.")]
        public string Estudia { get; set; }

        /// <summary>
        /// Obtiene o establece el Estatura
        /// </summary>
        [Required(ErrorMessage = "El campo Estatura es requerido.")]
        [RegularExpression("^(5[0-9]|[6-9][0-9]|1[0-9]{2})$", ErrorMessage = "El campo Estatura debe ser un número entero entre 50 y 200.")]
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
