using System;
using System.Collections.Generic;
using System.Text;
using GorillaRoasters.Models;
using System.ComponentModel;

namespace GorillaRoasters.ViewModels
{
    public class StartPageViewModel: INotifyPropertyChanged
    {
        private CoffeeInfoModel _coffeeInfoModel;
        private List<CoffeeInfoModel> _coffeeList;
        private int _index;
        public CoffeeInfoModel CoffeeInfoModel 
        {
            get => _coffeeInfoModel;
            set
            {
                if (_coffeeInfoModel == value) return;
                _coffeeInfoModel = value;
                OnPropertyChanged("CoffeeInfoModel");
            }
        }
        public StartPageViewModel()
        {
            _index = 0;
            _coffeeList = new List<CoffeeInfoModel>();
            _coffeeList.Add(new CoffeeInfoModel 
            {
                Name = "Jungle Expresso", 
                From = "By UXDivers", 
                Price = "$ 2.75",
                ImageSrc = "ExpressoCup.jpg",
                PreparationParams = new PreparationParamsModel
                {
                    Intensity = "Strong",
                    Acidity = "Sharp",
                    Preparation = "8 minutes",
                    Size = "Small"
                }
            }
            );
            _coffeeList.Add(new CoffeeInfoModel
            {
                Name = "Latte",
                From = "By CoffeeShop",
                Price = "$ 3.25",
                ImageSrc = "Latte.png",
                PreparationParams = new PreparationParamsModel
                {
                    Intensity = "Soft",
                    Acidity = "Sharp",
                    Preparation = "12 minutes",
                    Size = "Big"
                }
            }
           );
            _coffeeList.Add(new CoffeeInfoModel
            {
                Name = "Americano",
                From = "By StarBucks",
                Price = "$ 1.99",
                ImageSrc = "Americano.jpg",
                PreparationParams = new PreparationParamsModel
                {
                    Intensity = "Middle",
                    Acidity = "Sharp",
                    Preparation = "10 minutes",
                    Size = "Middle"
                }
            }
           );
            CoffeeInfoModel = _coffeeList[_index];
        }
        public void GoToNext()
        {
            if (_index >= _coffeeList.Count - 1)
                _index = 0;
            else
                _index++;
            CoffeeInfoModel = _coffeeList[_index];
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
