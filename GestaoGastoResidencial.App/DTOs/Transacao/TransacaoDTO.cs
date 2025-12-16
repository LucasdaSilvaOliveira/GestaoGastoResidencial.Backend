using GestaoGastoResidencial.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestaoGastoResidencial.App.DTOs.Transacao
{
    public class TransacaoDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TipoTransacao Tipo { get; set; }
        public int CategoriaId { get; set; }
        public int PessoaId { get; set; }
    }
}
