using GestaoGastoResidencial.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoGastoResidencial.Domain.Entities
{
    public class Transacao
    {
        [Key]
        public int Id { get; set; }
        public string Descrição { get; set; }
        public decimal Valor { get; set; }
        public TipoTransacao Tipo { get; set; }

        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

        [ForeignKey("Pessoa")]
        public int PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }

    }
}
