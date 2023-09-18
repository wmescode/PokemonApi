using Pokemon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Domain.Repositories
{
    public interface IPokemonMasterRepository
    {
        Task InsertPokemonMaster(PokemonMaster pokemonMaster);
        Task InsertPokemonCaptured(PokemonCaptured pokemonCaptured);
        Task<List<PokemonCaptured>?> GetListPokemonCaputuredByMasterName(string masterName);

    }
}
