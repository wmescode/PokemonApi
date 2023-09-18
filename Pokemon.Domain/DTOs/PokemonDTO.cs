using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Domain.DTOs
{
    public class PokemonDTO
    {
        public int id { get; set; }
        public string? name { get; set; }
        public int base_experience { get; set; }
        public int height { get; set; }
        public int order { get; set; }
        public int weight { get; set; }
        public string? type { get; set; }
        public Sprites? sprites { get; set; }
        public string? sprite_base64 { get; set; }
    }

    public class Sprites
    {
        public string? front_default { get; set; }
    }
}
