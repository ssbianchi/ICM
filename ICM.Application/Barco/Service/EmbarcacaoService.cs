using AutoMapper;
using ICM.Application.Barco.Dto;
using ICM.CrossCutting.Exception;
using ICM.CrossCutting.Notification;
using ICM.Domain.Barco;
using ICM.Domain.Barco.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Application.Barco.Service
{
    public class EmbarcacaoService : IEmbarcacaoService
    {
        private readonly IMapper _mapper;
        private readonly IEmbarcacaoRepository _embarcacaoRepository;

        public EmbarcacaoService(IMapper mapper, IEmbarcacaoRepository embarcacaoRepository)
        {
            _mapper = mapper;
            _embarcacaoRepository = embarcacaoRepository;
        }
        public async Task<bool> CriarEmbarcacao(EmbarcacaoInputDto dto)
        {
            var businessException = new BusinessException();

            if ((await _embarcacaoRepository.GetOneByCriteria(x => x.RegistroMarinha == dto.RegistroMarinha) != null))
            {
                businessException.AddError(new BusinessValidation() { Message = "Registro da Marinha já cadastrado na base para outra embarcação, por favor tente outro" });
            }

            businessException.ValidateAndThrow();

            var embarcacao = _mapper.Map<Embarcacao>(dto);
            //embarcacao.ValidateAndThrow();

            using (var transaction = await _embarcacaoRepository.CreateTransaction())
            {
                try
                {
                    await _embarcacaoRepository.Save(embarcacao);
                    var notification = new NotificationMessage(new Message(new
                    {
                        RegistroMarinha = embarcacao.RegistroMarinha,
                        Nome = embarcacao.Nome,
                        Id = embarcacao.Id
                    }));

                    await transaction.CommitAsync();

                    return true;
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }

            }
        }

        public async Task<bool> DeletarEmbarcacao(string registroMarinha)
        {
            var businessException = new BusinessException();

            var embarcacao = await _embarcacaoRepository.GetOneByCriteria(x => x.RegistroMarinha == registroMarinha);
            if (embarcacao == null)
                businessException.AddError(new BusinessValidation() { Message = "Embarcação com o Registro da Marinha não existe." });

            businessException.ValidateAndThrow();

            using (var transaction = await _embarcacaoRepository.CreateTransaction())
            {
                try
                {
                    await _embarcacaoRepository.Delete(embarcacao);
                    var notification = new NotificationMessage(new Message(new
                    {
                        RegistroMarinha = embarcacao.RegistroMarinha,
                        Nome = embarcacao.Nome,
                        Id = embarcacao.Id
                    }));

                    await transaction.CommitAsync();

                    return true;
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task<bool> EditarEmbarcacao(EmbarcacaoInputDto dto)
        {
            var businessException = new BusinessException();

            var embarcacao = await _embarcacaoRepository.GetOneByCriteria(x => x.RegistroMarinha == dto.RegistroMarinha);
            if (embarcacao == null)
                businessException.AddError(new BusinessValidation() { Message = "Embarcação com o Registro da Marinha não existe." });

            businessException.ValidateAndThrow();

            embarcacao.TipoVaga = dto.TipoVaga;

            using (var transaction = await _embarcacaoRepository.CreateTransaction())
            {
                try
                {
                    await _embarcacaoRepository.Update(embarcacao);
                    var notification = new NotificationMessage(new Message(new
                    {
                        RegistroMarinha = embarcacao.RegistroMarinha,
                        Nome = embarcacao.Nome,
                        Id = embarcacao.Id
                    }));

                    await transaction.CommitAsync();

                    return true;
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task<List<EmbarcacaoOutputDto>> GetAllEmbarcacoes()
        {
            try
            {
                var embarcacao = await _embarcacaoRepository.GetAll();

                var embarcacaoDto = _mapper.Map<List<EmbarcacaoOutputDto>>(embarcacao);

                return embarcacaoDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
