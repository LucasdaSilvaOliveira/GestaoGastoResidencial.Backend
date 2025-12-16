using GestaoGastoResidencial.App.DTOs.Pessoa;
using GestaoGastoResidencial.App.UseCases.PessoaUseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestaoGastoResidencial.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaUseCases _pessoaUseCases;

        public PessoaController(IPessoaUseCases pessoaUseCases)
        {
            _pessoaUseCases = pessoaUseCases;
        }

        [HttpGet]
        public async Task<IActionResult> GetPessoas()
        {
            var pessoas = await _pessoaUseCases.GetPessoas();
            return Ok(pessoas);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPessoaById(int id)
        {
            if (id <= 0) return BadRequest("Id inválido.");

            try
            {
                var pessoa = await _pessoaUseCases.GetPessoaById(id);
                return Ok(pessoa);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddPessoa([FromBody] CriarPessoaDTO dto)
        {
            try
            {
                _pessoaUseCases.AddPessoa(dto);
                return Ok("Pessoa registrada com sucesso.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdatePessoa(int id, [FromBody] PessoaDTO pessoaDto)
        {
            if (id != pessoaDto.Id) return BadRequest("ID inválido");

            try
            {
                await _pessoaUseCases.UpdatePessoa(pessoaDto);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePessoa(int id)
        {
            try
            {
                await _pessoaUseCases.DeletePessoa(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }

}
