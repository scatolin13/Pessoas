using System;
using System.Collections.Generic;

#nullable disable

namespace Pessoas.Models
{
    public partial class Deficiencium
    {
        public Deficiencium()
        {
            PessoaDeficiencia = new HashSet<PessoaDeficiencium>();
        }

        public int Id { get; private set; }
        public string Descricao { get; private set; }
        public string Detalhamento { get; private set; }
        public bool Ativado { get; private set; }

        public virtual ICollection<PessoaDeficiencium> PessoaDeficiencia { get; private set; }
    }
}
