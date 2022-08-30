using System.Text.Json.Serialization;

namespace BlogAPI.Src.Utilidades
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TipoUsuario
    {
        NORMAL,
        ADMINISTRADOR
    }
}