using System;
using System.Collections.Generic;

#nullable disable

namespace Pessoas.Models
{
    public partial class EstadoCivil
    {
        public EstadoCivil()
        {
            Pessoas = new HashSet<Pessoa>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Ativado { get; set; }

        public virtual ICollection<Pessoa> Pessoas { get; set; }
    }
}
