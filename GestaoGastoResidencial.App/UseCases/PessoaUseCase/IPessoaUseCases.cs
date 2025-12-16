using GestaoGastoResidencial.App.DTOs.Pessoa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoGastoResidencial.App.UseCases.PessoaUseCase
{
    public interface IPessoaUseCases
    {
        void AddPessoa(CriarPessoaDTO dto);
        Task<IEnumerable<PessoaDTO>> GetPessoas();
        Task<PessoaDTO> GetPessoaById(int id);
        Task UpdatePessoa(PessoaDTO pessoa);
        Task DeletePessoa(int id);
    }
}
