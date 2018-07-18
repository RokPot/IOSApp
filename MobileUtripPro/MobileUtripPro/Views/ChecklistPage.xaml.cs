using System;
using System.Collections.Generic;
using MobileUtripPro.ViewModels;
using Xamarin.Forms;

namespace MobileUtripPro.Views
{
    public partial class ChecklistPage : ContentPage
    {
        public ChecklistPage()
        {
            InitializeComponent();
            BindingContext = new ChecklistPageViewModel() 
            {
                Navigation = Navigation
            };
        }
    }
}
