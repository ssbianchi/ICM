using ICM.Application.Barco.Dto;
using ICM.Application.Barco.Service;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ICM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmbarcacaoController : Controller
    {
        private readonly IEmbarcacaoService _embarcacaoService;

        public EmbarcacaoController(IEmbarcacaoService embarcacaoService)
        {
            _embarcacaoService = embarcacaoService;
        }

        [HttpGet("GetEmbarcacoes")]
        public async Task<IActionResult> GetEmbarcacoes()
        {
            var result = await _embarcacaoService.GetAllEmbarcacoes();
            if (!result?.Any() ?? false)
                return NotFound($"Não existem embarcações na base");

            return Ok(result);
        }

        [HttpPost("SaveEmbarcacao")]
        public async Task<IActionResult> SaveContaSocio(EmbarcacaoInputDto dto)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var result = await _embarcacaoService.CriarEmbarcacao(dto);
            if (!result)
                return NotFound($"Não foi possível criar a embarcação na base");

            return Ok(result);
        }

        [HttpPut("AlterarEmbarcacao")]
        public async Task<IActionResult> AlterarEmbarcacao(EmbarcacaoInputDto dto)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var result = await _embarcacaoService.EditarEmbarcacao(dto);
            if (!result)
                return NotFound($"Não foi possível alterar a embarcação na base");

            return Ok(result);
        }

        [HttpDelete("ApagarEmbarcacao")]
        public async Task<IActionResult> ApagarEmbarcacao(string registroMarinha)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var result = await _embarcacaoService.DeletarEmbarcacao(registroMarinha);
            if (!result)
                return NotFound($"Não foi possível apagar a embarcação na base");

            return Ok(result);
        }
    }
}
