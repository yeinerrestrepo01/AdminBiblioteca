﻿using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bll
{
    public class Biblioteca
    {
        private readonly IBiblioteca BibliotecaI;


        /// <summary>
        /// Initializes a new instance of the <see cref="Biblioteca"/> class.
        /// </summary>
        /// <param name="bibliotecaI">bibliotecaI</param>
        public Biblioteca(IBiblioteca bibliotecaI) => BibliotecaI = bibliotecaI;
       

        public ApiResultadoDto Adiconar(BibliotecaDto entity)
        {
            return BibliotecaI.Adicionar(entity);
        }

        public ApiResultadoDto Listado()
        {
            return BibliotecaI.Listado();
        }

        public ApiResultadoDto Editar(int id,BibliotecaDto entity)
        {
            return BibliotecaI.Editar(id ,entity);
        }

        public ApiResultadoDto Eliminar(int id)
        {
            return BibliotecaI.Eliminar(id);
        }
    }
}