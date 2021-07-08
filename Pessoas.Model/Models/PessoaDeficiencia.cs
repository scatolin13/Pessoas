#nullable disable

namespace Pessoas.Models
{
    public partial class PessoaDeficiencia
    {
        public int Id { get; private set; }
        public int PessoaId { get; private set; }
        public int DeficienciaId { get; private set; }
        public bool Possui { get; private set; }

        public virtual Deficiencium Deficiencia { get; private set; }
        public virtual Pessoa Pessoa { get; private set; }
    }
}
