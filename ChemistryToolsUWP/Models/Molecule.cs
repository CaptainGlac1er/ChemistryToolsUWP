using ChemistryToolsUWP.CustomAttribute;
using ChemistryToolsUWP.HelperCode;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemistryToolsUWP.Models
{
    [Table("Molecules")]
    public class Molecule : ChemModel
    {
        private int _MoleculeID = 0;
        private string _Name = "";
        private string _Molecule = "";
        private int _Charge = 0;
        private string _Root = "";
        private string _Type = "";
        private int _Valence = 0;
        private ObservableCollection<Element> _Equation = new ObservableCollection<Element>();

        [PrimaryKey, Column("MolID")]
        public int MoleculeID
        {
            get { return _MoleculeID; }
            set { Set(ref _MoleculeID, value); }
        }
        [Column("Name")]
        public string Name
        {
            get { return _Name; }
            set
            {
                Set(ref _Name, value);
                RaisePropertyChanged("FancyFormula");
            }
        }
        [Column("Type")]
        public string Type
        {
            get { return _Type; }
            set { Set(ref _Type, value); }
        }
        [Column("Molecule")]
        public string ChemicalFormula
        {
            get { return _Molecule; }
            set { Set(ref _Molecule, value); }
        }
        [Column("Root")]
        public string Root
        {
            get { return _Root; }
            set { Set(ref _Root, value); }
        }
        [Column("Charge")]
        public int Charge
        {
            get { return _Charge; }
            set { Set(ref _Charge, value); }
        }
        [Ignore]
        public int Valence
        {
            get { return _Valence; }
            set { Set(ref _Valence, value); }
        }
        [Ignore]
        public ObservableCollection<Element> Equation
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
        [Ignore]
        public string FancyFormula
        {
            get { return GetFancyText(); }
        }

        private string GetPrefix(int num)
        {
            switch (num)
            {
                case 1:
                    return "mono";
                case 2:
                    return "di";
                case 3:
                    return "tri";
                case 4:
                    return "tetra";
                case 5:
                    return "penta";
                case 6:
                    return "hexa";
                case 7:
                    return "hepta";
                case 8:
                    return "octa";


            }
            return "error";
        }
        private string ConvertToRoman(int input)
        {
            switch (input)
            {
                case 1:
                    return "I";
                case 2:
                    return "II";
                case 3:
                    return "III";
                case 4:
                    return "IV";
                case 5:
                    return "V";
            }
            return "error";
        }

        private bool HasPoly(string aEquation, List<Molecule> polyAtomic)
        {
            foreach (Molecule poly in polyAtomic)
            {
                Debug.WriteLine(aEquation + " " + poly.ChemicalFormula);
                if (aEquation.Contains(poly.ChemicalFormula))
                {
                    return true;
                }
            }
            return false;
        }

        public static async Task<Molecule> GetMolecule(string text)
        {
            Molecule molecule = new Molecule();
            Molecule checkDB = await MoleculesDB.MoleculeDB.GetMolecule(text);
            if (checkDB != null)
            {
                molecule = checkDB;
            }
            else
            {
                StringBuilder formula = new StringBuilder();
                bool parIn = false;
                List<Element> inParElements = new List<Element>();
                for (int i = 0; i < text.Length; i++)
                {
                    bool boolbreak = false;
                    if (text.ToCharArray()[i] == '(')
                    {
                        parIn = true;
                        formula.Append('(');
                    }
                    else if (text.ToCharArray()[i] == ')')
                    {
                        parIn = false;
                        formula.Append(')');
                        int t = 1;
                        bool chance = true;
                        string number = "";
                        do
                        {
                            if (i + t < text.Length && Char.IsDigit(text, i + t))
                            {

                                number += text.Substring(i + t, 1);
                                t++;
                                chance = true;
                            }
                            else
                            {
                                chance = false;
                            }
                        } while (chance);
                        if (number != "")
                        {
                            int times = Int32.Parse(number);
                            for (int q = 0; q < inParElements.Count; q++)
                            {
                                inParElements[q].Count = inParElements[q].Count * times;
                            }
                            formula.Append(number.ToString());
                        }
                        foreach (Element elem in inParElements)
                            molecule.Equation.Add(elem);
                        inParElements = new List<Element>();

                    }

                    else if (Char.IsUpper(text, i))
                    {
                        if (i + 1 < text.Length)
                        {
                            if (Char.IsLower(text, i + 1))
                            {
                                string letter = text.Substring(i, 2);
                                Element currentElement = await PeriodicTable.PeriodTableData.GetElement(letter);
                                int t = 2;
                                bool chance = true;
                                string number = "";
                                formula.Append(letter);

                                do
                                {
                                    if (i + t < text.Length && Char.IsDigit(text, i + t))
                                    {

                                        number += text.Substring(i + t, 1);
                                        t++;
                                        chance = true;
                                    }
                                    else
                                    {
                                        chance = false;
                                    }
                                } while (chance);
                                if (number != "")
                                {
                                    currentElement.Count = Int32.Parse(number);
                                    formula.Append(number.ToString());
                                }
                                if (parIn)
                                    inParElements.Add(currentElement);
                                else
                                    molecule.Equation.Add(currentElement);
                            }
                            else
                            {
                                boolbreak = true;
                            }
                        }
                        else
                        {
                            boolbreak = true;
                        }
                        if (Char.IsUpper(text, i) && boolbreak)
                        {
                            string letter = text.Substring(i, 1);
                            Element currentElement = await PeriodicTable.PeriodTableData.GetElement(letter);
                            if (currentElement != null)
                            {
                                int t = 1;
                                bool chance = true;
                                string number = "";
                                formula.Append(letter);
                                //OutputMoles.Text = text.Length + " " + i + t;
                                do
                                {
                                    if (i + t < text.Length && Char.IsDigit(text, i + t))
                                    {

                                        number += text.Substring(i + t, 1);
                                        t++;
                                        chance = true;
                                    }
                                    else
                                    {
                                        chance = false;
                                    }
                                } while (chance);
                                if (number != "")
                                {
                                    currentElement.Count = Int32.Parse(number);
                                    formula.Append(number.ToString());
                                }
                                if (parIn)
                                    inParElements.Add(currentElement);
                                else
                                    molecule.Equation.Add(currentElement);
                            }
                        }
                    }
                }
                molecule.ChemicalFormula = formula.ToString();
                molecule.Valence = await molecule.GetValence();
                await molecule.GenerateName();
            }
            return molecule;
        }
        public async Task GenerateName()
        {
            bool found = false;
            if (this.Equation.Count > 0 && !found)
            {
                if (this.Equation.Count == 2)
                {
                    if ((Equation[0].Category == EnumHelper.GetAttribute<TagName>(Element.CategoryTypes.Alkali).Name || Equation[0].Category == EnumHelper.GetAttribute<TagName>(Element.CategoryTypes.Alkaline).Name) && (Equation[1].Category == EnumHelper.GetAttribute<TagName>(Element.CategoryTypes.Non_Metal).Name || Equation[1].Category == EnumHelper.GetAttribute<TagName>(Element.CategoryTypes.Halogen).Name))
                    {
                        Name = Equation[0].Name + " " + Equation[1].Root + "ide";
                    }
                    else if ((Equation[0].Category == EnumHelper.GetAttribute<TagName>(Element.CategoryTypes.Transition_Metal).Name || Equation[0].Category == EnumHelper.GetAttribute<TagName>(Element.CategoryTypes.Poor_Metal).Name && Equation[1].Category == EnumHelper.GetAttribute<TagName>(Element.CategoryTypes.Non_Metal).Name || Equation[1].Category == EnumHelper.GetAttribute<TagName>(Element.CategoryTypes.Halogen).Name))
                    {
                        Name = Equation[0].Name + " (" + ConvertToRoman((8 - ((Equation[1].Valence * Equation[1].Count) % 8))) + ") " + Equation[1].Root + "ide";
                    }
                    else if (Equation[0].Category == EnumHelper.GetAttribute<TagName>(Element.CategoryTypes.Non_Metal).Name && Equation[1].Category == EnumHelper.GetAttribute<TagName>(Element.CategoryTypes.Non_Metal).Name)
                    {
                        if (Equation[0].Count > 1)
                            Name = GetPrefix(Equation[0].Count);
                        Name += Equation[0].Name + " " + GetPrefix(Equation[1].Count) + Equation[1].Root + "ide";
                        Name = Name.ToLower().Replace("oo", "o");
                    }
                    else if (Equation[0].ChemicalSymbol == "H" && !ChemicalFormula.Contains("O"))
                    {
                        Name = "hydro" + Equation[1].Root + "ic acid";
                    }

                }
                else
                {
                    List<Molecule> polyAtomic = await MoleculesDB.MoleculeDB.GetPolyatomicMolecules();
                    if (Equation[0].ChemicalSymbol == "H")
                    {
                        foreach (Molecule poly in polyAtomic)
                        {
                            if (ChemicalFormula.Contains(poly.ChemicalFormula) && !ChemicalFormula.Contains("O"))
                            {
                                Name = "hydro" + poly.Root + "ic acid";
                            }
                            else if (ChemicalFormula.Contains(poly.ChemicalFormula) && ChemicalFormula.Contains("O"))
                            {
                                if (poly.Name.Contains("ite"))
                                {
                                    Name = poly.Root + "ous acid";
                                }
                                else if (poly.Name.Contains("ate"))
                                {
                                    Name = poly.Root + "ic acid";
                                }
                            }
                        }
                    }
                    else if (HasPoly(ChemicalFormula, polyAtomic))
                    {
                        foreach (Molecule poly in polyAtomic)
                        {
                            if (ChemicalFormula.Contains(poly.ChemicalFormula))
                            {
                                Name = Equation[0].Name + " " + poly.Name;
                                if (await GetValence() > 0)
                                {
                                    Name += "\nProbably incorrect would be unstable" + "\nValence electrons: " + await GetValence();
                                }
                            }
                        }
                    }
                    else if (!found)
                    {

                        Name = "error";

                    }
                }
            }
            else if (Equation.Count == 1)
            {
                Name = Equation[0].Name;
            }

            else if (!found)
            {
                Name = "error";
            }
            Debug.WriteLine(Equation + " " + Equation.Count);
        }

        public async Task<int> GetValence()
        {
            List<Molecule> polyAtomic = await MoleculesDB.MoleculeDB.GetPolyatomicMolecules();
            int valence = 0;
            string edittedFormula = ChemicalFormula;
            if (HasPoly(edittedFormula, polyAtomic))
            {
                foreach (Molecule poly in polyAtomic)
                {
                    if (edittedFormula.Contains(poly.ChemicalFormula))
                    {
                        valence += poly.Charge;
                        Debug.WriteLine(edittedFormula + " " + poly.ChemicalFormula);
                        edittedFormula = edittedFormula.Replace(poly.ChemicalFormula, "");
                        Debug.WriteLine(edittedFormula);
                    }
                }
            }
            foreach (Element elem in Equation)
                valence += elem.Valence * elem.Count;
            return valence;
        }
        public string GetFancyText()
        {
            return Element.ConvertSubscript(ChemicalFormula);
        }
    }
}
