using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Domain.Entities
{
    public class PokemonMaster
    {
        public int id {  get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string? cpf { get; set; }
        public string? email {  get; set; }  
        public List<PokemonCaptured>? captuerd_pokemons { get; set;}
    }
}
