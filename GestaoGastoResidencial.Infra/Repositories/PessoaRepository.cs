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
    public class PessoaRepository : IPessoaRepository
    {
        private readonly BancoContext _context;
        public PessoaRepository(BancoContext context)
        {
            _context = context;
        }

        public void AddPessoa(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            _context.SaveChanges();
        }

        public async Task DeletePessoa(int id)
        {
            var pessoa = await _context.Pessoas.FirstOrDefaultAsync(x => x.Id == id);
            if (pessoa != null)
            {
                _context.Pessoas.Remove(pessoa);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Pessoa?> GetPessoaById(int id)
        {
            return await _context.Pessoas
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Pessoa>> GetPessoas()
        {
            return await _context.Pessoas.AsNoTracking().ToListAsync();
        }

        public void UpdatePessoa(Pessoa pessoa)
        {
            if (pessoa == null) return;
            _context.Pessoas.Update(pessoa);
            _context.SaveChanges();
        }
    }

}
