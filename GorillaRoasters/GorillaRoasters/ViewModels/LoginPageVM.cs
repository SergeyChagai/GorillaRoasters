using GorillaRoasters.StateContainers.LoginPageSC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;

namespace GorillaRoasters.ViewModels
{
    public class LoginPageVM : INotifyPropertyChanged
    {
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
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
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
