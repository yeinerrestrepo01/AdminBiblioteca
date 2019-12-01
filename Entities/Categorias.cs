using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Categorias
    {
        /// <summary>
        /// identificador  unico para Categoria, Llave primaria
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCategoria { get; set; }

        /// <summary>
        /// Nombre del Categoria
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Descripcion de categoria
        /// </summary>
        public string Descripcion { get; set; }

        public virtual ICollection<Libros> Libros { get; set; }
    }
}
