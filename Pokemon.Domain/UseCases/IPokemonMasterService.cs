using Pokemon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Domain.UseCases
{
    public interface IPokemonMasterService
    {
        Task RegisterPokemonMaster(PokemonMaster pokemonMaster);
        Task RegisterPokemonCapture(PokemonCaptured pokemonCaptured);
        Task<List<PokemonCaptured>?> GetListPokemonCaputuredByMasterName(string name);
    }
}