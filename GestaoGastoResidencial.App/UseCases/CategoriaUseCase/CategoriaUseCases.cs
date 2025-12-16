using GestaoGastoResidencial.App.DTOs.Categoria;
using GestaoGastoResidencial.Domain.Entities;
using GestaoGastoResidencial.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoGastoResidencial.App.UseCases.CategoriaUseCase
{
    public class CategoriaUseCases : ICategoriaUseCases
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaUseCases(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public void AddCategoria(CriarCategoriaDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Descricao) || dto.Finalidade == 0)
                throw new ArgumentException("Dados inválidos para criação de categoria.");

            var categoria = new Categoria
            {
                Descricao = dto.Descricao,
                Finalidade = dto.Finalidade
            };

            _categoriaRepository.AddCategoria(categoria);
        }

        public async Task DeleteCategoria(int id)
        {
            var categoria = await _categoriaRepository.GetCategoriaById(id);
            if (categoria == null)
                throw new KeyNotFoundException("Categoria não encontrada");

            await _categoriaRepository.DeleteCategoria(id);
        }

        public async Task<CategoriaDTO> GetCategoriaById(int id)
        {
            var categoria = await _categoriaRepository.GetCategoriaById(id);
            if (categoria == null)
                throw new KeyNotFoundException("Categoria não encontrada");

            return new CategoriaDTO
            {
                Id = categoria.Id,
                Descricao = categoria.Descricao,
                Finalidade = categoria.Finalidade
            };
        }

        public async Task<IEnumerable<CategoriaDTO>> GetCategorias()
        {
            var categorias = await _categoriaRepository.GetCategorias();
            return categorias.Select(c => new CategoriaDTO
            {
                Id = c.Id,
                Descricao = c.Descricao,
                Finalidade = c.Finalidade
            }).ToList();
        }

        public async Task UpdateCategoria(CategoriaDTO dto)
        {
            var categoria = await _categoriaRepository.GetCategoriaById(dto.Id);
            if (categoria == null)
                throw new KeyNotFoundException("Categoria não encontrada");

            categoria.Descricao = dto.Descricao;
            categoria.Finalidade = dto.Finalidade;

            _categoriaRepository.UpdateCategoria(categoria);
        }
    }

}
