using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Domain.Entities
{
    public class PokemonEvolution
    {
        public string? previous_level { get; set; }
        public string current_level { get; set; }
        public int id { get; set; }
        public bool is_baby { get; set; }
    }
}
