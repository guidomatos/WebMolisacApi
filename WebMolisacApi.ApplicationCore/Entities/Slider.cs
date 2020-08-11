using System;

namespace WebMolisacApi.ApplicationCore.Entities
{
    public class Slider
    {
        public int SliderId { get; set; }
        public string Nombre { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public bool Activo { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}