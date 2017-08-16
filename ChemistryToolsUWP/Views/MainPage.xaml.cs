using System;
using ChemistryToolsUWP.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;

namespace ChemistryToolsUWP.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        private void ElementList_SelectedElement(Models.Element element)
        {
            ViewModel.GotoElement(element);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            /*ElementList.SelectedElement -= ElementList_SelectedElement;
            ElementList.SelectedElement += ElementList_SelectedElement;*/
        }
    }
}
