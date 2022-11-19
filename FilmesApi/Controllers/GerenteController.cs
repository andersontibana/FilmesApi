
using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Gerente;
using FilmesApi.Models;
using FilmesApi.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private GerenteService _gerenteService;

        public GerenteController(GerenteService gerenteService)
        {
            _gerenteService = gerenteService;
        }


        [HttpPost]
        public IActionResult AdicionarGerente([FromBody] CreateGerenteDto gerenteDto)
        {
            ReadGerenteDto readGerenteDto = _gerenteService.AdicionarGerente(gerenteDto);

            return CreatedAtAction(nameof(RecuperaGerentePorId), new { Id = readGerenteDto.Id }, readGerenteDto);
        }

        [HttpGet]
        public IEnumerable<Gerente> RecuperaGerentes()
        {
            return _gerenteService.RecuperaGerentes();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaGerentePorId(int id)
        {
            ReadGerenteDto readGerenteDto = _gerenteService.RecuperaGerentePorId(id);
            if (readGerenteDto != null)
            {
                return Ok(readGerenteDto);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaGerente(int id)
        {
            Result gerente = _gerenteService.DeleteGerente(id);
            if (gerente.IsFailed)
                return NotFound();
            return Ok(gerente);
        }
    }

}