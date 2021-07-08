﻿using System;

namespace Pessoas.DTO.Request
{
    public class PessoaDTO
    {
        public string IdNoSql { get; set; }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeSocial { get; set; }
        public string Cpf { get; set; }
        public int? SexoId { get; set; }
        public int? RacaCorId { get; set; }
        public int? EstadoCivilId { get; set; }
        public int? GrauInstrucaoId { get; set; }
        public DateTime? DataNascimento { get; set; }
        public int? Nacionalidade { get; set; }
        public int? Naturalidade { get; set; }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public bool PessoaDigital { get; set; }
    }
}
