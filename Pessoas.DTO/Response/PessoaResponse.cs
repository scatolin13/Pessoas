using FluntValidation.Validations;
using System.Collections.Generic;

namespace Pessoas.DTO.Response
{
    public class PessoaResponse : EntityBase
    {
        public PessoaResponse()
        {
            Id = new List<int>();
        }

        public List<int> Id { get; set; }
    }
}
