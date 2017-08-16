using ChemistryToolsUWP.CustomAttribute;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ChemistryToolsUWP.Models
{
    [Table("Element")]
    public class Element : ChemModel
    {
        public enum CategoryTypes
        {
            [TagName("Non Metal")]
            Non_Metal,
            [TagName("Actinoids")]
            Actinoids,
            [TagName("Alkaline")]
            Alkaline,
            [TagName("Halogen")]
            Halogen,
            [TagName("Lanthancid")]
            Lanthancid,
            [TagName("Metalloid")]
            Metalloid,
            [TagName("Noble Gas")]
            Noble_Gas,
            [TagName("Poor Metal")]
            Poor_Metal,
            [TagName("Transition Metal")]
            Transition_Metal,
            [TagName("Alkali")]
            Alkali
        }
        private int atomicNumber;
        private string name;
        private string chemicalSymbol;
        private double amu;
        private int period;
        private int valence;
        private string root;
        private string category;
        private string _Color = "FFFFFF";
        private int _Count = 1;
        [PrimaryKey, Column("AtomicNumber")]
        public int AtomicNumber {
            get
            {
                return atomicNumber;
            }
            set
            {
                if(value != atomicNumber)
                {
                    Set(ref atomicNumber, value);
                }
            }
        }
        [Column("Name")]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != name)
                {
                    name = value;
                    RaisePropertyChanged();
                }
            }
        }
        [Column("ChemicalSymbol")]
        public string ChemicalSymbol
        {
            get
            {
                return chemicalSymbol;
            }
            set
            {
                if (value != chemicalSymbol)
                {
                    chemicalSymbol = value;
                    RaisePropertyChanged();
                }
            }
        }
        [Column("Amu")]
        public double Amu
        {
            get
            {
                return amu;
            }
            set
            {
                if (value != amu)
                {
                    amu = value;
                    RaisePropertyChanged();
                }
            }
        }
        [Column("Period")]
        public int Period
        {
            get
            {
                return period;
            }
            set
            {
                if (value != period)
                {
                    period = value;
                    RaisePropertyChanged();
                }
            }
        }
        [Column("Valence")]
        public int Valence
        {
            get
            {
                return valence;
            }
            set
            {
                if (value != valence)
                {
                    valence = value;
                    RaisePropertyChanged();
                }
            }
        }
        [Column("Root")]
        public string Root
        {
            get
            {
                return root;
            }
            set
            {
                if (value != root)
                {
                    root = value;
                    RaisePropertyChanged();
                }
            }
        }
        [Column("Category")]
        public string Category
        {
            get
            {
                return category;
            }
            set
            {
                if (value != category)
                {
                    category = value;
                    RaisePropertyChanged();
                }
            }
        }
        [Column("Color")]
        public string Color
        {
            get
            {
                return _Color;
            }
            set
            {
                if (_Color != value)
                {
                    _Color = value;
                    RaisePropertyChanged();
                }
            }
        }
        [Ignore]
        public int Count
        {
            get
            {
                return _Count;
            }
            set
            {
                Set(ref _Count, value);
            }
        }




        public static string ConvertSubscript(string input)
        {
            string output = "";
            foreach (char digit in input.ToCharArray())
            {
                switch (digit)
                {
                    case '0':
                        output += "\x2080";
                        break;
                    case '1':
                        output += "\x2081";
                        break;
                    case '2':
                        output += "\x2082";
                        break;
                    case '3':
                        output += "\x2083";
                        break;
                    case '4':
                        output += "\x2084";
                        break;
                    case '5':
                        output += "\x2085";
                        break;
                    case '6':
                        output += "\x2086";
                        break;
                    case '7':
                        output += "\x2087";
                        break;
                    case '8':
                        output += "\x2088";
                        break;
                    case '9':
                        output += "\x2089";
                        break;
                    default:
                        output += digit;
                        break;
                }
            }

            return output;
        }
        public static string ConvertRegscript(string input)
        {
            string output = "";
            foreach (char digit in input.ToCharArray())
            {
                switch (digit)
                {
                    case '\x2080':
                        output += "0";
                        break;
                    case '\x2081':
                        output += "1";
                        break;
                    case '\x2082':
                        output += "2";
                        break;
                    case '\x2083':
                        output += "3";
                        break;
                    case '\x2084':
                        output += "4";
                        break;
                    case '\x2085':
                        output += "5";
                        break;
                    case '\x2086':
                        output += "6";
                        break;
                    case '\x2087':
                        output += "7";
                        break;
                    case '\x2088':
                        output += "8";
                        break;
                    case '\x2089':
                        output += "9";
                        break;
                    default:
                        output += digit;
                        break;
                }
            }

            return output;
        }

    }
}
