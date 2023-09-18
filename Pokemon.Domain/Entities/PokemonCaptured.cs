using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Domain.Entities
{
    public class PokemonCaptured
    {
        public string master_name {  get; set; }        
        public string pokemon_name { get; set; }
        public DateTime capture_date { get; set; }
    }
}
