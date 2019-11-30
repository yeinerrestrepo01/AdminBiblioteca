using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    public class BibliotecaDto
    {
        /// <summary>
        /// Nombre 
        /// </summary>
        public string Nombres { get; set; }

        /// <summary>
        /// Apellidos 
        /// </summary>
        public string Apellidos { get; set; }

        /// <summary>
        /// Apellidos 
        /// </summary>
        public DateTime? FechaNacimiento { get; set; }

        /// <summary>
        /// identificador de categoría
        /// </summary>
        public int? IdCategoria { get; set; }

        /// <summary>
        /// identificador de categoría
        /// </summary>
        public int? IdAutor { get; set; }

        /// <summary>
        /// ISBN 
        /// </summary>
        public string ISBN { get; set; }

        /// <summary>
        /// Descripcion 
        /// </summary>
        public string Descripcion { get; set; }


    }
}
