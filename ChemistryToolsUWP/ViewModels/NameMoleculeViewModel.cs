using ChemistryToolsUWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;

namespace ChemistryToolsUWP.ViewModels
{
    class NameMoleculeViewModel : ViewModelBase
    {
        private string _Equation;
        private string _Output;

        public string Equation
        {
            get
            {
                return _Equation;
            }
            set
            {
                Set(ref _Equation, value);
            }
        }
        public string Output
        {
            get
            {
                return _Output;
            }
            set
            {
                Set(ref _Output, value);
            }
        }
        public async Task NameMolecule()
        {
            Output += $"searched for '{Equation}'\n";
            Molecule molecule = await MoleculesDB.MoleculeDB.GetMolecule(Equation) ?? await Molecule.GetMolecule(Equation);
            if(molecule != null)
            {
                Output += $"{molecule.GetFancyText()} is {molecule.Name}\n";
            }
            else
            {

                Output += $"{Equation} could not be found";
            }
        }
    }
}
