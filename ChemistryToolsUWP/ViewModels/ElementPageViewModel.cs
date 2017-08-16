using ChemistryToolsUWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;

namespace ChemistryToolsUWP.ViewModels
{
    public class ElementPageViewModel : ViewModelBase
    {
        Element elementToShow;
        public Element ElementToShow
        {
            get { return elementToShow; }
            set { Set(ref elementToShow, value); }
        }
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            ElementToShow = (Element) ((suspensionState.ContainsKey(nameof(ElementToShow))) ? suspensionState[nameof(ElementToShow)] : parameter);
            await Task.CompletedTask;
        }

        public override async Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending)
        {
            if (suspending)
            {
                suspensionState[nameof(ElementToShow)] = ElementToShow;
            }
            await Task.CompletedTask;
        }

        public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            args.Cancel = false;
            await Task.CompletedTask;
        }
    }
}
