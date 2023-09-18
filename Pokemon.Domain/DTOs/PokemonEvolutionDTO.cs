using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Domain.DTOs
{
    public class PokemonEvolutionDTO
    {
        public string? PreviousLevel { get; set; }
        public string CurrentLevel { get; set; }
        public int Id { get; set; } 
        public bool IsBaby { get; set; }        
    }
}
