using System;
using System.Collections.Generic;
using MobileUtripPro.Models;
using MobileUtripPro.ViewModels;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace MobileUtripPro.Views
{
    public partial class InsertCheckListNoteDetails : PopupPage
    {
        public InsertCheckListNoteDetails()
        {
            InitializeComponent();
        }
        public InsertCheckListNoteDetails(CheckItem ch)
        {
            InitializeComponent();
            BindingContext = new InsertCheckListNoteDetailsViewModel()
            {
                CheckItm = new CheckItem()
                {
                    CheckTitle = ch.CheckTitle,
                    CheckDescription = ch.CheckDescription,
                    Sarza = ch.Sarza,
                    NativeNumber = ch.NativeNumber,
                    Notes = ch.Notes,
                    IsChecked = ch.IsChecked
                },
                SelectedIndex = ch.IsChecked == true ? 0 : 1,
                Navigation = Navigation,
                OriginalCheckItm = ch
            };
        }
    }
}
