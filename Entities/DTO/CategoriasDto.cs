using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    public class CategoriasDto
    {
        /// <summary>
        /// identificador  unico para Categoria, Llave primaria
        /// </summary>
        public int IdCategoria { get; set; }

        /// <summary>
        /// Nombre del Categoria
        /// </summary>
        public string Nombre { get; set; }

        /// <descripcion de categoria
        /// </summary>
        public string Descripcion { get; set; }
    }
}
