using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bll;
using Entities.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {

        private readonly Biblioteca Biblioteca = new Biblioteca(new AutoresBll());

        /// <summary>
        /// inializador de nueva instancia controller Categorias
        /// </summary>
        /// <param name="categoria"></param>
        /// <param name="biblioteca"></param>
        public AutoresController(Biblioteca biblioteca)
        {
            this.Biblioteca = biblioteca;
        }
        // GET: api/Autores
        [HttpGet]
        public ApiResultadoDto Get()
        {
            return Biblioteca.Listado();
        }

        // POST: api/Autores
        [HttpPost]
        public ApiResultadoDto Post([FromBody] BibliotecaDto entity)
        {
            return Biblioteca.Adiconar(entity);
        }

        // PUT: api/Autores/5
        [HttpPut("{id}")]
        public ApiResultadoDto Put(int id, [FromBody] BibliotecaDto entity)
        {
            return Biblioteca.Editar(id, entity);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ApiResultadoDto Delete(int id)
        {
            return Biblioteca.Eliminar(id);
        }
    }
}
