namespace Pessoas.Models
{
    public partial class Deficiencia
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; }
        public string Detalhamento { get; private set; }
        public bool Ativado { get; private set; }
    }
}
