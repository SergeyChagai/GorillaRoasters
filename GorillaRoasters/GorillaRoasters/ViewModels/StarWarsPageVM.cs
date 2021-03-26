using GorillaRoasters.Models.StarWarModels.DALModels;
using GorillaRoasters.Models.StarWarModels.UIModels;
using GorillaRoasters.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GorillaRoasters.ViewModels
{
    public class StarWarsPageVM: INotifyPropertyChanged
    {
        public IStarWarsService Service;
        private CharacterModel _character;
        public ICommand GetCharactersCommand { get; set; }
        public ICommand PushCharacterCommand { get; set; }

        public CharacterModel Character
        {
            get => _character;
            set
            {
                _character = value;
                NotifyPropertyChanged(nameof(Character));
            }
        }
        public ObservableCollection<CharacterModel> Characters { get; set; }
        public StarWarsPageVM()
        {
            Service = new StarWarsSimpleService();
            GetCharactersCommand = new Command(GetCharactersCommandExecute);
            PushCharacterCommand = new Command(PushCharacterCommandExecute);
            Characters = new ObservableCollection<CharacterModel>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private async void GetCharactersCommandExecute()
        {
            var response = await Service.GetCharacters();
            if (response.Results == null)
                return;
            foreach(var model in response.Results)
            {
                var character = new CharacterModel
                {
                    Name = model.Name,
                    Height = model.Height,
                    Mass = model.Mass,
                    Gender = model.Gender
                };
                Characters.Add(character);
            }
        }
        private async void PushCharacterCommandExecute()
        {
            var character = new CharacterInfoModel()
            {
                Name = "Chubaka",
                Height = 270,
                Mass = 120,
                Gender = "male"
            };
            string message = await Service.PushCharacter(character) ? "OK" : "NE OK";
            Debug.WriteLine(message);
        }
    }
}
