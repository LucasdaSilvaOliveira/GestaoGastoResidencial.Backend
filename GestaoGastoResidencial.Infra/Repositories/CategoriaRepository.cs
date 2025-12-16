using GestaoGastoResidencial.Domain.Entities;
using GestaoGastoResidencial.Domain.Interfaces.Repositories;
using GestaoGastoResidencial.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoGastoResidencial.Infra.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly BancoContext _context;

        public CategoriaRepository(BancoContext context)
        {
            _context = context;
        }

        public void AddCategoria(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
        }

        public async Task DeleteCategoria(int id)
        {
            var categoria = await _context.Categorias.FirstOrDefaultAsync(x => x.Id == id);
            if (categoria != null)
            {
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Categoria?> GetCategoriaById(int id)
        {
            return await _context.Categorias
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Categoria>> GetCategorias()
        {
            return await _context.Categorias.AsNoTracking().ToListAsync();
        }

        public void UpdateCategoria(Categoria categoria)
        {
            if (categoria == null) return;
            _context.Categorias.Update(categoria);
            _context.SaveChanges();
        }
    }

}
