/// <summary>
/// Archivo con la clase encargada de almacenar los parametros para paginar las consultas
/// </summary>
/// <remarks>
/// Autor: Diego Madrid
/// </remarks>

namespace Proyecto.IC.Utilidades.Auxiliares
{
    using Newtonsoft.Json;
    using Proyecto.IC.Utilidades.Genericos;
    using Proyecto.IC.Utilidades.Respuestas;
    using System.Collections.Generic;

    public class Paginador : IPaginadorDTO
    {
        public int Pagina { get; set; }
        public int Registros { get; set; }
        public int TotalRegistros { get; set; }

        [JsonConverter(typeof(ConvertidorLista<Ordenamiento, IOrdenamientoDTO>))]
        public List<IOrdenamientoDTO> PropiedadesDeOrdenamiento { get; set; }
    }
}