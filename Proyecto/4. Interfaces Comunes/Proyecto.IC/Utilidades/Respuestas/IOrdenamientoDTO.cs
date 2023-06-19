/// <summary>
/// Archivo con la clase ordenamiento para las consultas
/// </summary>
/// <remarks>
/// Autor: Diego Madrid
/// </remarks>
namespace Proyecto.IC.Utilidades.Respuestas
{
    using Proyecto.IC.Enumeraciones;

    public interface IOrdenamientoDTO
    {
        string NombrePropiedad { get; set; }
        DireccionOrdenamiento Orden { get; set; }
    }
}