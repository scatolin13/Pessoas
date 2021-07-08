using FluntValidation.Validations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Pessoas.Models
{
    public partial class Pessoa : EntityBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [NotMapped]
        public string IdNoSql { get; set; }

        public Pessoa(int id)
        {
            Id = id;
        }

        public Pessoa Cadastrar(string nome, string nomeSocial, string cpf, int? sexo, bool pessoaDigital = false)
        {
            IsNotNullOrWhiteSpace(nome, "Nome", "é obrigatório.");

            if (!pessoaDigital)
            {
                IsCPF(cpf, "CPF", "inválido");
                IsNotNull(sexo, "Sexo", "é obrigatório");
                IfNotNull(sexo, o => IsBetween(sexo.Value, 1, 2, "Sexo", "inválido"));
            }

            if (IsValid)
            {
                Nome = nome;
                NomeSocial = nomeSocial;
                Cpf = cpf;
                PessoaDigital = pessoaDigital;
                Cpfsimples = Regex.Replace(cpf, "[^0-9]+", "");
                SexoId = sexo;
                DataCadastro = DateTime.Now;
            }

            return this;
        }

        public Pessoa Atualizar(string nome, string nomeSocial, string cpf, int? sexo)
        {
            IsGreaterThan(Id, 0, "Pessoa", "não localizado");
            IsNotNullOrWhiteSpace(nome, "Nome", "é obrigatório.");

            if (!PessoaDigital)
            {
                IsCPF(cpf, "CPF", "inválido");
                IsNotNull(sexo, "Sexo", "é obrigatório");
                IfNotNull(sexo, o => IsBetween(sexo.Value, 1, 2, "Sexo", "inválido"));
            }

            if (IsValid)
            {
                Nome = nome;
                NomeSocial = nomeSocial;
                Cpf = cpf;
                Cpfsimples = Regex.Replace(cpf, "[^0-9]+", "");
                SexoId = sexo;
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

        public Pessoa AdicionarInformacoesNascimento(DateTime? dataNascimento, int? nacionalidade, int? naturalidade)
        {
            IfNotNull(dataNascimento, o => IsBetween(dataNascimento.Value, DateTime.Now.AddYears(-200), DateTime.Now, "Data de nascimento", "inválida"));
            IfNotNull(nacionalidade, o => IsGreaterThan(nacionalidade.Value, 0, "Nacionalidade", "inválido"));
            IfNotNull(naturalidade, o => IsGreaterThan(naturalidade.Value, 0, "Naturalidade", "inválido"));

            if (IsValid)
            {
                DataNascimento = dataNascimento;
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
