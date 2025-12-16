using GestaoGastoResidencial.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoGastoResidencial.App.DTOs.Categoria
{
    public class CriarCategoriaDTO
    {
        public string Descricao { get; set; }
        public FinalidadeCategoria Finalidade { get; set; }
    }
}
