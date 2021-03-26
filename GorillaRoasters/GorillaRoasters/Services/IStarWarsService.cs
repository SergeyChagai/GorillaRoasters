using GorillaRoasters.Models.StarWarModels.DALModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GorillaRoasters.Services
{
    public interface IStarWarsService
    {
        Task<CaractersResponseModel> GetCharacters();
        Task<bool> PushCharacter(CharacterInfoModel characterInfo);
    }
}
