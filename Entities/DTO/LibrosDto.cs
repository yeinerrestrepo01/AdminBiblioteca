using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    public class LibrosDto
    {
        public int IdLibro { get; set; }
        public string NombreLibro { get; set; }
        public string ISBN { get; set; }
        public string Autor { get; set; }
        public string Categoria { get; set; }
        public int IdCategoria { get; set; }
        public int IdAutor { get; set; }
    }
}
