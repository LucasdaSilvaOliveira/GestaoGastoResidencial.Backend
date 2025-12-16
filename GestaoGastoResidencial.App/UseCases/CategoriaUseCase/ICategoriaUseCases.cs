using GestaoGastoResidencial.App.DTOs.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoGastoResidencial.App.UseCases.CategoriaUseCase
{
    public interface ICategoriaUseCases
    {
        void AddCategoria(CriarCategoriaDTO dto);
        Task<IEnumerable<CategoriaDTO>> GetCategorias();
        Task<CategoriaDTO> GetCategoriaById(int id);
        Task UpdateCategoria(CategoriaDTO categoria);
        Task DeleteCategoria(int id);
    }
}
