﻿using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Services;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {

        CinemaService _cinemaService;
        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }
  

        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            ReadCinemaDto readCinemaDto = _cinemaService.AdicionaCinema(cinemaDto);
            
            return CreatedAtAction(nameof(RecuperaCinemasPorId), new { Id = readCinemaDto.Id }, readCinemaDto);
        }

        [HttpGet]
        public IActionResult RecuperaCinemas([FromQuery] string nomeDoFilme)
        {
            List<ReadCinemaDto> readCinema = _cinemaService.RecuperaCinemas(nomeDoFilme);
           
            if(readCinema == null)
                return NotFound();
            return Ok(readCinema);     
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemasPorId(int id)
        {
            ReadCinemaDto readCinema = _cinemaService.RecuperaCinemasPorId(id);
           
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            Result resultado = _cinemaService.AtualizaCinema(id, cinemaDto);
            if (resultado.IsFailed)
                return NotFound();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            Result resultado = _cinemaService.DeletaCinema(id);
            if (resultado.IsFailed)
                return NotFound();
            return NoContent();
        }

    }
}
