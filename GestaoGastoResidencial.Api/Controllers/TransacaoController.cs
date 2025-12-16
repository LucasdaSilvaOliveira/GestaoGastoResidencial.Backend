using GestaoGastoResidencial.App.DTOs.Transacao;
using GestaoGastoResidencial.App.UseCases.TransacaoUseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestaoGastoResidencial.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoUseCases _transacaoUseCases;

        public TransacaoController(ITransacaoUseCases transacaoUseCases)
        {
            _transacaoUseCases = transacaoUseCases;
        }

        [HttpGet]
        public async Task<IActionResult> GetTransacoes()
        {
            var transacoes = await _transacaoUseCases.GetTransacoes();
            return Ok(transacoes);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTransacaoById(int id)
        {
            if (id <= 0) return BadRequest("Id inválido.");

            try
            {
                var transacao = await _transacaoUseCases.GetTransacaoById(id);
                return Ok(transacao);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddTransacao([FromBody] CriarTransacaoDTO dto)
        {
            try
            {
                _transacaoUseCases.AddTransacao(dto);
                return Ok("Transação registrada com sucesso.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateTransacao(int id, [FromBody] TransacaoDTO dto)
        {
            if (id != dto.Id) return BadRequest("ID inválido");

            try
            {
                await _transacaoUseCases.UpdateTransacao(dto);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTransacao(int id)
        {
            try
            {
                await _transacaoUseCases.DeleteTransacao(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }

}
