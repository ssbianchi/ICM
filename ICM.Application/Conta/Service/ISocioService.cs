using ICM.Application.Conta.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Application.Conta.Service
{
    public interface ISocioService
    {
        Task<List<SocioOutputDto>> GetAllSocios();
        Task<bool> CriarContaSocio(SocioInputDto dto);
        Task<bool> EditarContaSocio(SocioInputDto dto);
        Task<bool> DeletarContaSocio(string nomeContaSocio);
    }
}
