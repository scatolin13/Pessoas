using System;
using System.Collections.Generic;

#nullable disable

namespace Pessoas.Repository.Models
{
    public partial class GrauInstrucao
    {
        public GrauInstrucao()
        {
            Pessoas = new HashSet<Pessoa>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Ativado { get; set; }

        public virtual ICollection<Pessoa> Pessoas { get; set; }
    }
}
