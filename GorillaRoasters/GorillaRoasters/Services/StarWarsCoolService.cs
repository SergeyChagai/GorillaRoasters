using GorillaRoasters.Models.StarWarModels.DALModels;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace GorillaRoasters.Services
{
    public class StarWarsCoolService: IStarWarsService
    {
        public IStarWarsApi Api { get; set; }
        public StarWarsCoolService()
        {
            var settings = new RefitSettings();

            Api = RestService.For<IStarWarsApi>("https://swapi.dev/api");
            
        }

        public async Task<CaractersResponseModel> GetCharacters()
        {
            var message = await Api.GetCharacters();
            Debug.WriteLine("Rest API use for Get");

            var json = await message.Content.ReadAsStringAsync();
            CaractersResponseModel result = new CaractersResponseModel();
            if (message.IsSuccessStatusCode)
                result = JsonConvert.DeserializeObject<CaractersResponseModel>(json);
            return result;
            //var result = await Api.GetCharacters();
            //return result;
        }

        public async Task<bool> PushCharacter(CharacterInfoModel characterInfo)
        {
            var message = await Api.PushCharacter(characterInfo);
            Debug.WriteLine("Rest API use for Post");
            if (message.IsSuccessStatusCode)
                return true;
            return false;
        }
    }
}
