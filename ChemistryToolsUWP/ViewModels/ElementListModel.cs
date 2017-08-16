using ChemistryToolsUWP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace ChemistryToolsUWP.ViewModels
{
    public class ElementListModel : ViewModelBase
    {
        private string _SearchTerm = "";
        public PeriodicTable Table
        {
            get
            {
                Debug.WriteLine(PeriodicTable.PeriodTableData == null ? "yes" : "no");
                return PeriodicTable.PeriodTableData;
            }
            set
            {
                if(value != PeriodicTable.PeriodTableData)
                {
                    PeriodicTable.PeriodTableData = value;
                    RaisePropertyChanged();
                }
            }
        }
        private ObservableCollection<Element> _SearchableCollection = PeriodicTable.PeriodTableData.Elements;
        public string SearchTerm
        {
            get
            {
                return _SearchTerm;
            }
            set
            {
                if (_SearchTerm != value)
                {
                    _SearchTerm = value;
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        SearchableCollection = Table.Elements;
                        RaisePropertyChanged();
                    }
                    else
                    {
                        ObservableCollection<Element> limitedCollection = new ObservableCollection<Element>();
                        foreach (Element e in Table.Elements)
                            if (e.Name.ToLower().Contains(value.ToLower()) || e.ChemicalSymbol.ToLower().Contains(value.ToLower()) || value == "")
                                limitedCollection.Add(e);
                        SearchableCollection = limitedCollection;
                        RaisePropertyChanged();
                    }
                }                      

            }
        }
        public ObservableCollection<Element> SearchableCollection
        {
            get
            {
                return _SearchableCollection;
            }
            set
            {
                if(_SearchableCollection != value)
                {
                    _SearchableCollection = value;
                    RaisePropertyChanged();
                }
            }
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            if (suspensionState.Any())
            {
            }
            await Task.CompletedTask;
        }
        public void GotoElement(Element element) =>
            NavigationService.Navigate(typeof(Views.ElementPage), element);
    }
}
