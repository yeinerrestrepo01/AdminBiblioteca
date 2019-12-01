using Bll;
using Dal;
using Entities.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriasController : ControllerBase
    {
        private readonly Biblioteca _Biblioteca;
        private readonly AdminBibliotecaContext _ContextDB;

        /// <summary>
        /// inializador de nueva instancia controller Categorias
        /// </summary>
        /// <param name="contextDB"></param>
        public CategoriasController(AdminBibliotecaContext contextDB) 
        {
            this._ContextDB = contextDB;
            this._Biblioteca = new Biblioteca(new CategoriaBll(contextDB));
        }

        // GET: api/Categorias
        [HttpGet]
        public ApiResultadoDto Get() 
        {

            return _Biblioteca.Listado();
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
            return _Biblioteca.Adicionar(entity);
        }

        // PUT: api/Categorias/5
        [HttpPut("{id}")]
        public ApiResultadoDto Put(int id, [FromBody] BibliotecaDto entity)
        {
            return _Biblioteca.Editar(id ,entity);
        }

        // DELETE: api/Categorias/5
        [HttpDelete("{id}")]
        public ApiResultadoDto Delete(int id)
        {
            return _Biblioteca.Eliminar(id);
        }
    }
}