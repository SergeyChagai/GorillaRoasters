using GorillaRoasters.StateContainers.LoginPageSC;
using GorillaRoasters.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GorillaRoasters.ViewModels
{
    public class LoginPageVM : INotifyPropertyChanged
    {
        private bool _isToggled;
        public bool IsToggled 
        { 
            get => _isToggled;
            set
            {
                _isToggled = value;
                NotifyPropertyChanged(nameof(IsToggled));
            }
        }
        private string _userName;
        public string Username 
        {
            get => _userName;
            set
            {
                if (RegularExpressionUtilities.IsValidEmail(value))
                {
                    _userName = value;
                }
                else _userName = "";
            }
        }

        public string Password { get; set; }

        public ICommand SetLoginDataCommand { get; set; }
        private States _pageStateId;
        public States PageStateId 
        {
            get => _pageStateId;
            set
            {
                _pageStateId = value;
                NotifyPropertyChanged(nameof(PageStateId));
            }
        }
        public LoginPageVM()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.None)
            {
                PageStateId = States.NotConnected;
            }
            else
                PageStateId = States.Connected;
            Connectivity.ConnectivityChanged += ChangePageState;
            Username = "";
            Password = "";
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public async void GetLoginData()
        {
            try
            {
                Username = await SecureStorage.GetAsync(nameof(Username));
                Password = await SecureStorage.GetAsync(nameof(Password));
            }
            catch { }
        }
        public async void SetLoginData()
        {
            if(IsToggled)
            {
                try
                {
                    await SecureStorage.SetAsync(nameof(Username), Username);
                    await SecureStorage.SetAsync(nameof(Password), Password);
                }
                catch { }
            }
        }

        public void ChangePageState(object sender, ConnectivityChangedEventArgs e)
        {
            if(e == null) return;
            if (e.NetworkAccess == NetworkAccess.None)
            {
                PageStateId = States.NotConnected;
            }
            else
                PageStateId = States.Connected;
        }
    }
}
