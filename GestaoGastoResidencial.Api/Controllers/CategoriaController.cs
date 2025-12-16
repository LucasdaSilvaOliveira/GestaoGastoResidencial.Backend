using GestaoGastoResidencial.App.DTOs.Categoria;
using GestaoGastoResidencial.App.UseCases.CategoriaUseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestaoGastoResidencial.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaUseCases _categoriaUseCases;

        public CategoriaController(ICategoriaUseCases categoriaUseCases)
        {
            _categoriaUseCases = categoriaUseCases;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategorias()
        {
            var categorias = await _categoriaUseCases.GetCategorias();
            return Ok(categorias);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCategoriaById(int id)
        {
            if (id <= 0) return BadRequest("Id inválido.");

            try
            {
                var categoria = await _categoriaUseCases.GetCategoriaById(id);
                return Ok(categoria);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddCategoria([FromBody] CriarCategoriaDTO dto)
        {
            try
            {
                _categoriaUseCases.AddCategoria(dto);
                return Ok("Categoria registrada com sucesso.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCategoria(int id, [FromBody] CategoriaDTO dto)
        {
            if (id != dto.Id) return BadRequest("ID inválido");

            try
            {
                await _categoriaUseCases.UpdateCategoria(dto);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            try
            {
                await _categoriaUseCases.DeleteCategoria(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }

}
