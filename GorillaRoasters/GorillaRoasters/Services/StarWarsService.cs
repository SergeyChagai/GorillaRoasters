using GorillaRoasters.Models.StarWarModels.DALModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GorillaRoasters.Services
{
    class StarWarsService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseURL = "https://swapi.dev/api/";

        public StarWarsService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<CaractersResponseModel> GetCharacters()
        {
            var response = await _httpClient.GetAsync(_baseURL+"people/");
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CaractersResponseModel>(json) ?? 
                new CaractersResponseModel();

            return result;
        }

        public async void PushCharacter()
        {
            throw new NotImplementedException();
        }
    }
}
