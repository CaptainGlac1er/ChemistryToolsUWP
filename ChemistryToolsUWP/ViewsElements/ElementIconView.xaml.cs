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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ChemistryToolsUWP.ViewsElements
{
    public delegate void ElementTapped(object sender, TappedRoutedEventArgs e);
    public sealed partial class ElementIconView : UserControl
    {
        public event ElementTapped ElementTapped;
        public Element ElementShown
        {
            get
            {
                return ViewModel.ElementToShow;
            }
            set
            {
                ViewModel.ElementToShow = value;
            }
        }
        public ElementIconView()
        {
            this.InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Resize();
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Resize();
        }
        private void Resize()
        {
            if (ActualWidth <= 75)
            {
                ElementName.Visibility = Visibility.Collapsed;
                ElementNumber.FontSize = 10;
                ElementAmu.FontSize = 10;
                Symbol.FontSize = 13;
            }
            else if(ActualWidth <= 200)
            {
                ElementName.Visibility = Visibility.Visible;
                ElementNumber.FontSize = 15;
                ElementAmu.FontSize = 15;
                Symbol.FontSize = 30;
            }
            else
            {
                ElementName.Visibility = Visibility.Visible;
                ElementNumber.FontSize = 15;
                ElementAmu.FontSize = 15;
                Symbol.FontSize = 80;
            }
        }

        private void ElementPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ElementTapped?.Invoke(sender, e);
        }
    }
}
