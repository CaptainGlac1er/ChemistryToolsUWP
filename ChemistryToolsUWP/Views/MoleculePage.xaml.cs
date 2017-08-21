using ChemistryToolsUWP.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace ChemistryToolsUWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MoleculePage : Page
    {
        Template10.Services.SerializationService.ISerializationService _SerializationService;
        public MoleculePage()
        {
            this.InitializeComponent();
            _SerializationService = Template10.Services.SerializationService.SerializationService.Json;
            NavigationCacheMode = NavigationCacheMode.Disabled;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.MoleculeToShow  = (Molecule) _SerializationService.Deserialize(e.Parameter?.ToString());
        }
    }
}
