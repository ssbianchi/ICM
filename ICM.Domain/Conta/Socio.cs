using FluentValidation;
using ICM.CrossCutting.Entity;
using ICM.Domain.Conta.Rules;
using ICM.Domain.Conta.ValueObject;
using ICM.Domain.Responsavel;
using ICM.Domain.Titulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Domain.Conta
{
    public class Socio : Entity<int>
    {
        public string Nome { get; set; }
        public CPF CPF { get; set; }
        public CNPJ CNPJ { get; set; }
        
        public IList<InfoBasica> InfoBasica { get; set; }
        public IList<HabilitacaoNautica> HabilitacaoNautica { get; set; }
        public IList<Dependente> Dependente { get; set; }
        public void ValidateAndThrow() => new SocioValidator().ValidateAndThrow(this);
    }
}
