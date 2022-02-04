using ICM.Application.Conta.Dto;
using ICM.Application.Conta.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaSocioController : ControllerBase
    {
        private readonly ISocioService _socioService;

        public ContaSocioController(ISocioService socioService)
        {
            _socioService = socioService;
        }

        [HttpGet("GetSocios")]
        public async Task<IActionResult> GetSocios()
        {
            var result = await _socioService.GetAllSocios();
            if (!result?.Any() ?? false)
                return NotFound($"Não existem sócios na base");

            return Ok(result);
        }

        [HttpPost("SaveContaSocio")]
        public async Task<IActionResult> SaveContaSocio(SocioInputDto dto)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var result = await _socioService.CriarContaSocio(dto);
            if (!result)
                return NotFound($"Não foi possível criar a conta do sócio na base");

            return Ok(result);
        }

        [HttpPut("AlterarContaSocio")]
        public async Task<IActionResult> AlterarContaSocio(SocioInputDto dto)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var result = await _socioService.EditarContaSocio(dto);
            if (!result)
                return NotFound($"Não foi possível alterar a conta do sócio na base");

            return Ok(result);
        }

        [HttpDelete("ApagarContaSocio")]
        public async Task<IActionResult> ApagarContaSocio(string nomeContaSocio)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var result = await _socioService.DeletarContaSocio(nomeContaSocio);
            if (!result)
                return NotFound($"Não foi possível apagar a conta do sócio na base");

            return Ok(result);
        }
    }
}
