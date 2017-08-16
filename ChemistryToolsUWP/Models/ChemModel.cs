using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ChemistryToolsUWP.Models
{
    public class ChemModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
        protected void Set<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            storage = value;
            RaisePropertyChanged(propertyName);
        }
    }
}
