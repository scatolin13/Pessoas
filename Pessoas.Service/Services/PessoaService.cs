using CustomMapper;
using Pessoas.DTO.Request;
using Pessoas.DTO.Response;
using Pessoas.Models;
using Pessoas.Repository.Interfaces;
using Pessoas.Service.Interfaces;
using RequestResponse;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pessoas.Service.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository repository;

        public PessoaService(IPessoaRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ResponseBase<IEnumerable<PessoaDTO>>> RetornarPorId(params int[] id)
        {
            var res = new ResponseBase<IEnumerable<PessoaDTO>>();

            try
            {
                var customMapper = new CustomAutoMapper<Pessoa, PessoaDTO>();
                var pessoas = await repository.RetornarPorId(id);

                res.Entities = customMapper.Map(pessoas);

                return res;
            }
            catch (System.Exception ex)
            {
                res.Message.Add("Falha ao buscar registro");
                throw ex;
            }
        }

        public async Task<ResponseBase<IEnumerable<PessoaDTO>>> RetornarPorCpf(params string[] cpf)
        {
            var customMapper = new CustomAutoMapper<Pessoa, PessoaDTO>();
            var pessoas = await repository.RetornarPorCpf(cpf);

            var res = new ResponseBase<IEnumerable<PessoaDTO>>();

            res.Entities = customMapper.Map(pessoas);

            return res;
        }

        public async Task<ResponseBase<PessoaResponse>> Inserir(params PessoaDTO[] entities)
        {
            var listModel = new List<Pessoa>();
            var res = new ResponseBase<PessoaResponse>();

            try
            {
                foreach (var entity in entities)
                {
                    var model = new Pessoa();

                    model
                        .Cadastrar(entity.Nome, entity.NomeSocial, entity.Cpf, entity.SexoId)
                        .AdicionarInformacoes(entity.RacaCorId, entity.EstadoCivilId, entity.GrauInstrucaoId)
                        .AdicionarInformacoesNascimento(entity.DataNascimento, entity.PaisNascimento, entity.Nacionalidade, entity.Naturalidade)
                        .AdicionarFiliacao(entity.NomePai, entity.NomeMae);

                    if (model.IsValid)
                        listModel.Add(model);
                    else
                        res.Entities.Join(model);
                }

                if (listModel.Any(o => o.IsValid))
                {
                    repository.Inserir(listModel.Where(o => o.IsValid).ToArray());

                    await repository.SaveChanges();

                    res.Entities.Id = listModel.Where(o => o.Id > 0).Select(o => o.Id).ToList();

                    res.Message.Add("Registro inserido com sucesso");
                }
                else
                {
                    res.Message.Add("Nenhum registro foi inserido");
                }

            }
            catch (System.Exception ex)
            {
                res.Message.Add("Falha ao inserir registro");

                throw ex;
            }

            return res;
        }

        public async Task<ResponseBase<PessoaResponse>> Atualizar(params PessoaDTO[] entities)
        {
            var listModel = new List<Pessoa>();
            var res = new ResponseBase<PessoaResponse>();

            try
            {
                foreach (var entity in entities)
                {
                    var model = new Pessoa(entity.Id);

                    model
                        .Atualizar(entity.Nome, entity.NomeSocial, entity.Cpf, entity.SexoId)
                        .AdicionarInformacoes(entity.RacaCorId, entity.EstadoCivilId, entity.GrauInstrucaoId)
                        .AdicionarInformacoesNascimento(entity.DataNascimento, entity.PaisNascimento, entity.Nacionalidade, entity.Naturalidade)
                        .AdicionarFiliacao(entity.NomePai, entity.NomeMae);

                    if (model.IsValid)
                        listModel.Add(model);
                    else
                        res.Entities.Join(model);
                }

                if (listModel.Any(o => o.IsValid))
                {
                    repository.Atualizar(listModel.Where(o => o.IsValid).ToArray());

                    await repository.SaveChanges();

                    res.Entities.Id = listModel.Where(o => o.Id > 0).Select(o => o.Id).ToList();

                    res.Message.Add("Registro alterado com sucesso");
                }
                else
                {
                    res.Message.Add("Nenhum registro foi alterado");
                }
            }
            catch (System.Exception ex)
            {
                res.Message.Add("Falha ao alterar registro");
                throw ex;
            }

            return res;
        }

        public async Task<ResponseBase<PessoaResponse>> Excluir(params PessoaDTO[] entities)
        {
            var listModel = new List<Pessoa>();
            var res = new ResponseBase<PessoaResponse>();

            try
            {
                foreach (var entity in entities)
                {
                    var model = new Pessoa(entity.Id);

                    model.Excluir();

                    if (model.IsValid)
                        listModel.Add(model);
                    else
                        res.Entities.Join(model);
                }

                if (listModel.Any(o => o.IsValid))
                {
                    repository.Excluir(listModel.Where(o => o.IsValid).ToArray());

                    await repository.SaveChanges();

                    res.Entities.Id = listModel.Where(o => o.Id > 0).Select(o => o.Id).ToList();

                    res.Message.Add("Registro deletado com sucesso");
                }
                else
                {
                    res.Message.Add("Nenhum registro foi deletado");
                }
            }
            catch (System.Exception ex)
            {
                res.Message.Add("Falha ao deletar registro");
                throw ex;
            }


            return res;
        }
    }
}
