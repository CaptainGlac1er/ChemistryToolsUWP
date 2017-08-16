using ChemistryToolsUWP.Models;
using System.ComponentModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ChemistryToolsUWP.ViewsElements
{
    public delegate void ElementSelected(Element element);
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ElementViewList : UserControl, INotifyPropertyChanged
    {
        public event ElementSelected SelectedElement;
        public string SearchFilter
        {
            get
            {
                return ViewModel.SearchTerm;
            }
            set
            {
                ViewModel.SearchTerm = value;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public ElementViewList()
        {
            this.InitializeComponent();
        }
        public void GotoElementPage(object sender, ItemClickEventArgs e)
        {
            SelectedElement?.Invoke((Element) e.ClickedItem);
        }

    }
}
