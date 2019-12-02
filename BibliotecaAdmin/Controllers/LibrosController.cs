using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bll;
using Dal;
using Entities.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LibrosController : ControllerBase
    {
        private readonly Biblioteca _Biblioteca;
        private readonly AdminBibliotecaContext _ContextDB;

        /// <summary>
        /// inializador de nueva instancia controller Autores
        /// </summary>
        /// <param name="contextDB"></param>
        public LibrosController(AdminBibliotecaContext contextDB)
        {
            this._ContextDB = contextDB;
            this._Biblioteca = new Biblioteca(new LibrosBll(contextDB));
        }

    
        [HttpGet]
        public ApiResultadoDto Get()
        {
            return _Biblioteca.Listado();
        }

        [Route("GetParametros")]
        [HttpGet]
        public ApiResultadoDto GetParametros(string libro, int? autor, int? categoria)
        {
            return _Biblioteca.BusquedaLibro(libro, (int)autor, (int)categoria);
        }

        // POST: api/Libros
        [HttpPost]
        public ApiResultadoDto Post([FromBody] BibliotecaDto entity)
        {
            return _Biblioteca.Adicionar(entity);
        }

        // PUT: api/Libros/5
        [HttpPut("{id}")]
        public ApiResultadoDto Put(int id, [FromBody] BibliotecaDto entity)
        {
            return _Biblioteca.Editar(id,entity);
        }

        // DELETE: api/Libros/5
        [HttpDelete("{id}")]
        public ApiResultadoDto Delete(int id)
        {
            return _Biblioteca.Eliminar(id);
        }
    }
}
