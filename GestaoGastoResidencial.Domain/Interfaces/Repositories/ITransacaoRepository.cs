using GestaoGastoResidencial.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoGastoResidencial.Domain.Interfaces.Repositories
{
    public interface ITransacaoRepository
    {
        Task<IEnumerable<Transacao>> GetTransacoes();
        Task<Transacao> GetTransacaoById(int id);
        void AddTransacao(Transacao transacao);
        void UpdateTransacao(Transacao transacao);
        Task DeleteTransacao(int id);
    }
}
