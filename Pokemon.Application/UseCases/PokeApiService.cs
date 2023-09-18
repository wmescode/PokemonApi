using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Pokemon.Domain.DTOs;
using Pokemon.Domain.Helpers;
using Pokemon.Domain.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Application.UseCases
{
    public class PokeApiService : IPokeApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _apiSettings;

        public PokeApiService(IOptions<ApiSettings> apiSettings)
        {
            _apiSettings = apiSettings.Value;
            //_httpClient = new HttpClient { BaseAddress = new Uri(_apiSettings.BaseAddress) };
            _httpClient = new HttpClient(new HttpClientHandler { AllowAutoRedirect = true });
            _httpClient.BaseAddress = new Uri(_apiSettings.BaseAddress);
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537");
        }

        public async Task<List<PokemonEvolutionDTO>?> GetEvolutionChainById(int id)
        {
            var response = await _httpClient.GetAsync($"evolution-chain/{id}");

            if (!response.IsSuccessStatusCode)
                return null;

            var previsaoAsString = await response.Content.ReadAsStringAsync();
            var teste1 = await response.Content.ReadAsByteArrayAsync();

            EvolutionChainDTO? evolutionChainDto = JsonConvert.DeserializeObject<EvolutionChainDTO>(previsaoAsString);

            List<PokemonEvolutionDTO>? pokemonEvolutionDTO = null;

            if (evolutionChainDto != null)
            {
                pokemonEvolutionDTO = ExtractEvolutionChain(evolutionChainDto);
            }
                
            return pokemonEvolutionDTO;
        }

        public async Task<PokemonDTO?> GetPokemonById(int id)
        {
            var response = await _httpClient.GetAsync($"pokemon/{id}");

            if (!response.IsSuccessStatusCode)
                return null;

            var previsaoAsString = await response.Content.ReadAsStringAsync();

            PokemonDTO? pokemonDTO = JsonConvert.DeserializeObject<PokemonDTO>(previsaoAsString);

            var json = JsonConvert.DeserializeObject(previsaoAsString);

            if (pokemonDTO == null || pokemonDTO.sprites?.front_default == null)
                return null;

            var imageResponse = await _httpClient.GetByteArrayAsync(pokemonDTO.sprites.front_default);

            pokemonDTO.sprite_base64 = Convert.ToBase64String(imageResponse);            

            return pokemonDTO;
        }
        public List<PokemonEvolutionDTO> ExtractEvolutionChain(EvolutionChainDTO chainDTO)
        {
            var results = new List<PokemonEvolutionDTO>();
            
            void ExtractChain(ChainLink chainLink, int id, string previousLevel)
            {
                results.Add(new PokemonEvolutionDTO
                {
                    PreviousLevel = previousLevel,
                    CurrentLevel = chainLink.Species.Name,
                    Id = id,
                    IsBaby = chainLink.IsBaby
                });

                foreach (var nextLink in chainLink.EvolvesTo)
                {
                    ExtractChain(nextLink, id, chainLink.Species.Name);
                    previousLevel = nextLink.Species.Name;
                }
            }

            ExtractChain(chainDTO.Chain, chainDTO.Id, "");

            return results;
        }       
    }
}
