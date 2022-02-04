using AutoMapper;
using ICM.Application.Conta.Dto;
using ICM.CrossCutting.Exception;
using ICM.CrossCutting.Notification;
using ICM.Domain.Conta;
using ICM.Domain.Conta.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Application.Conta.Service
{
    public class SocioService : ISocioService
    {
        private readonly IMapper _mapper;
        private readonly ISocioRepository _socioRepository;
        public SocioService(IMapper mapper, ISocioRepository socioRepository)
        {
            _mapper = mapper;
            _socioRepository = socioRepository;
        }
        public async Task<List<SocioOutputDto>> GetAllSocios()
        {
            try
            {
                var socios = await _socioRepository.GetAll();

                var socioDto = _mapper.Map<List<SocioOutputDto>>(socios);

                return socioDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<bool> CriarContaSocio(SocioInputDto dto)
        {
            var businessException = new BusinessException();

            if ((await _socioRepository.GetOneByCriteria(x => x.CPF.Valor == dto.CPF) != null))
            {
                businessException.AddError(new BusinessValidation() { Message = "CPF já cadastrado na base, por favor tente outro" });
            }
            if (dto.CNPJ != null && (await _socioRepository.GetOneByCriteria(x => x.CNPJ.Valor == dto.CNPJ) != null))
            {
                businessException.AddError(new BusinessValidation() { Message = "CNPJ já cadastrado na base, por favor tente outro" });
            }

            businessException.ValidateAndThrow();

            var conta = _mapper.Map<Socio>(dto);
            conta.ValidateAndThrow();

            using (var transaction = await _socioRepository.CreateTransaction())
            {
                try
                {
                    await _socioRepository.Save(conta);
                    var notification = new NotificationMessage(new Message(new
                    {
                        CNPJ = conta.CNPJ,
                        CPF = conta.CPF.Valor,
                        Id = conta.Id
                    }));

                    //return _mapper.Map<SocioOutputDto>(conta);
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

        public async Task<bool> EditarContaSocio(SocioInputDto dto)
        {
            var businessException = new BusinessException();

            var contaSocio = await _socioRepository.GetOneByCriteria(x => x.CPF.Valor == dto.CPF);
            if (contaSocio == null)
                businessException.AddError(new BusinessValidation() { Message = "Conta do sócio com o nome não existe." });

            businessException.ValidateAndThrow();

            contaSocio.Nome = dto.Nome;
            contaSocio.ValidateAndThrow();


            using (var transaction = await _socioRepository.CreateTransaction())
            {
                try
                {
                    await _socioRepository.Update(contaSocio);
                    var notification = new NotificationMessage(new Message(new
                    {
                        CNPJ = contaSocio.CNPJ,
                        CPF = contaSocio.CPF.Valor,
                        Id = contaSocio.Id
                    }));

                    //return _mapper.Map<SocioOutputDto>(conta);
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

        public async Task<bool> DeletarContaSocio(string nomeContaSocio)
        {
            var businessException = new BusinessException();

            var contaSocio = await _socioRepository.GetOneByCriteria(x => x.Nome == nomeContaSocio);
            if (contaSocio == null)
                businessException.AddError(new BusinessValidation() { Message = "Conta do sócio com o nome não existe." });

            businessException.ValidateAndThrow();

            using (var transaction = await _socioRepository.CreateTransaction())
            {
                try
                {
                    await _socioRepository.Delete(contaSocio);
                    var notification = new NotificationMessage(new Message(new
                    {
                        CNPJ = contaSocio.CNPJ,
                        CPF = contaSocio.CPF.Valor,
                        Id = contaSocio.Id
                    }));

                    //return _mapper.Map<SocioOutputDto>(conta);
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
    }
}

