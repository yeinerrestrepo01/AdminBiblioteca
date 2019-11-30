using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    /// <summary>
    /// resultado de tranaccion
    /// </summary>
    public class ApiResultadoDto
    {
        public string Mesanje { get; set; }

        public bool Error { get; set; }

        public object Resultado { get; set; }
    }
}
