/// <summary>
/// Archivo con la interfaz Respuesta con paginación en sus entidades
/// </summary>
/// <remarks>
/// Autor: Diego Madrid
/// </remarks>

namespace Proyecto.IC.Utilidades.Respuestas
{ 
    public interface IRespuestaPaginadaDTO
    {
        IPaginadorDTO Paginador { get; set; }
    }
}