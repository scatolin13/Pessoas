using System;
using System.Collections.Generic;

#nullable disable

namespace Pessoas.Models
{
    public partial class Sexo
    {
        public Sexo()
        {
            Pessoas = new HashSet<Pessoa>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        public bool Ativado { get; set; }

        public virtual ICollection<Pessoa> Pessoas { get; set; }
    }
}
