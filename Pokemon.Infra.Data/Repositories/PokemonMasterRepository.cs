using Microsoft.EntityFrameworkCore;
using Pokemon.Domain.Entities;
using Pokemon.Domain.Repositories;
using Pokemon.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Infra.Data.Repositories
{
    public class PokemonMasterRepository : IPokemonMasterRepository
    {
        private readonly AppDbContext _context;
        public PokemonMasterRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<PokemonCaptured>?> GetListPokemonCaputuredByMasterName(string masterName)
        {
            try
            {
                return await _context.PokemonsCaptured
                    .Where(p => p.master_name == masterName)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task InsertPokemonCaptured(PokemonCaptured pokemonCaptured)
        {
            try
            {
                _context.PokemonsCaptured.Add(pokemonCaptured);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex) { 
            }
        }

        public async Task InsertPokemonMaster(PokemonMaster pokemonMaster)
        {
            try
            {
                _context.PokemonMasters.Add(pokemonMaster);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
