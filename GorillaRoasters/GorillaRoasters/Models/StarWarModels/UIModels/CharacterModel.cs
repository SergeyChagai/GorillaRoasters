using System;
using System.Collections.Generic;
using System.Text;

namespace GorillaRoasters.Models.StarWarModels.UIModels
{
    public class CharacterModel
    {
        public string Name { get; set; }
        public int Height { get; set; }
        public int Mass { get; set; }
        public string Gender { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is CharacterModel character)
                return character.Name == Name &&
                    character.Height == Height &&
                    character.Mass == Mass &&
                    character.Gender == Gender;
            return false;
        }
    }
}
