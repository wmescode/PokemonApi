using Microsoft.AspNetCore.Mvc;
using Pokemon.Domain.DTOs;
using Pokemon.Domain.Entities;
using Pokemon.Domain.UseCases;

namespace Pokemon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PokemonMasterController : ControllerBase
    {
        private readonly IPokemonMasterService _pokeMasterService;
        public PokemonMasterController(IPokemonMasterService pokeMasterService)
        {
            _pokeMasterService = pokeMasterService;
        }

        // Método para registrar um novo treinador (master) de Pokémon.
        [HttpPost("register")]
        public async Task<IActionResult> RegisterPokemonMaster([FromBody] PokemonMasterCreateDTO masterDTO)
        {
            try
            {
                var pokemonMaster = new PokemonMaster
                {
                    name = masterDTO.Name,
                    age = masterDTO.Age,
                    cpf = masterDTO.Cpf,
                    email = masterDTO.Email
                };

                await _pokeMasterService.RegisterPokemonMaster(pokemonMaster);
                return Ok("Treinador registrado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao registrar o treinador: {ex.Message}");
            }
        }

        // Método para registrar uma nova captura de Pokémon.
        [HttpPost("capture")]
        public async Task<IActionResult> RegisterPokemonCapture([FromBody] PokemonCaptured pokemonCaptured)
        {
            try
            {
                await _pokeMasterService.RegisterPokemonCapture(pokemonCaptured);
                return Ok("Pokémon capturado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao registrar a captura: {ex.Message}");
            }
        }

        // Método para obter a lista de Pokémon capturados por um treinador através do nome do treinador.
        [HttpGet("captured-list/{name}")]
        public async Task<IActionResult> GetListPokemonCapturedByMasterName(string name)
        {
            try
            {
                var pokemons = await _pokeMasterService.GetListPokemonCaputuredByMasterName(name);
                if (pokemons == null || pokemons.Count == 0)
                {
                    return NotFound($"Nenhum Pokémon capturado encontrado para o treinador: {name}");
                }
                return Ok(pokemons);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao obter a lista de Pokémon capturados: {ex.Message}");
            }
        }
    }
}
