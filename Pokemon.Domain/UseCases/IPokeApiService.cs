using Pokemon.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Domain.UseCases
{
    public interface IPokeApiService
    {
        Task<PokemonDTO?> GetPokemonById(int id);

        Task<List<PokemonEvolutionDTO>?> GetEvolutionChainById(int id);
    }
}
