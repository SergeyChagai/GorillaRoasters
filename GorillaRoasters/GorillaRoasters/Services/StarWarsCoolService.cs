using GorillaRoasters.Models.StarWarModels.DALModels;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GorillaRoasters.Services
{
    public class StarWarsCoolService
    {
        public IStarWarsApi Api { get; set; }
        public StarWarsCoolService()
        {
            Api = RestService.For<IStarWarsApi>("https://swapi.dev/api");
        }

        public async Task<CaractersResponseModel> GetCharacters()
        {
            var message = await Api.GetCharacters();
            var json = await message.Content.ReadAsStringAsync();
            CaractersResponseModel result = new CaractersResponseModel();
            if (message.IsSuccessStatusCode)
                result = JsonConvert.DeserializeObject<CaractersResponseModel>(json);
            return result;
        }

        public async Task<bool> PushCharacter(CharacterInfoModel characterInfo)
        {
            var message = await Api.PushCharacter(characterInfo);
            if (message.IsSuccessStatusCode)
                return true;
            return false;
        }
    }
}
