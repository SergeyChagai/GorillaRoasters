using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GorillaRoasters.Models.StarWarModels.DALModels
{
    public class CaractersResponseModel
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("previous")]
        public object Previous { get; set; }

        [JsonProperty("results")]
        public List<CharacterInfoModel> Results { get; set; }
    }
}
