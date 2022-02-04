using ICM.Application.Conta.Dto;
using ICM.Domain.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Application.Conta.Profile
{
    public class SocioProfile : AutoMapper.Profile
    {
        public SocioProfile()
        {
            CreateMap<SocioInputDto, Socio>()
                .IncludeAllDerived()
                .ForPath(x => x.InfoBasica, m => m.MapFrom(f => f.InfoBasicas))
                //.ForPath(x => x.Nome, m => m.MapFrom(f => f.Nome))
                .ForPath(x => x.CPF, m => m.MapFrom(f => f.CPF))
                .ForPath(x => x.CNPJ, m => m.MapFrom(f => f.CNPJ));

            CreateMap<Socio, SocioOutputDto>()
                .ForMember(x => x.CPF, m => m.MapFrom(f => f.CPF.Formatado));

            CreateMap<InfoBasica, InfoBasicaInputDto>();
            CreateMap<InfoBasicaInputDto, InfoBasica>();
        }
    }
}