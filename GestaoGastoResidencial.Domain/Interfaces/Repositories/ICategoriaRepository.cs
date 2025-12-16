using GestaoGastoResidencial.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoGastoResidencial.Domain.Interfaces.Repositories
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> GetCategorias();
        Task<Categoria> GetCategoriaById(int id);
        void AddCategoria(Categoria categoria);
        void UpdateCategoria(Categoria categoria);
        Task DeleteCategoria(int id);
    }
}
