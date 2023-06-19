/// <summary>
/// Archivo con la clase encargada de almacenar los parametros para paginar las consultas
/// </summary>
/// <remarks>
/// Autor: Diego Madrid
/// </remarks>

namespace Proyecto.IC.Utilidades.Respuestas
{
    using System.Collections.Generic;

    public interface IPaginadorDTO
    {
        int Pagina { get; set; }
        int Registros { get; set; }
        int TotalRegistros { get; set; }
        List<IOrdenamientoDTO> PropiedadesDeOrdenamiento { get; set; }
    }
}