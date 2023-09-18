using Pokemon.Domain.DTOs;
using Pokemon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Application.Mappings
{
    public static class PokemonDTOTOPokemon
    {
        public static PokemonRegister ConvertPokemonDTOTOPokemonRegister(PokemonDTO pokemonDTO, List<PokemonEvolutionDTO>? pokemonEvolutionDTO)
        {
            var pokemonRegister = new PokemonRegister
            {
                id = pokemonDTO.id,
                name = pokemonDTO.name,
                height = pokemonDTO.height,
                weight = pokemonDTO.weight,
                sprite_base64 = pokemonDTO.sprite_base64,
                base_experience = pokemonDTO.base_experience,
                type = pokemonDTO.type,
                pokemon_evolution = pokemonEvolutionDTO?.Select(evolution => new PokemonEvolution
                {
                    id = evolution.Id,
                    current_level = evolution.CurrentLevel,
                    previous_level = evolution.PreviousLevel,
                    is_baby = evolution.IsBaby
                }).ToList() ?? new List<PokemonEvolution>()
            };

            return pokemonRegister;
        }
    }
}
