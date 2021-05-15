using FluntValidation.Validations;
using System;

namespace Pessoas.Models
{
    public partial class Pessoa : EntityBase
    {
        public Pessoa(int id)
        {
            Id = id;
        }

        public Pessoa Cadastrar(string nome, string nomeSocial, string cpf, int? sexo)
        {
            IsNotNullOrWhiteSpace(nome, "Nome", "é obrigatório.");
            IsCPF(cpf, "CPF", "inválido");
            IsNotNull(sexo, "Sexo", "é obrigatório");
            IfNotNull(sexo, o => IsBetween(sexo.Value, 1, 2, "Sexo", "inválido"));

            if (IsValid)
            {
                Nome = nome;
                NomeSocial = nomeSocial;
                TipoInscricaoId = 1; // CPF
                CPF = cpf;
                SexoId = (int)sexo;
            }

            return this;
        }

        public Pessoa Atualizar(string nome, string nomeSocial, string cpf, int? sexo)
        {
            IsGreaterThan(Id, 0, "Pessoa", "não localizado");
            IsNotNullOrWhiteSpace(nome, "Nome", "é obrigatório.");
            IsCPF(cpf, "CPF", "inválido");
            IsNotNull(sexo, "Sexo", "é obrigatório");
            IfNotNull(sexo, o => IsBetween(sexo.Value, 1, 2, "Sexo", "inválido"));

            if (IsValid)
            {
                Nome = nome;
                NomeSocial = nomeSocial;
                TipoInscricaoId = 1; // CPF
                CPF = cpf;
                SexoId = (int)sexo;
            }

            return this;
        }

        public Pessoa AdicionarInformacoes(int? racaCor, int? estadoCivil, int? grauInstrucao)
        {
            RacaCorId = racaCor;
            EstadoCivilId = estadoCivil;
            GrauInstrucaoId = grauInstrucao;

            return this;
        }

        public Pessoa AdicionarInformacoesNascimento(DateTime dataNascimento, int? paisNascimento, int? nacionalidade, int? naturalidade)
        {
            IsBetween(dataNascimento, DateTime.Now.AddYears(-200), DateTime.Now, "Data de nascimento", "inválida");
            IfNotNull(paisNascimento, o => IsGreaterThan(paisNascimento.Value, 0, "País de nascimento", "inválido"));
            IfNotNull(nacionalidade, o => IsGreaterThan(nacionalidade.Value, 0, "Nacionalidade", "inválido"));
            IfNotNull(naturalidade, o => IsGreaterThan(naturalidade.Value, 0, "Naturalidade", "inválido"));

            if (IsValid)
            {
                DataNascimento = dataNascimento;
                PaisNascimentoId = paisNascimento;
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

        public Pessoa Excluir()
        {
            IsGreaterThan(Id, 0, "Pessoa", "não localizada");

            return this;
        }
    }
}
