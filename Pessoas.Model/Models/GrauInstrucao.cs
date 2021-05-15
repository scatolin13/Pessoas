using System.Collections.Generic;


namespace Pessoas.Models
{
    public partial class GrauInstrucao
    {
        public GrauInstrucao()
        {
            Pessoas = new HashSet<Pessoa>();
        }

        public int Id { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativado { get; private set; }

        public virtual ICollection<Pessoa> Pessoas { get; private set; }
    }
}
