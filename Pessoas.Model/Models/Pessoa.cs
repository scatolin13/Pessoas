using System;
using System.Collections.Generic;

#nullable disable

namespace Pessoas.Models
{
    public partial class Pessoa
    {
        public Pessoa()
        {
            PessoaDeficiencia = new HashSet<PessoaDeficiencia>();
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string NomeSocial { get; private set; }
        public string Cpf { get; private set; }
        public string Cpfsimples { get; private set; }
        public int? SexoId { get; private set; }
        public int? RacaCorId { get; private set; }
        public int? EstadoCivilId { get; private set; }
        public int? GrauInstrucaoId { get; private set; }
        public bool PossuiDeficiencia { get; private set; }
        public DateTime? DataNascimento { get; private set; }
        public int? Nacionalidade { get; private set; }
        public int? Naturalidade { get; private set; }
        public string NomePai { get; private set; }
        public string NomeMae { get; private set; }
        public bool PessoaDigital { get; set; }
        public bool Ativado { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime? DataExclusao { get; private set; }

        public virtual EstadoCivil EstadoCivil { get; private set; }
        public virtual GrauInstrucao GrauInstrucao { get; private set; }
        public virtual RacaCor RacaCor { get; private set; }
        public virtual Sexo Sexo { get; private set; }
        public virtual ICollection<PessoaDeficiencia> PessoaDeficiencia { get; private set; }
    }
}
