﻿using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class PokemonController : Controller
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonController(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult getPokemons() 
        {
            var pokemons = _pokemonRepository.GetPokemons();
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(pokemons == null)
            {
                return NotFound();
            }
            return Ok(pokemons);
            
        }
    }
}
