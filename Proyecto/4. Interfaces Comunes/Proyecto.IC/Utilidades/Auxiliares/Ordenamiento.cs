/// <summary>
/// Archivo con la clase ordenamiento para las consultas
/// </summary>
/// <remarks>
/// Autor: Diego Madrid
/// </remarks>

namespace Proyecto.IC.Utilidades.Auxiliares
{
    using Proyecto.IC.Enumeraciones;
    using Proyecto.IC.Utilidades.Respuestas;

    public class Ordenamiento : IOrdenamientoDTO
    {
        public string NombrePropiedad { get; set; }
        public DireccionOrdenamiento Orden { get; set; }
     }
}