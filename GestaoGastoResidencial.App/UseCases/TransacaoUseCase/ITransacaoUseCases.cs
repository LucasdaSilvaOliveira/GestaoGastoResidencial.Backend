using GestaoGastoResidencial.App.DTOs.Transacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoGastoResidencial.App.UseCases.TransacaoUseCase
{
    public interface ITransacaoUseCases
    {
        void AddTransacao(CriarTransacaoDTO dto);
        Task<IEnumerable<TransacaoDTO>> GetTransacoes();
        Task<TransacaoDTO> GetTransacaoById(int id);
        Task UpdateTransacao(TransacaoDTO pessoa);
        Task DeleteTransacao(int id);
    }
}
