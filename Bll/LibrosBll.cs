using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using Dal;
using Entities;
using Entities.DTO;
using Microsoft.EntityFrameworkCore;

namespace Bll
{
    public class LibrosBll : IBiblioteca
    {
        /// <summary>
        ///  context de base de datos
        /// </summary>
        private readonly AdminBibliotecaContext BibliotecaContex;


        /// <summary>
        /// Initializes a new instance of the <see cref="CategoriaBll"/> class.
        /// </summary>
        public LibrosBll()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoriaBll"/> class.
        /// </summary>
        /// <param name="dbcontex">Database context</param>
        public LibrosBll(AdminBibliotecaContext dbcontex)
        {
            this.BibliotecaContex = dbcontex;
        }

        /// <summary>
        /// creacion de registro para Libros
        /// </summary>
        /// <param name="entity">BibliotecaDto</param>
        /// <returns>ApiResultadoDto</returns>
        public ApiResultadoDto Adicionar(BibliotecaDto entity)
        {
            var Apiresult = new ApiResultadoDto();
            var libros = new Libros
            {
                NombreLibro = entity.Nombres,
                ISBN = entity.ISBN,
                AutoresIdAutor = (int)entity.IdAutor,
                CategoriasIdCategoria = (int)entity.IdCategoria
            };

            this.BibliotecaContex.Libros.Add(libros);
            this.BibliotecaContex.SaveChanges();
            Apiresult.Mesanje = Mensajes.RegistrosExitoso;
            return Apiresult;
        }

        /// <summary>
        /// realiza la edicion de un libro especifico
        /// </summary>
        /// <param name="id">el identificador de la categoria</param>
        /// <returns>ApiResultadoDto</returns>
        public ApiResultadoDto Editar(int id, BibliotecaDto entity)
        {
            var Apiresult = new ApiResultadoDto();
            var libros = BibliotecaContex.Libros.FirstOrDefault(t => t.IdLibro == id);
            if (libros != null)
            {
                libros.NombreLibro = entity.Nombres;
                libros.ISBN = entity.ISBN;
                libros.CategoriasIdCategoria = (int)entity.IdCategoria;
                libros.AutoresIdAutor = (int)entity.IdAutor;
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
        /// realiza la eliminacion de un libro especifico
        /// </summary>
        /// <param name="id">el identificador de la categoria</param>
        /// <returns>ApiResultadoDto</returns>
        public ApiResultadoDto Eliminar(int id)
        {
            var Apiresult = new ApiResultadoDto();
            var editarAutor = BibliotecaContex.Libros.AsNoTracking().FirstOrDefault(t => t.IdLibro == id);
            if (editarAutor != null)
            {
                BibliotecaContex.Libros.Remove(new Libros { IdLibro = id });
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
        /// consulta el listado de libros almacenados en base de datos
        /// </summary>
        /// <returns>listado de libros</returns>
        public ApiResultadoDto Listado()
        {

            var Apiresult = new ApiResultadoDto();
            var listLibros = this.BibliotecaContex.Libros.Select(t => new LibrosDto
            {
                NombreLibro = t.NombreLibro,
                ISBN = t.ISBN,
                Autor = t.Autores.Nombre +" " + t.Autores.Apellidos,
                Categoria = t.Categorias.Nombre  

            }).ToList();

            Apiresult.Mesanje = Utilidades.MensajesResult(listLibros);
            Apiresult.Resultado = listLibros;
            return Apiresult;
        }
    }
}
