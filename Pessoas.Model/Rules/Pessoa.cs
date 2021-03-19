using FluntValidation.Validations;
using Pessoas.DTO.Enum;
using System;

namespace Pessoas.Models
{
    public partial class Pessoa : EntityBase
    {
        public Pessoa(int id)
        {
            Id = id;
        }

        public Pessoa Cadastrar(string nome, string nomeSocial, string cpf, ESexo sexo)
        {
            IsNotNullOrWhiteSpace(nome, "Nome", "é obrigatório.");
            IsCPF(Cpf, "CPF", "inválido");
            
            if (IsValid)
            {
                Nome = nome;
                NomeSocial = nomeSocial;
                TipoInscricaoId = 1; // CPF
                Cpf = cpf;
                SexoId = (int)sexo;
            }

            return this;
        }

        public Pessoa AdicionarInformacoes(ERacaCor? racaCor, EEstadoCivil? estadoCivil, EGrauInstrucao? grauInstrucao)
        {
            RacaCorId = (int)racaCor;
            EstadoCivilId = (int)estadoCivil;
            GrauInstrucaoId = (int)grauInstrucao;

            return this;
        }

        public Pessoa AdicionarInformacoesNascimento(DateTime dataNascimento, int? paisNascimento, int? nacionalidade, int? naturalidade)
        {
            IsLowerOrEqualsThan(dataNascimento, DateTime.Now, "Data de nascimento", "não pode ser maior que a data atual");
            IfNotNull(paisNascimento, o => IsGreaterThan(paisNascimento.Value, 0, "País de nascimento", "inválido"));
            IfNotNull(nacionalidade, o => IsGreaterThan(nacionalidade.Value, 0, "Nacionalidade", "inválido"));
            IfNotNull(naturalidade, o => IsGreaterThan(naturalidade.Value, 0, "Naturalidade", "inválido"));

            if (IsValid)
            {
                PaisNascimento = paisNascimento;
                Nacionalidade = nacionalidade;
                Naturalidade = naturalidade;
            }

            return this;
        }

        public Pessoa AdicionarFiliacao(string nomePai, string nomeMae)
        {
            IsNotNullOrWhiteSpace(nomeMae, "Nome da mãe", "é obrigatório");

            if (IsValid)
            {
                NomePai = nomePai;
                NomeMae = nomeMae;
            }
            return this;
        }
    }
}
