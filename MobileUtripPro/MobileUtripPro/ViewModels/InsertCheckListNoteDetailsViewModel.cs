using System;
using System.ComponentModel;
using MobileUtripPro.Extensions;
using MobileUtripPro.Models;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace MobileUtripPro.ViewModels
{
    public class InsertCheckListNoteDetailsViewModel : NavigationView, INotifyPropertyChanged
    {
        public InsertCheckListNoteDetailsViewModel()
        {
        }
        public CheckItem CheckItm { get; set; }

        public CheckItem OriginalCheckItm { get; set; }

        public int SelectedIndex { get; set; }

        public Command Cancel
        {
            get
            {
                return new Command(async() => {
                    CheckItm = OriginalCheckItm;
                    await Navigation.PopPopupAsync();
                });
            }
        }
        public Command SubmitChanges
        {
            get
            {
                return new Command(async () => {
                    OriginalCheckItm = CheckItm;
                        CheckItm.IsChecked = SelectedIndex == 1 ? false : true;
                    MessagingCenter.Send<InsertCheckListNoteDetailsViewModel, CheckItem>(this, "RefreshCheckList", CheckItm);
                    await Navigation.PopPopupAsync();

                });
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
