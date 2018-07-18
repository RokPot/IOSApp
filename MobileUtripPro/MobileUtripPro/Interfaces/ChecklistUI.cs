using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MobileUtripPro.Models;

namespace MobileUtripPro.Interfaces
{
    public class ChecklistUI : INotifyPropertyChanged
    {
        public CheckItem Check { get; set; }

        private bool _isChecked = false;
        public bool IsChecked { 
            get
            {
                return _isChecked;
            }

            set {
                _isChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            if(PropertyChanged != null){
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                if (propertyName == "IsChecked")
                {
                    Check.IsChecked = IsChecked;
                }
            }

        }
    }
}
