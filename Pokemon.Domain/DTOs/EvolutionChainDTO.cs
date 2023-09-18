using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Domain.DTOs
{
    public class EvolutionChainDTO
    {
        [JsonProperty("baby_trigger_item")]
        public object BabyTriggerItem { get; set; }
        [JsonProperty("chain")]
        public ChainLink Chain { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
    }

    public class ChainLink
    {
        [JsonProperty("evolution_details")]
        public List<EvolutionDetail> EvolutionDetails { get; set; } = new();
        [JsonProperty("evolves_to")]
        public List<ChainLink> EvolvesTo { get; set; } = new();
        [JsonProperty("is_baby")]
        public bool IsBaby { get; set; }
        [JsonProperty("species")]
        public Species Species { get; set; }
    }

    public class EvolutionDetail
    {
        public object Gender { get; set; }
        public object HeldItem { get; set; }
        public object Item { get; set; }
        public object KnownMove { get; set; }
        public object KnownMoveType { get; set; }
        public object Location { get; set; }
        public object MinAffection { get; set; }
        public object MinBeauty { get; set; }
        public object MinHappiness { get; set; }
        public int? MinLevel { get; set; }
        public bool NeedsOverworldRain { get; set; }
        public object PartySpecies { get; set; }
        public object PartyType { get; set; }
        public object RelativePhysicalStats { get; set; }
        public string TimeOfDay { get; set; }
        public object TradeSpecies { get; set; }
        public Trigger Trigger { get; set; }
        public bool TurnUpsideDown { get; set; }
    }

    public class Trigger
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class Species
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
