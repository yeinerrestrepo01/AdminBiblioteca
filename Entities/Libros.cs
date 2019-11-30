using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Libros
    {
        /// <summary>
        /// identificador  unico para Libro, Llave primaria
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLibro { get; set; }

        /// <summary>
        /// Nombre del Libro
        /// </summary>
        public string NombreLibro { get; set; }

        /// <summary>
        /// ISBN  Libro
        /// </summary>
        public string ISBN { get; set; }
        /// <summary>
        /// identificador de categoría , llave foranea
        /// </summary>
        public Categorias Categorias { get; set; }

        /// <summary>
        /// identificaro de autor de libro, llave foranea tabla autores (IdAutor)
        /// </summary>
        public Autores Autores { get; set; }
    }
}
