﻿using api_filmes_senai.Domains;
using api_filmes_senai.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_filmes_senai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class FilmeController : ControllerBase
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeController(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }
        /// <summary>
        /// Endpoint para buscar um Filme pelo seu Id
        /// </summary>
        /// <param name="id">Id do Filme buscado</param>
        /// <returns>Filme Buscado</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Filme> listaDeFilmes = _filmeRepository.Listar();
                return Ok(listaDeFilmes);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        /// <summary>
        /// Endpoint para buscar um Filme pelo seu Id
        /// </summary>
        /// <param name="id">Id do Filme buscado</param>
        /// <returns>Filme Buscado</returns>
        [HttpPost]
        public IActionResult Post (Filme novoFilme)
        {
            try
            {
                _filmeRepository.Cadastrar(novoFilme);
                return Created();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        /// <summary>
        /// Endpoint para buscar um Filme pelo seu Id
        /// </summary>
        /// <param name="id">Id do Filme buscado</param>
        /// <returns>Filme Buscado</returns>
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Filme novoFilme = _filmeRepository.BuscarPorId(id);
                return Ok(novoFilme);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        /// <summary>
        /// Endpoint para buscar um Filme pelo seu Id
        /// </summary>
        /// <param name="id">Id do Filme buscado</param>
        /// <returns>Filme Buscado</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _filmeRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        /// <summary>
        /// Endpoint para buscar um Filme pelo seu Id
        /// </summary>
        /// <param name="id">Id do Filme buscado</param>
        /// <returns>Filme Buscado</returns>

        [HttpPut("{id}")]
        public IActionResult Put (Guid id, Filme novoFilme)
        {
            try
            {
                _filmeRepository.Atualizar(id, novoFilme);
                return NoContent();    
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        /// <summary>
        /// Endpoint para buscar um Filme pelo seu Id
        /// </summary>
        /// <param name="id">Id do Filme buscado</param>
        /// <returns>Filme Buscado</returns>

        [HttpGet("ListarPorGenero/{id}")]
        public IActionResult GetByGenero(Guid id)
        {
            try
            {
                List<Filme> listaDeFilmePorGenero = _filmeRepository.ListarPorGenero(id);
                return Ok(listaDeFilmePorGenero);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
