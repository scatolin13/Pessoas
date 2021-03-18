using System;
using System.Collections.Generic;

#nullable disable

namespace Pessoas.Repository.Models
{
    public partial class TipoInscricao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Detalhamento { get; set; }
        public int TipoPessoaId { get; set; }
        public bool Ativado { get; set; }
    }
}
