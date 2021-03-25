using GorillaRoasters.Models.StarWarModels.UIModels;
using GorillaRoasters.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GorillaRoasters.ViewModels
{
    public class StarWarsPageVM: INotifyPropertyChanged
    {
        private readonly StarWarsService _service;
        private CharacterModel _character;
        public ICommand GetCharacters { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

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
            _service = new StarWarsService();
            GetCharacters = new Command(GetCharactersExecute);
            Characters = new ObservableCollection<CharacterModel>();
        }
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private async void GetCharactersExecute()
        {
            var response = await _service.GetCharacters();
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
    }
}
