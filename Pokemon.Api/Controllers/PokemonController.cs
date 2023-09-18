using Microsoft.AspNetCore.Mvc;
using Pokemon.Application.Mappings;
using Pokemon.Domain.DTOs;
using Pokemon.Domain.Entities;
using Pokemon.Domain.UseCases;

namespace Pokemon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokeApiService _pokeApiService;
        
        
        public PokemonController(IPokeApiService pokeApiService)
        {
            _pokeApiService = pokeApiService;
        }
        [ProducesResponseType(typeof(PokemonRegister), 200)]
        [HttpGet("GetPokemon/{id}")]
        public async Task<IActionResult> GetPokemon(int id)
        {
            try
            {
                PokemonDTO? pokemonDTO = await _pokeApiService.GetPokemonById(id);

                List<PokemonEvolutionDTO>? evolutionChainDTO = await _pokeApiService.GetEvolutionChainById(id);

                if (pokemonDTO == null) return NotFound();

                PokemonRegister pokemonRegister = PokemonDTOTOPokemon.ConvertPokemonDTOTOPokemonRegister(pokemonDTO, evolutionChainDTO);

                return Ok(pokemonRegister);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro interno. Por favor, tente novamente mais tarde.");
            }
        }

        [ProducesResponseType(typeof(List<PokemonRegister>), 200)]
        [HttpGet("GetRandomPokemons")]
        public async Task<IActionResult> GetRandomPokemons()
        {
            try
            {
                const int totalPokemons = 1000;
                const int numberOfRandomPokemons = 10;
                var random = new Random();
                
                var randomIds = new HashSet<int>();
                while (randomIds.Count < numberOfRandomPokemons)
                {
                    randomIds.Add(random.Next(1, totalPokemons + 1));
                }

                var pokemonRegisters = new List<PokemonRegister>();

                foreach (var id in randomIds)
                {
                    PokemonDTO? pokemonDTO = await _pokeApiService.GetPokemonById(id);

                    List<PokemonEvolutionDTO>? evolutionChainDTO = await _pokeApiService.GetEvolutionChainById(id);

                    if (pokemonDTO != null)
                    {
                        var pokemonRegister = PokemonDTOTOPokemon.ConvertPokemonDTOTOPokemonRegister(pokemonDTO, evolutionChainDTO);
                        pokemonRegisters.Add(pokemonRegister);
                    }
                }

                return Ok(pokemonRegisters);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro interno. Por favor, tente novamente mais tarde.");
            }
        }
    }
}
