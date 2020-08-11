using System;

namespace WebMolisacApi.ApplicationCore.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Codigo { get; set; }
        public string Clave { get; set; }
        public bool Activo { get; set; }
    }
}