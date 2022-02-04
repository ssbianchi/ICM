using AutoMapper;
using ICM.Application.Barco.Service;
using ICM.Domain.Barco.Repository;
using ICM.Domain.Conta.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Tests.Embarcacao
{
    [TestClass]
    public class EmbarcacaoTests
    {
        private readonly IMapper _mapper;
        private readonly IEmbarcacaoRepository _embarcacaoRepository;

        [TestMethod]
        public void TestEmbarcacao()
        {
        }

        [Test]
        public void GetEmbarcacao()
        {
            var service = new EmbarcacaoService(_mapper, _embarcacaoRepository);
            var result = service.GetAllEmbarcacoes();
            NUnit.Framework.Assert.NotNull(result.Result);
        }
    }
}
