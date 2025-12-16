using GestaoGastoResidencial.App.DTOs.Pessoa;
using GestaoGastoResidencial.Domain.Entities;
using GestaoGastoResidencial.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoGastoResidencial.App.UseCases.PessoaUseCase
{
    public class PessoaUseCases : IPessoaUseCases
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaUseCases(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public void AddPessoa(CriarPessoaDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Nome) || dto.Idade <= 0)
                throw new ArgumentException("Dados inválidos para criação de pessoa.");

            var pessoa = new Pessoa
            {
                Nome = dto.Nome,
                Idade = dto.Idade
            };

            _pessoaRepository.AddPessoa(pessoa);
        }

        public async Task DeletePessoa(int id)
        {
            var pessoa = await _pessoaRepository.GetPessoaById(id);
            if (pessoa == null)
                throw new KeyNotFoundException("Pessoa não encontrada");

            await _pessoaRepository.DeletePessoa(id);
        }

        public async Task<PessoaDTO> GetPessoaById(int id)
        {
            var pessoa = await _pessoaRepository.GetPessoaById(id);
            if (pessoa == null)
                throw new KeyNotFoundException("Pessoa não encontrada");

            return new PessoaDTO
            {
                Id = pessoa.Id,
                Nome = pessoa.Nome,
                Idade = pessoa.Idade
            };
        }

        public async Task<IEnumerable<PessoaDTO>> GetPessoas()
        {
            var pessoas = await _pessoaRepository.GetPessoas();
            return pessoas.Select(p => new PessoaDTO
            {
                Id = p.Id,
                Nome = p.Nome,
                Idade = p.Idade
            });
        }

        public async Task UpdatePessoa(PessoaDTO pessoaDto)
        {
            var pessoa = await _pessoaRepository.GetPessoaById(pessoaDto.Id);
            if (pessoa == null)
                throw new KeyNotFoundException("Pessoa não encontrada");

            pessoa.Nome = pessoaDto.Nome;
            pessoa.Idade = pessoaDto.Idade;

            _pessoaRepository.UpdatePessoa(pessoa);
        }
    }

}
