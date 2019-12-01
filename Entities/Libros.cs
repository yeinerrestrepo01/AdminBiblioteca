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
        /// Identificador  unico para Libro, Llave primaria
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLibro { get; set; }

        /// <summary>
        /// Identificador Nombre Libro
        /// </summary>
        public string NombreLibro { get; set; }

        /// <summary>
        /// Identificador ISBN
        /// </summary>
        public string ISBN { get; set; }
        public int AutoresIdAutor { get; set; }
        public int CategoriasIdCategoria { get; set; }

        public virtual Autores Autores { get; set; }
        public virtual Categorias Categorias { get; set; }
    }
}
