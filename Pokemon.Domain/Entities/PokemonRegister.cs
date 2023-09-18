using Pokemon.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Domain.Entities
{
    public class PokemonRegister
    {
        public int id { get; set; }
        public string? name { get; set; }
        public int base_experience { get; set; }
        public int height { get; set; }
        public int order { get; set; }
        public int weight { get; set; }
        public string? type { get; set; }        
        public string? sprite_base64 { get; set; }
        public List<PokemonEvolution>? pokemon_evolution { get; set; }
    }
}
