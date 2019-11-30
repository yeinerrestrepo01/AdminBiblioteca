using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using Dal;
using Entities;
using Entities.DTO;

namespace Bll
{
    public class CategoriaBll : IBiblioteca
    {

        /// <summary>
        ///  context de base de datos
        /// </summary>
        private readonly AdminBibliotecaContext BibliotecaContex;


        /// <summary>
        /// Initializes a new instance of the <see cref="CategoriaBll"/> class.
        /// </summary>
        public CategoriaBll()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoriaBll"/> class.
        /// </summary>
        /// <param name="dbcontex">Database context</param>
        public CategoriaBll(AdminBibliotecaContext dbcontex)
        {
            this.BibliotecaContex = dbcontex;
        }
        
        /// <summary>
        /// creacion de registro para categorias
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ApiResultadoDto Adicionar(BibliotecaDto entity)
        {
            var Apiresult = new ApiResultadoDto();
            var categogira = new Categorias { Nombre = entity.Nombres, Descripcion = entity.Descripcion };
            BibliotecaContex.Categorias.Add(categogira);
            BibliotecaContex.SaveChanges();
            Apiresult.Mesanje = Mensajes.RegistrosExitoso;
            return Apiresult;

        }

        /// <summary>
        /// edicion de registros de catergoria
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns>ApiResultadoDto</returns>
        public ApiResultadoDto Editar(int id, BibliotecaDto entity)
        {
            var Apiresult = new ApiResultadoDto();
            var editarcategoria = BibliotecaContex.Categorias.FirstOrDefault(t => t.IdCategoria == id);
            if (editarcategoria != null)
            {
                editarcategoria.Descripcion = entity.Descripcion;
                editarcategoria.Nombre = entity.Nombres;
                Apiresult.Mesanje = Mensajes.EdicionExitosa;
                BibliotecaContex.SaveChanges();
            }
            else
            {
                Apiresult.Mesanje = Mensajes.NoExisteId;
            }
            return Apiresult;
        }

        /// <summary>
        /// realiza la eliminacion de una categoria especifica
        /// </summary>
        /// <param name="id">el identificador de la categoria</param>
        /// <returns>ApiResultadoDto</returns>
        public ApiResultadoDto Eliminar(int id)
        {
            var Apiresult = new ApiResultadoDto();
            var editarcategoria = BibliotecaContex.Categorias.FirstOrDefault(t => t.IdCategoria == id);
            if (editarcategoria != null)
            {
                BibliotecaContex.Categorias.Remove(new Categorias { IdCategoria = id });
                BibliotecaContex.SaveChanges();
                Apiresult.Mesanje = Mensajes.EliminacionExitosa;
            }
            else
            {
                Apiresult.Mesanje = Mensajes.NoExisteId;
            }

            return Apiresult;
        }

        /// <summary>
        /// consulta el listado de categorias existentes en base de datos
        /// </summary>
        /// <returns>listado de categorias</returns>
        public ApiResultadoDto Listado()
        {
            var Apiresult = new ApiResultadoDto();
            var listcategoriaresultado = this.BibliotecaContex.Categorias.Select(t => new CategoriasDto
            {
                Descripcion = t.Descripcion,
                Nombre = t.Nombre,
                IdCategoria = t.IdCategoria
            }).ToList();

            Apiresult.Mesanje = Utilidades.MensajesResult(listcategoriaresultado);
            Apiresult.Resultado = listcategoriaresultado;
            return Apiresult;
        }
    }
}
