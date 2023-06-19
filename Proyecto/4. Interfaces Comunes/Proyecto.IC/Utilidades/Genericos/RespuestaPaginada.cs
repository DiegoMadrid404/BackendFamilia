using Proyecto.IC.Utilidades.Respuestas;
/// <summary>
/// Archivo con la interfaz Respuesta con paginación en sus entidades
/// </summary>
/// <remarks>
/// Autor: Diego Madrid
/// </remarks>
namespace Proyecto.IC.Utilidades.Genericos
{
    using Newtonsoft.Json;
    using Proyecto.IC.Enumeraciones;
    using Proyecto.IC.Utilidades.Auxiliares;
    using System.Collections.Generic;

    public class RespuestaPaginada<T> : IRespuestaPaginadaDTO, IRespuestaDTO<T>
    {
        public bool Resultado { get; set; }
        public List<T> Entidades { get; set; }
        public List<string> Mensajes { get; set; }
        public TipoNotificacion TipoNotificacion { get; set; }

        [JsonConverter(typeof(ConvertidorEntidad<Paginador, IPaginadorDTO>))]
        public IPaginadorDTO Paginador { get; set; }
    }
}