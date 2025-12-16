using GestaoGastoResidencial.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoGastoResidencial.Domain.Interfaces.Repositories
{
    public interface IPessoaRepository
    {
        Task<IEnumerable<Pessoa>> GetPessoas();
        Task<Pessoa> GetPessoaById(int id);
        void AddPessoa(Pessoa pessoa);
        void UpdatePessoa(Pessoa pessoa);
        Task DeletePessoa(int id);
    }
}
