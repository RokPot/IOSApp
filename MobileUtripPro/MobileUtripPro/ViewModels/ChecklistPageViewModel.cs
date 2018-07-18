using System;
using System.ComponentModel;
using MobileUtripPro.Extensions;
using Xamarin.Forms;
using Rg.Plugins.Popup.Extensions;
using MobileUtripPro.Views;
using System.Collections.ObjectModel;
using MobileUtripPro.Models;
using MobileUtripPro.Interfaces;

namespace MobileUtripPro.ViewModels
{
    public class ChecklistPageViewModel : NavigationView, INotifyPropertyChanged
    {
        public ChecklistPageViewModel()
        {
            CheckForMessages();
        }
        public ObservableCollection<ChecklistUI> CheckList { get => _checklist; set => _checklist = value; }

        public ObservableCollection<ChecklistUI> _checklist = new ObservableCollection<ChecklistUI>()
        {
            new ChecklistUI(){
                Check = new CheckItem(){
                    CheckTitle = "1 - Preveri kvaliteto noža",
                    CheckDescription = "Odpri stroj, preglej vsako rezilo in  jih po potrebi zamenjaj z novimi",
                    NativeNumber = "15/51",
                    Sarza = "123121"
                },
                IsChecked = false
            } ,
            new ChecklistUI(){
                Check =  new CheckItem(){
                    CheckTitle = "2 - Preveri Olje",
                    CheckDescription = "Odpri stroj, preveri vsa olja v stroju",
                    NativeNumber = "16/51",
                    Sarza = "123121"
                },
                IsChecked = false
            },
            new ChecklistUI(){
                Check = new CheckItem(){
                    CheckTitle = "3 - Preveri za špene",
                    CheckDescription = "Odpri stroj preglej špentrak če so v stroju ostružki le-te počisti!",
                    NativeNumber = "9/110",
                    Sarza = ""
                },
                IsChecked = false
            }
        };
        public Command<object> EditNotes
            {
            get
            {
                return new Command<object>(async(parameter) =>
                {
                    var arg = parameter  as CheckItem;
                    foreach(var itm in CheckList)
                    {
                        if (itm.Check.CheckTitle == arg.CheckTitle && itm.Check.CheckDescription == arg.CheckDescription)
                        {
                            
                            await Navigation.PushPopupAsync(new InsertCheckListNoteDetails(itm.Check));
                        }
                    }

                });
            }
        }
        private void CheckForMessages()
        {
            MessagingCenter.Subscribe<InsertCheckListNoteDetailsViewModel, CheckItem>(this, "RefreshCheckList", (sender, arg) =>
            {
                foreach(var itm in CheckList)
                {
                    if(itm.Check.CheckTitle == arg.CheckTitle && itm.Check.CheckDescription == arg.CheckDescription)
                    {
                        itm.Check = arg;
                        itm.IsChecked = itm.Check.IsChecked;
                        CheckList.Add(new ChecklistUI());
                        CheckList.RemoveAt(CheckList.Count - 1);

                        return;
                    }
                }
            });
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
