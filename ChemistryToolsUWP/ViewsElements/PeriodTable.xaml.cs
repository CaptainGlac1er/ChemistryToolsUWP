using ChemistryToolsUWP.Models;
using System;
using System.Collections.Generic;
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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ChemistryToolsUWP.ViewsElements
{
    public sealed partial class PeriodTable : UserControl
    {
        public event ElementSelected SelectedElement;
        public PeriodTable()
        {
            this.InitializeComponent();
        }

        private void ElementIconView_ElementTapped(object sender, TappedRoutedEventArgs e)
        {
            SelectedElement?.Invoke((Element)((RelativePanel)sender).Tag);
        }
    }
}
