using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Autores
    {
        /// <summary>
        /// identificador  unico para autor, Llave primaria
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAutor { get; set; }

        /// <summary>
        /// Nombres del autor
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Apellidos del autor
        /// </summary>
        public string Apellidos { get; set; }

        /// <summary>
        /// Fecha nacimiento del autor
        /// </summary>
        public DateTime FechaNacimiento { get; set; }
    }
}
