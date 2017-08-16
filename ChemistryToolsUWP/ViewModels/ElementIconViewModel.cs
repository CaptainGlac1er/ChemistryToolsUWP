using ChemistryToolsUWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;

namespace ChemistryToolsUWP.ViewModels
{
    class ElementIconViewModel : ViewModelBase
    {
        private Element element;
        public Element ElementToShow
        {
            get
            {
                return element;
            }
            set
            {
                Set(ref element, value);
            }
        }
        public ElementIconViewModel()
        {
            if(Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                ElementToShow = new Element()
                {
                    Name="Test",
                    ChemicalSymbol="T",
                    AtomicNumber=0
                    
                };
            }
        }
    }
}
