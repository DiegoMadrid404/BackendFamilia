﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Proyecto.Datos.Contexto.Repositorio
{
    public partial class Hijos
    {
        public int Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public string Estudia { get; set; }
        public int? Estatura { get; set; }
        public string DescripcionFisica { get; set; }
        public int? IdentificacionPadre { get; set; }
        public int? IdentificacionMadre { get; set; }

        public virtual Padres IdentificacionMadreNavigation { get; set; }
        public virtual Padres IdentificacionPadreNavigation { get; set; }
    }
}