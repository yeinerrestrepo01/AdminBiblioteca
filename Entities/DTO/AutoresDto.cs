using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    public class AutoresDto
    {
        /// <summary>
        /// identificador  unico para autor, Llave primaria
        /// </summary>
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
