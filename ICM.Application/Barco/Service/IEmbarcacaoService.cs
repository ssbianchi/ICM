using ICM.Application.Barco.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Application.Barco.Service
{
    public interface IEmbarcacaoService
    {
        Task<List<EmbarcacaoOutputDto>> GetAllEmbarcacoes();
        Task<bool> CriarEmbarcacao(EmbarcacaoInputDto dto);
        Task<bool> EditarEmbarcacao(EmbarcacaoInputDto dto);
        Task<bool> DeletarEmbarcacao(string nomeContaSocio);
    }
}
