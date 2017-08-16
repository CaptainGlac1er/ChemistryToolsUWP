using ChemistryToolsUWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace ChemistryToolsUWP.ViewModels
{
    class PeriodicTableViewModel : ViewModelBase
    {
        public PeriodicTable Table
        {
            get
            {
                return PeriodicTable.PeriodTableData;
            }
            set
            {
                if (value != PeriodicTable.PeriodTableData)
                {
                    PeriodicTable.PeriodTableData = value;
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
    }
}
