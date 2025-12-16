using GestaoGastoResidencial.App.DTOs.Transacao;
using GestaoGastoResidencial.Domain.Entities;
using GestaoGastoResidencial.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoGastoResidencial.App.UseCases.TransacaoUseCase
{
    public class TransacaoUseCases : ITransacaoUseCases
    {
        private readonly ITransacaoRepository _transacaoRepository;

        public TransacaoUseCases(ITransacaoRepository transacaoRepository)
        {
            _transacaoRepository = transacaoRepository;
        }

        public void AddTransacao(CriarTransacaoDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Descricao) || dto.Valor <= 0)
                throw new ArgumentException("Dados inválidos para criação de transação");

            var transacao = new Transacao
            {
                Descrição = dto.Descricao,
                Valor = dto.Valor,
                Tipo = dto.Tipo,
                CategoriaId = dto.CategoriaId,
                PessoaId = dto.PessoaId
            };

            _transacaoRepository.AddTransacao(transacao);
        }

        public async Task DeleteTransacao(int id)
        {
            var transacao = await _transacaoRepository.GetTransacaoById(id);
            if (transacao == null)
                throw new KeyNotFoundException("Transação não encontrada");

            await _transacaoRepository.DeleteTransacao(id);
        }

        public async Task<IEnumerable<TransacaoDTO>> GetTransacoes()
        {
            var transacoes = await _transacaoRepository.GetTransacoes();
            return transacoes.Select(t => new TransacaoDTO
            {
                Id = t.Id,
                Descrição = t.Descrição,
                Valor = t.Valor,
                Tipo = t.Tipo,
                CategoriaId = t.CategoriaId,
                PessoaId = t.PessoaId
            }).ToList();
        }

        public async Task<TransacaoDTO> GetTransacaoById(int id)
        {
            var transacao = await _transacaoRepository.GetTransacaoById(id);
            if (transacao == null)
                throw new KeyNotFoundException("Transação não encontrada");

            return new TransacaoDTO
            {
                Id = transacao.Id,
                Descrição = transacao.Descrição,
                Valor = transacao.Valor,
                Tipo = transacao.Tipo,
                CategoriaId = transacao.CategoriaId,
                PessoaId = transacao.PessoaId
            };
        }

        public async Task UpdateTransacao(TransacaoDTO dto)
        {
            var transacao = await _transacaoRepository.GetTransacaoById(dto.Id);
            if (transacao == null)
                throw new KeyNotFoundException("Transação não encontrada");

            transacao.Descrição = dto.Descrição;
            transacao.Valor = dto.Valor;
            transacao.Tipo = dto.Tipo;
            transacao.CategoriaId = dto.CategoriaId;
            transacao.PessoaId = dto.PessoaId;

            _transacaoRepository.UpdateTransacao(transacao);
        }
    }

}
