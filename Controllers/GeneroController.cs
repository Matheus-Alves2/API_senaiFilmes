﻿using api_filmes_senai.Domains;
using api_filmes_senai.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_filmes_senai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class GeneroController : ControllerBase
    {
        private readonly IGeneroRepository _generoRepository;

        public GeneroController(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;
        }
        /// <summary>
        /// Endpoint para buscar um Genero pelo seu Id
        /// </summary>
        /// <param name="id">Id do Genero buscado</param>
        /// <returns>Genero Buscado</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_generoRepository.Listar());
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para buscar um Genero pelo seu Id
        /// </summary>
        /// <param name="id">Id do Genero buscado</param>
        /// <returns>Genero Buscado</returns>
        [Authorize]
        [HttpPost]
        public IActionResult Post(Genero novoGenero)
        {
            try
            {
                _generoRepository.Cadastrar(novoGenero);
                return Created();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        /// <summary>
        /// Endpoint para buscar um Genero pelo seu Id
        /// </summary>
        /// <param name="id">Id do Genero buscado</param>
        /// <returns>Genero Buscado</returns>
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Genero generoBuscado = _generoRepository.BuscarPorID(id);
                return Ok(generoBuscado);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }

        }
        /// <summary>
        /// Endpoint para buscar um Genero pelo seu Id
        /// </summary>
        /// <param name="id">Id do Genero buscado</param>
        /// <returns>Genero Buscado</returns>
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _generoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Endpoint para buscar um Genero pelo seu Id
        /// </summary>
        /// <param name="id">Id do Genero buscado</param>
        /// <returns>Genero Buscado</returns>
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Genero genero)
        {
            try
            {
                _generoRepository.Atualizar(id, genero);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }














    }
}

