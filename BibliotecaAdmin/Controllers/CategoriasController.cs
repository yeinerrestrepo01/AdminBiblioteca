using Bll;
using Entities.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly Biblioteca Biblioteca = new Biblioteca(new CategoriaBll());

        /// <summary>
        /// inializador de nueva instancia controller Categorias
        /// </summary>
        /// <param name="categoria"></param>
        /// <param name="biblioteca"></param>
        public CategoriasController(Biblioteca biblioteca) 
        {
            this.Biblioteca = biblioteca;
        }

        // GET: api/Categorias
        [HttpGet]
        public ApiResultadoDto Get() 
        {
            return Biblioteca.Listado();
        }


        // POST: api/Autores
        /// <summary>
        /// metodo para creacion de categorias
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>ApiResultadoDto</returns>
        [HttpPost]
        public ApiResultadoDto Post([FromBody] BibliotecaDto entity)
        {
            return Biblioteca.Adiconar(entity);
        }

        // PUT: api/Categorias/5
        [HttpPut("{id}")]
        public ApiResultadoDto Put(int id, [FromBody] BibliotecaDto entity)
        {
            return Biblioteca.Editar(id ,entity);
        }

        // DELETE: api/Categorias/5
        [HttpDelete("{id}")]
        public ApiResultadoDto Delete(int id)
        {
            return Biblioteca.Eliminar(id);
        }
    }
}