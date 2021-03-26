using GorillaRoasters.Models.StarWarModels.DALModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Mime;
using System.Threading.Tasks;

namespace GorillaRoasters.Services
{
    public class StarWarsSimpleService: IStarWarsService
    {
        private readonly HttpClient _httpClient;

        public StarWarsSimpleService()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://swapi.dev/api/")
            };
        }
        public async Task<CaractersResponseModel> GetCharacters()
        {
            var response = await _httpClient.GetAsync("people/");
            Debug.WriteLine("Http client use for Get");
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CaractersResponseModel>(json) ?? 
                new CaractersResponseModel();

            return result;
        }

        public async Task<bool> PushCharacter(CharacterInfoModel characterInfo)
        {
            var json = JsonConvert.SerializeObject(characterInfo);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var result = (await _httpClient.PostAsync("people/", httpContent)).StatusCode != 
                System.Net.HttpStatusCode.OK ? false : true;
            Debug.WriteLine("Http client use for Post");
            return result;
        }
    }
}
