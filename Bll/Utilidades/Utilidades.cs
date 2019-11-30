using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bll
{
    public static class Utilidades
    {
        public static string MensajesResult<T>(List<T> listobject)
        {
            var mensajeResultado = string.Empty;
            if (!listobject.Any())
            {
                mensajeResultado = Mensajes.SinResultados;
            }

            return mensajeResultado;
        }
    }
}
