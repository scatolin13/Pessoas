using Pessoas.DTO;
using Pessoas.DTO.Request;
using Pessoas.DTO.Response;
using Pessoas.Models;
using Pessoas.Repository.Interfaces;
using Pessoas.Service.CustomAutoMapper;
using Pessoas.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pessoas.Service.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository repository;

        public PessoaService(IPessoaRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<PessoaDTO> RetornarPorId(params int[] id)
        {

            var customMapper = new CustomMapper<IEnumerable<Pessoa>, IEnumerable<PessoaDTO>>();
            var pessoas = repository.RetornarPorId(id);

            var res = customMapper.Map(pessoas);

            return res;
        }

        public IEnumerable<PessoaDTO> RetornarPorCpf(params string[] cpf)
        {
            var customMapper = new CustomMapper<IEnumerable<Pessoa>, IEnumerable<PessoaDTO>>();
            var pessoas = repository.RetornarPorCpf(cpf);

            var res = customMapper.Map(pessoas);

            return res;
        }
        
        public PessoaResponse Inserir(params PessoaDTO[] entities)
        {
            var listModel = new List<Pessoa>();
            var res = new PessoaResponse();

            foreach (var entity in entities)
            {
                var model = new Pessoa();

                model
                    .Cadastrar(entity.Nome, entity.NomeSocial, entity.Cpf, (DTO.Enum.ESexo)entity.SexoId)
                    .AdicionarInformacoes((DTO.Enum.ERacaCor)entity.RacaCorId, (DTO.Enum.EEstadoCivil)entity.EstadoCivilId, (DTO.Enum.EGrauInstrucao)entity.GrauInstrucaoId)
                    .AdicionarInformacoesNascimento(entity.DataNascimento, entity.PaisNascimento, entity.Nacionalidade, entity.Naturalidade)
                    .AdicionarFiliacao(entity.NomePai, entity.NomeMae);

                if (model.IsValid)
                    listModel.Add(model);
                else
                    res.Join(model);
            }

            if (listModel.Any(o => o.IsValid))
            {
                repository.Inserir(listModel.Where(o => o.IsValid).ToArray());

                repository.SaveChanges();

                res.Id = listModel.Where(o => o.Id > 0).Select(o => o.Id).ToArray();
            }

            return res;
        }

        public PessoaResponse Atualizar(params PessoaDTO[] entities)
        {
            var listModel = new List<Pessoa>();
            var res = new PessoaResponse();

            foreach (var entity in entities)
            {
                var model = new Pessoa(entity.Id);

                model
                    .Cadastrar(entity.Nome, entity.NomeSocial, entity.Cpf, (DTO.Enum.ESexo)entity.SexoId)
                    .AdicionarInformacoes((DTO.Enum.ERacaCor)entity.RacaCorId, (DTO.Enum.EEstadoCivil)entity.EstadoCivilId, (DTO.Enum.EGrauInstrucao)entity.GrauInstrucaoId)
                    .AdicionarInformacoesNascimento(entity.DataNascimento, entity.PaisNascimento, entity.Nacionalidade, entity.Naturalidade)
                    .AdicionarFiliacao(entity.NomePai, entity.NomeMae);

                if (model.IsValid)
                    listModel.Add(model);
                else
                    res.Join(model);
            }

            if (listModel.Any(o => o.IsValid))
            {
                repository.Atualizar(listModel.Where(o => o.IsValid).ToArray());

                repository.SaveChanges();

                res.Id = listModel.Where(o => o.Id > 0).Select(o => o.Id).ToArray();
            }

            return res;
        }

        public PessoaResponse Excluir(params PessoaDTO[] entities)
        {
            var listModel = new List<Pessoa>();
            var res = new PessoaResponse();

            foreach (var entity in entities)
            {
                var model = new Pessoa(entity.Id);

                model.Excluir();

                if (model.IsValid)
                    listModel.Add(model);
                else
                    res.Join(model);
            }

            if (listModel.Any(o => o.IsValid))
            {
                repository.Excluir(listModel.Where(o => o.IsValid).ToArray());

                repository.SaveChanges();

                res.Id = listModel.Where(o => o.Id > 0).Select(o => o.Id).ToArray();
            }

            return res;
        }
    }
}
