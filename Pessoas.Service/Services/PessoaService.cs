using CustomMapper;
using Pessoas.DTO.Request;
using Pessoas.DTO.Response;
using Pessoas.Models;
using Pessoas.Repository.Interfaces;
using Pessoas.Service.Interfaces;
using Pessoas.Service.Queues;
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
            }
            catch (System.Exception ex)
            {
                res.Message.Add("Falha ao buscar registro");
                res.Message.Add(ex.Message);
            }

            return res;
        }

        public async Task<ResponseBase<IEnumerable<PessoaDTO>>> RetornarPorCpf(params string[] cpf)
        {
            var res = new ResponseBase<IEnumerable<PessoaDTO>>();

            try
            {
                var customMapper = new CustomAutoMapper<Pessoa, PessoaDTO>();
                var pessoas = await repository.RetornarPorCpf(cpf);

                res.Entities = customMapper.Map(pessoas);
            }
            catch (System.Exception ex)
            {
                res.Message.Add("Falha ao buscar registro");
                res.Message.Add(ex.Message);
            }

            return res;
        }

        public async Task<ResponseBase<PessoaResponse>> Inserir(params PessoaDTO[] entities)
        {
            var listModel = new List<Pessoa>();
            var res = new ResponseBase<PessoaResponse>();
            var pessoaResponse = new PessoaResponse();
            int invalidos = 0;
            try
            {
                foreach (var entity in entities)
                {
                    var model = new Pessoa();

                    if (await repository.ExistePorCpf(entity.Cpf))
                    {
                        pessoaResponse.AddNotification("CPF", $"{entity.Cpf} já se encontra cadastrado");
                        invalidos++;
                    }
                    else
                    {
                        model
                            .Cadastrar(entity.Nome, entity.NomeSocial, entity.Cpf, entity.SexoId)
                            .AdicionarInformacoes(entity.RacaCorId, entity.EstadoCivilId, entity.GrauInstrucaoId)
                            .AdicionarInformacoesNascimento(entity.DataNascimento, entity.Nacionalidade, entity.Naturalidade)
                            .AdicionarFiliacao(entity.NomePai, entity.NomeMae);

                        if (model.IsValid)
                            listModel.Add(model);
                        else
                        {
                            pessoaResponse.Join(model);
                            invalidos++;
                        }
                    }
                }

                if (listModel.Any(o => o.IsValid))
                {
                    repository.Inserir(listModel.Where(o => o.IsValid).ToArray());

                    await repository.SaveChanges();

                    pessoaResponse.Id = listModel.Where(o => o.Id > 0).Select(o => o.Id).ToList();

                    res.Message.Add($"{listModel.Count(o => o.IsValid)} registro(s) inserido(s) com sucesso.");

                    var serviceBus = new ServiceBus("localhost");

                    serviceBus.SendQueue(new QueueRequest<List<Pessoa>>()
                    {
                        QueueName = "queuePessoas",
                        Value = listModel
                    });
                }

                if (invalidos > 0)
                {
                    res.Message.Add($"{invalidos} registro(s) não inserido(s).");
                }

                res.Entities = pessoaResponse;

            }
            catch (System.Exception ex)
            {
                res.Message.Add("Falha ao inserir registro(s)");
                res.Message.Add(ex.Message);
            }

            return res;
        }

        public async Task<ResponseBase<PessoaResponse>> Atualizar(params PessoaDTO[] entities)
        {
            var listModel = new List<Pessoa>();
            var res = new ResponseBase<PessoaResponse>();
            var pessoaResponse = new PessoaResponse();
            int invalidos = 0;

            try
            {
                foreach (var entity in entities)
                {

                    if (await repository.ExistePorId(entity.Id))
                    {
                        var model = new Pessoa(entity.Id);

                        model
                            .Atualizar(entity.Nome, entity.NomeSocial, entity.Cpf, entity.SexoId)
                            .AdicionarInformacoes(entity.RacaCorId, entity.EstadoCivilId, entity.GrauInstrucaoId)
                            .AdicionarInformacoesNascimento(entity.DataNascimento, entity.Nacionalidade, entity.Naturalidade)
                            .AdicionarFiliacao(entity.NomePai, entity.NomeMae);

                        if (model.IsValid)
                            listModel.Add(model);
                        else
                        {
                            pessoaResponse.Join(model);
                            invalidos++;
                        }
                    }
                    else
                    {
                        pessoaResponse.AddNotification("Id", $"{entity.Id} não localizado.");
                        invalidos++;
                    }
                }

                if (listModel.Any(o => o.IsValid))
                {
                    repository.Atualizar(listModel.Where(o => o.IsValid).ToArray());

                    await repository.SaveChanges();

                    pessoaResponse.Id = listModel.Where(o => o.Id > 0).Select(o => o.Id).ToList();

                    res.Message.Add($"{ listModel.Count(o => o.IsValid)} registro(s) alterado(s) com sucesso");
                }

                if (invalidos > 0)
                {
                    res.Message.Add($"{invalidos} registro(s) não alterado(s).");
                }

                res.Entities = pessoaResponse;
            }
            catch (System.Exception ex)
            {
                res.Message.Add("Falha ao alterar registro(s)");
                throw ex;
            }

            return res;
        }

        public async Task<ResponseBase<PessoaResponse>> Excluir(params PessoaDTO[] entities)
        {
            var listModel = new List<Pessoa>();
            var res = new ResponseBase<PessoaResponse>();
            var pessoaResponse = new PessoaResponse();

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

                    pessoaResponse.Id = listModel.Where(o => o.Id > 0).Select(o => o.Id).ToList();

                    res.Entities = pessoaResponse;
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
