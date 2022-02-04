using AutoMapper;
using ICM.Application.Conta.Dto;
using ICM.Application.Conta.Service;
using ICM.Domain.Conta;
using ICM.Domain.Conta.Repository;
using ICM.Domain.Conta.ValueObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Collections.Generic;

namespace ICM.Tests.Conta
{
    [TestClass]
    public class SocioTests
    {
        private readonly IMapper _mapper;
        private readonly ISocioRepository _socioRepository;

        [TestMethod]
        public void TestSocioConta()
        {
            var nome = "Sergio Bianchi";
            var cpf = "11571129780";
            var email = "sergio.bianchi@infnet.al.edu.br";
            var tel = "(21) 97515-7146";

            var infoBasica = new List<InfoBasicaInputDto>() { new InfoBasicaInputDto() { Email = email, NumTelefone = tel } };

            var contaSocio = new SocioInputDto()
            {
                Nome = nome,
                CPF = cpf,
                InfoBasicas = infoBasica
            };
            var service = new SocioService(_mapper, _socioRepository);
            var result = service.CriarContaSocio(contaSocio);

            NUnit.Framework.Assert.IsTrue(result.Result);
        }

        [Test]
        public void GetSocioConta()
        {
            var service = new SocioService(_mapper, _socioRepository);
            var result = service.GetAllSocios();
            NUnit.Framework.Assert.NotNull(result.Result);
        }


    }
}
