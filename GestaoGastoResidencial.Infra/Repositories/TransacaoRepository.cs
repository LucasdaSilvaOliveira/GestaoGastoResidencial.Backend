using GestaoGastoResidencial.Domain.Entities;
using GestaoGastoResidencial.Domain.Interfaces.Repositories;
using GestaoGastoResidencial.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoGastoResidencial.Infra.Repositories
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private readonly BancoContext _context;

        public TransacaoRepository(BancoContext context)
        {
            _context = context;
        }

        public void AddTransacao(Transacao transacao)
        {
            _context.Transacoes.Add(transacao);
            _context.SaveChanges();
        }

        public async Task DeleteTransacao(int id)
        {
            var transacao = await _context.Transacoes.FirstOrDefaultAsync(x => x.Id == id);
            if (transacao != null)
            {
                _context.Transacoes.Remove(transacao);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Transacao?> GetTransacaoById(int id)
        {
            return await _context.Transacoes
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Transacao>> GetTransacoes()
        {
            return await _context.Transacoes.AsNoTracking().ToListAsync();
        }

        public void UpdateTransacao(Transacao transacao)
        {
            if (transacao == null) return;
            _context.Transacoes.Update(transacao);
            _context.SaveChanges();
        }
    }

}
