using GestaoGastoResidencial.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestaoGastoResidencial.App.DTOs.Categoria
{
    public class CategoriaDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public FinalidadeCategoria Finalidade { get; set; }
    }
}
