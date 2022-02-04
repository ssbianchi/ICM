using ICM.Application.Barco.Dto;
using ICM.Domain.Barco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Application.Barco.Profile
{
    public class EmbarcacaoProfile : AutoMapper.Profile
    {
        public EmbarcacaoProfile()
        {
            CreateMap<EmbarcacaoInputDto, Embarcacao>();

            CreateMap<Embarcacao, EmbarcacaoOutputDto>();
        }
    }
}
