using Common;
using Dal;
using Entities;
using Entities.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bll
{
    public class AutoresBll : IBiblioteca
    {
     

        /// <summary>
        ///  context de base de datos
        /// </summary>
        private readonly AdminBibliotecaContext BibliotecaContex;

        /// <summary>
        /// Initializes a new instance of the <see cref="AutoresBll"/> class.
        /// </summary>
        public AutoresBll()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AutoresBll"/> class.
        /// </summary>
        /// <param name="dbcontex">Database context</param>
        public AutoresBll(AdminBibliotecaContext dbcontex)
        {
            this.BibliotecaContex = dbcontex;
        }


        /// <summary>
        /// creacion de registro para Autores
        /// </summary>
        /// <param name="entity"></param>
        /// <returns> ApiResultadoDto </returns>
        public ApiResultadoDto Adicionar(BibliotecaDto entity)
        {
            var Apiresult = new ApiResultadoDto();
            var Autores = new Autores
            {
                Nombre = entity.Nombres,
                Apellidos = entity.Apellidos,
                FechaNacimiento = (DateTime)entity.FechaNacimiento
            };
            BibliotecaContex.Autores.Add(Autores);
            BibliotecaContex.SaveChanges();
            Apiresult.Mesanje = Mensajes.RegistrosExitoso;
            return Apiresult;
        }

        /// <summary>
        /// edicion de registros para Autores
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns>ApiResultadoDto</returns>
        public ApiResultadoDto Editar(int id, BibliotecaDto entity)
        {
            var Apiresult = new ApiResultadoDto();
            var editarAutor = BibliotecaContex.Autores.FirstOrDefault(t => t.IdAutor == id);
            if (editarAutor != null)
            {
                editarAutor.Nombre = entity.Nombres;
                editarAutor.Apellidos = entity.Apellidos;
                editarAutor.FechaNacimiento = (DateTime)entity.FechaNacimiento;
                BibliotecaContex.SaveChanges();
                Apiresult.Mesanje = Mensajes.EdicionExitosa;
            }
            else
            {
                Apiresult.Mesanje = Mensajes.NoExisteId;
            }
            return Apiresult;
        }

        /// <summary>
        /// realiza la eliminacion de un autor especifico
        /// </summary>
        /// <param name="id">el identificador de la categoria</param>
        /// <returns>ApiResultadoDto</returns>
        public ApiResultadoDto Eliminar(int id)
        {
            var Apiresult = new ApiResultadoDto();
            var editarAutor = BibliotecaContex.Autores.AsNoTracking().FirstOrDefault(t => t.IdAutor == id);
            if (editarAutor != null)
            {
                BibliotecaContex.Autores.Remove(new Autores { IdAutor = id });
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
        /// consulta el listado de Autores existentes en base de datos
        /// </summary>
        /// <returns>listado de autores</returns>
        public ApiResultadoDto Listado()
        {
            var Apiresult = new ApiResultadoDto();
            var listAutorresultado = this.BibliotecaContex.Autores.Select(t => new AutoresDto
            {
                Apellidos = t.Apellidos,
                Nombre = t.Nombre,
                FechaNacimiento = t.FechaNacimiento,
                IdAutor = t.IdAutor
            }).ToList();

            Apiresult.Mesanje = Utilidades.MensajesResult(listAutorresultado);
            Apiresult.Resultado = listAutorresultado;
            return Apiresult;
        }
    }
}
