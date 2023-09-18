using Pokemon.Domain.Entities;
using Pokemon.Domain.Repositories;
using Pokemon.Domain.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Application.UseCases
{
    public class PokemonMasterService : IPokemonMasterService
    {
        private readonly IPokemonMasterRepository _repository;
        public PokemonMasterService(IPokemonMasterRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<PokemonCaptured>?> GetListPokemonCaputuredByMasterName(string name)
        {
            try
            {
                return await _repository.GetListPokemonCaputuredByMasterName(name);
            }catch (Exception ex) 
            {
                return null;
            }
            
        }

        public async Task RegisterPokemonCapture(PokemonCaptured pokemonCaptured)
        {
            try
            {
                await _repository.InsertPokemonCaptured(pokemonCaptured);

            }catch (Exception ex) { }
        }

        public async Task RegisterPokemonMaster(PokemonMaster pokemonMaster)
        {
            try
            {
                await _repository.InsertPokemonMaster(pokemonMaster);
            }catch  (Exception ex) { }
        }
    }
}
