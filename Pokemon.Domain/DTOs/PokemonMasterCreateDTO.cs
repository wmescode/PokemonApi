using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Domain.DTOs
{
    public class PokemonMasterCreateDTO
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
    }
}
