using System;
using System.Collections.Generic;

using Xamarin.Forms;
using MobileUtripPro.ViewModels;
namespace MobileUtripPro.Views
{
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
            BindingContext = new RegistrationPageViewModel() { };
        }
    }
}
