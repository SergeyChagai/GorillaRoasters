using System;
using System.Collections.Generic;
using System.Text;
using GorillaRoasters.Models;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace GorillaRoasters.ViewModels
{
    public class MainPageViewModel: INotifyPropertyChanged
    {
        private CoffeeInfoModel _coffeeInfoModel;
        private List<CoffeeInfoModel> _coffeeList;
        private int _index;
        private List<PreparationParamModel> _preparationParams;
        public CoffeeInfoModel CoffeeInfoModel 
        {
            get => _coffeeInfoModel;
            set
            {
                if (_coffeeInfoModel == value) return;
                _coffeeInfoModel = value;
                _preparationParams = _coffeeInfoModel.PreparationParams;
                OnPropertyChanged(nameof(CoffeeInfoModel));
            }
        }
        public List<PreparationParamModel> PreparationParams
        {
            get => _preparationParams;
            set
            {
                _preparationParams = value;
                OnPropertyChanged(nameof(PreparationParams));
            }
        }
        public ICommand ChangeItem { get; set; }
        public MainPageViewModel()
        {
            _index = 0;
            _coffeeList = new List<CoffeeInfoModel>();
            _coffeeList.Add(new CoffeeInfoModel 
            {
                Name = "Jungle Expresso", 
                From = "By UXDivers", 
                Price = "$ 2.75",
                ImageSrc = "ExpressoCup.jpg",
                PreparationParams = new List<PreparationParamModel>
                {
                    new PreparationParamModel{IconSrc = "intensity.ico", Name = "Intensity", Value = "Strong"},
                    new PreparationParamModel{IconSrc = "acidity.jpg", Name = "Acidity", Value = "Sharp"},
                    new PreparationParamModel{IconSrc = "preparation.jpg", Name = "Preparation", Value = "8 minutes"},
                    new PreparationParamModel{IconSrc = "size.jpg", Name = "Size", Value = "Small"}
                }
            }
            );
            _coffeeList.Add(new CoffeeInfoModel
            {
                Name = "Latte",
                From = "By CoffeeShop",
                Price = "$ 3.25",
                ImageSrc = "Latte.png",
                PreparationParams = new List<PreparationParamModel>
                {
                    new PreparationParamModel{IconSrc = "intensity.ico", Name = "Intensity", Value = "Soft"},
                    new PreparationParamModel{IconSrc = "acidity.jpg", Name = "Acidity", Value = "Sharp"},
                    new PreparationParamModel{IconSrc = "preparation.jpg", Name = "Preparation", Value = "12 minutes"},
                    new PreparationParamModel{IconSrc = "size.jpg", Name = "Size", Value = "Big"}
                }
            }
           );
            _coffeeList.Add(new CoffeeInfoModel
            {
                Name = "Americano",
                From = "By StarBucks",
                Price = "$ 1.99",
                ImageSrc = "Americano.jpg",
                PreparationParams = new List<PreparationParamModel>
                {
                    new PreparationParamModel{IconSrc = "intensity.ico", Name = "Intensity", Value = "Middle"},
                    new PreparationParamModel{IconSrc = "acidity.jpg", Name = "Acidity", Value = "Sharp"},
                    new PreparationParamModel{IconSrc = "preparation.jpg", Name = "Preparation", Value = "10 minutes"},
                    new PreparationParamModel{IconSrc = "size.jpg", Name = "Size", Value = "Middle"}
                }
            }
           );
            _coffeeList.Add(new CoffeeInfoModel
            {
                Name = "Donut",
                From = "By Сrumpets",
                Price = "$ 0.75",
                ImageSrc = "Donut.jpg",
                PreparationParams = new List<PreparationParamModel>
                {
                    new PreparationParamModel{IconSrc = "taste.png", Name = "Taste", Value = "Strawberry"}
                }
            }
          );
            CoffeeInfoModel = _coffeeList[_index];
            PreparationParams = CoffeeInfoModel.PreparationParams;
            ChangeItem = new Command(GoToNext);
        }
        private void GoToNext()
        {
            if (_index >= _coffeeList.Count - 1)
                _index = 0;
            else
                _index++;
            CoffeeInfoModel = _coffeeList[_index];
            PreparationParams = CoffeeInfoModel.PreparationParams;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
