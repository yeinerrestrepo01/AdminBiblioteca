using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bll
{
   public interface IBiblioteca
    {
        public ApiResultadoDto Editar(int id ,BibliotecaDto entity);
        public ApiResultadoDto Listado();
        public ApiResultadoDto Eliminar(int id);
        public ApiResultadoDto Adicionar(BibliotecaDto entity);
    }
}
