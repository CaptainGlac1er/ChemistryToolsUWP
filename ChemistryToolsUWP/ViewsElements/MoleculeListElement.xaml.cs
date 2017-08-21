using ChemistryToolsUWP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public delegate void MoleculeTapped(Molecule sender);
    public sealed partial class MoleculeListElement : UserControl, INotifyPropertyChanged
    {
        Molecule elementToShow;

        public event MoleculeTapped MoleculeTapped;
        public event PropertyChangedEventHandler PropertyChanged;

        public Molecule MoleculeToShow
        {
            get { return elementToShow; }
            set {
                elementToShow = value;
                RaisePropertyChanged();
            }
        }
        public MoleculeListElement()
        {
            this.InitializeComponent();
        }
        private void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        private void MoleculePanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Molecule molecule = (Molecule)(((RelativePanel)sender).Tag);
            Debug.WriteLine($"{molecule.Name} tapped {(((RelativePanel)sender).Tag).GetType()}");
            MoleculeTapped?.Invoke(molecule);
        }

        public static readonly DependencyProperty MoleculeToShowProperty =
   DependencyProperty.Register("MoleculeToShow", typeof(Molecule), typeof(MoleculeListElement), null);
    }
}
