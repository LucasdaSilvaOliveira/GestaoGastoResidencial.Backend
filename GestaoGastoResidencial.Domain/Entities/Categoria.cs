using GestaoGastoResidencial.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoGastoResidencial.Domain.Entities
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public FinalidadeCategoria Finalidade { get; set; }
    }
}
