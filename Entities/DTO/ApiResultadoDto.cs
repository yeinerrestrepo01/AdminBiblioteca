﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    /// <summary>
    /// resultado de tranaccion
    /// </summary>
    public class ApiResultadoDto
    {
        public string Mensaje { get; set; }

        public bool isError { get; set; }

        public object Resultado { get; set; }
    }
}
