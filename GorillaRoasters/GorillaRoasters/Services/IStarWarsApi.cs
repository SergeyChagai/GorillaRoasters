using GorillaRoasters.Models.StarWarModels.DALModels;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GorillaRoasters.Services
{
    public interface IStarWarsApi
    {
        [Get("/people/")]
        Task<HttpResponseMessage> GetCharacters();
        [Post("/people/")]
        Task<HttpResponseMessage> PushCharacter(CharacterInfoModel characterInfo);
    }
}
