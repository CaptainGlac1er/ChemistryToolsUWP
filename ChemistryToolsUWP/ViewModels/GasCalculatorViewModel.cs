using ChemistryToolsUWP.CustomAttribute;
using ChemistryToolsUWP.HelperCode;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml;
using static ChemistryToolsUWP.ViewModels.BasicGasCalculatorClass;

namespace ChemistryToolsUWP.ViewModels
{
    public abstract class BasicGasCalculatorClass : ViewModelBase
    {

        public enum TemperatureUnit
        {
            [Unit("Fahrenheit", "F")]
            F,
            [Unit("Celsius", "C")]
            C,
            [Unit("Kelvin", "K")]
            K
        }
        private string pi = "", vi = "", ti = "", pf = "", vf = "", tf = "", output = "", n = "", t = "";
        private TemperatureUnit unitTi = TemperatureUnit.C, unitTf = TemperatureUnit.C, unitN = TemperatureUnit.C;
        public TemperatureUnit UnitTi
        {
            get
            {
                return unitTi;
            }
            set
            {
                Calculate();
                Set(ref unitTi, value);
            }
        }
        public TemperatureUnit UnitTf
        {
            get
            {
                return unitTf;
            }
            set
            {
                Set(ref unitTf, value);
            }
        }
        public TemperatureUnit UnitT
        {
            get
            {
                return unitN;
            }
            set
            {
                Set(ref unitN, value);
            }
        }
        public string Output
        {
            get
            {
                return output;
            }
            set
            {
                Set(ref output, value);
            }
        }

        public string Pi
        {
            get
            {
                return pi;
            }
            set
            {
                Set(ref pi, value.Trim());
                //Calculate();
            }
        }
        public string Vi
        {
            get
            {
                return vi;
            }
            set
            {
                Set(ref vi, value.Trim());
                //Calculate();
            }
        }
        public string Ti
        {
            get
            {
                return ti;
            }
            set
            {
                Set(ref ti, value.Trim());
                //Calculate();
            }
        }
        public bool TryParseTemp(TemperatureUnit type, string number, out double value)
        {
            double ti;
            switch (type)
            {
                case TemperatureUnit.C:
                    if (double.TryParse(number, out ti))
                    {
                        value = ti + 273.15;
                        return true;
                    }
                    else
                    {
                        value = 0;
                        return false;
                    }
                case TemperatureUnit.K:
                    if (double.TryParse(number, out ti))
                    {
                        value = ti;
                        return true;
                    }
                    else
                    {
                        value = 0;
                        return false;
                    }
                case TemperatureUnit.F:
                    if (double.TryParse(number, out ti))
                    {
                        value = (ti + 459.67) * 5.0 / 9;
                        return true;
                    }
                    else
                    {
                        value = 0;
                        return false;
                    }
                default:
                    value = 0;
                    return false;
            }
        }
        public void SetNumber(ref string numberOut, double newNumber, TemperatureUnit type)
        {
            double number = 0;
            switch (type)
            {
                case TemperatureUnit.C:
                    number = newNumber - 273.15;
                    break;
                case TemperatureUnit.K:
                    number = newNumber;
                    break;
                case TemperatureUnit.F:
                    number = newNumber * 9 / 5.0 - 459.67;
                    break;
                default:
                    break;
            }
            numberOut = number.ToString();
        }
        public string Pf
        {
            get
            {
                return pf;
            }
            set
            {
                Set(ref pf, value.Trim());
                //Calculate();
            }
        }
        public string Vf
        {
            get
            {
                return vf;
            }
            set
            {
                Set(ref vf, value.Trim());
                //Calculate();
            }
        }
        public string Tf
        {
            get
            {
                return tf;
            }
            set
            {
                Set(ref tf, value.Trim());
                //Calculate();
            }
        }


        public string T
        {
            get
            {
                return t;
            }
            set
            {
                Set(ref t, value.Trim());
                //Calculate();
            }
        }
        public string N
        {
            get
            {
                return n;
            }
            set
            {
                Set(ref n, value.Trim());
            }
        }

        public abstract void Calculate();
        public void ClearNumbers()
        {
            Pi = "";
            Vi = "";
            Ti = "";
            Pf = "";
            Vf = "";
            Tf = "";
            Output = "";
        }

        public static IEnumerable<UnitName> AllTempUnits()
        {
            Array test = Enum.GetValues(typeof(TemperatureUnit));
            IEnumerable<TemperatureUnit> test2 = test.Cast<TemperatureUnit>();
            IEnumerable<UnitName> test3 = test2.Select((e) => new UnitName() { Unit = e });
            return test3;
        }

    }
    public class UnitName : ViewModelBase
    {
        private TemperatureUnit _Unit;
        public TemperatureUnit Unit
        {
            get
            {
                return _Unit;
            }
            set
            {
                Set(ref _Unit, value);
            }
        }
        public string Name
        {
            get
            {
                return _Unit.GetAttribute<Unit>().Name;
            }
        }
        public string ShortName
        {
            get
            {
                return _Unit.GetAttribute<Unit>().Shortname;
            }
        }
    }
    public class GasCalculatorViewModel : ViewModelBase
    {
        public string PageTitle = "Gas Calculators";
        public ObservableCollection<UnitName> TempUnits = new ObservableCollection<UnitName>(BasicGasCalculatorClass.AllTempUnits());
    }
    public class CombinedCalulatorViewModel : BasicGasCalculatorClass
    {
        public override void Calculate()
        {
            Debug.WriteLine($"`{Pi}` {Pi == ""} `{Vi}` {Vi == ""} `{Ti}` {Ti == ""} `{Pf}` {Pf == ""} `{Vf}` {Vf == ""} `{Tf}` {Tf == ""}");
            int empty = 0;
            double pi = 0, vi = 0, ti = 0, pf = 0, vf = 0, tf = 0;
            if (Pi == "")
            {
                empty++;
            }
            else if (!double.TryParse(Pi, out pi))
            {
                return;
            }
            if (Vi == "")
            {
                empty++;
                if (empty > 1)
                    return;
            }
            else if (!double.TryParse(Vi, out vi))
            {
                return;
            }
            if (Ti == "")
            {
                empty++;
                if (empty > 1)
                    return;
            }
            else if (!TryParseTemp(UnitTi, Ti, out ti))
            {
                return;
            }
            if (Pf == "")
            {
                empty++;
                if (empty > 1)
                    return;
            }
            else if (!double.TryParse(Pf, out pf))
            {
                return;
            }
            if (Vf == "")
            {
                empty++;
                if (empty > 1)
                    return;
            }
            else if (!double.TryParse(Vf, out vf))
            {
                return;
            }
            if (Tf == "")
            {
                empty++;
                if (empty > 1)
                    return;
            }
            else if (!TryParseTemp(UnitTf, Tf, out tf))
            {
                return;
            }
            Debug.WriteLine($"{empty}");
            if (empty == 1)
            {
                string output = "";
                if (Pi == "")
                {
                    output = String.Format($"Pi is {((pf * vf * ti) / (tf * vi))}");
                }
                else if (Vi == "")
                {
                    output = String.Format($"Vi is {((pf * vf * ti) / (tf * pi))}");
                }
                else if (Ti == "")
                {
                    SetNumber(ref output, (pi * vi * tf) / (vf * pf), UnitTi);
                    output = String.Format($"Ti is {output}");
                }
                else if (Pf == "")
                {
                    output = ((pi * vi * tf) / (vf * ti)).ToString();
                    output = String.Format($"Pf is {output}");
                }
                else if (Vf == "")
                {
                    output = ((pi * vi * tf) / (pf * ti)).ToString();
                    output = String.Format($"Vf is {output}");
                }
                else if (Tf == "")
                {
                    double calc = ((pf * vf * ti) / (pi * vi));
                    SetNumber(ref output, calc, UnitTf);
                    output = String.Format($"Tf is {output} {EnumHelper.GetAttribute<Unit>(UnitTf).Name}");
                }
                Output = output;
            }
            else
            {
                return;
            }
        }
    }
    public class CharlesCalulatorViewModel : BasicGasCalculatorClass
    {
        public override void Calculate()
        {
            Debug.WriteLine($"`{Pi}` {Pi == ""} `{Vi}` {Vi == ""} `{Ti}` {Ti == ""} `{Pf}` {Pf == ""} `{Vf}` {Vf == ""} `{Tf}` {Tf == ""}");
            int empty = 0;
            double vi = 0, ti = 0, vf = 0, tf = 0;
            if (Vi == "")
            {
                empty++;
                if (empty > 1)
                    return;
            }
            else if (!double.TryParse(Vi, out vi))
            {
                return;
            }
            if (Ti == "")
            {
                empty++;
                if (empty > 1)
                    return;
            }
            else if (!TryParseTemp(UnitTi, Ti, out ti))
            {
                return;
            }
            if (Vf == "")
            {
                empty++;
                if (empty > 1)
                    return;
            }
            else if (!double.TryParse(Vf, out vf))
            {
                return;
            }
            if (Tf == "")
            {
                empty++;
                if (empty > 1)
                    return;
            }
            else if (!TryParseTemp(UnitTi, Tf, out tf))
            {
                return;
            }
            if (empty == 1)
            {
                string output = "";
                if (Vi == "")
                {
                    output = String.Format($"Vi is {((ti * vf) / tf)}");
                }
                else if (Ti == "")
                {
                    SetNumber(ref output, (tf * vi) / vf, UnitTi);
                    output = String.Format($"Ti is {output}");
                }
                else if (Vf == "")
                {
                    output = String.Format($"Vf is {((tf * vi) / ti)}");
                }
                else if (Tf == "")
                {
                    SetNumber(ref output, (ti * vf) / vi, UnitTf);
                    output = String.Format($"Tf is {output}");
                }
                Output = output;
            }
            else
            {
                return;
            }
        }
    }
    public class BoyleCalulatorViewModel : BasicGasCalculatorClass
    {
        public override void Calculate()
        {
            int empty = 0;
            double pi = 0, vi = 0, pf = 0, vf = 0;
            if (Pi == "")
            {
                empty++;
            }
            else if (!double.TryParse(Pi, out pi))
            {
                return;
            }
            if (Vi == "")
            {
                empty++;
                if (empty > 1)
                    return;
            }
            else if (!double.TryParse(Vi, out vi))
            {
                return;
            }
            if (Pf == "")
            {
                empty++;
                if (empty > 1)
                    return;
            }
            else if (!double.TryParse(Pf, out pf))
            {
                return;
            }
            if (Vf == "")
            {
                empty++;
                if (empty > 1)
                    return;
            }
            else if (!double.TryParse(Vf, out vf))
            {
                return;
            }
            if (empty == 1)
            {
                string output = "";
                if (Pi == "")
                {
                    output = String.Format($"Pi is {((pf * vf) / vi)}");
                }
                else if (Vi == "")
                {
                    output = String.Format($"Vi is {((pf * vf) / pi)}");
                }
                else if (Pf == "")
                {
                    output = ((pi * vi) / vf).ToString();
                    output = String.Format($"Pf is {output}");
                }
                else if (Vf == "")
                {
                    output = ((pi * vi) / pf).ToString();
                    output = String.Format($"Vf is {output}");
                }
                Output = output;
            }
            else
            {
                return;
            }
        }
    }
    public class IdealCalulatorViewModel : BasicGasCalculatorClass
    {
        public override void Calculate()
        {
            int empty = 0;
            double p = 0, v = 0, n = 0, t = 0, r = 0.0821;
            if (Pi == "")
            {
                empty++;
                if (empty > 1)
                    return;
            }
            else if (!double.TryParse(Pi, out p))
            {
                return;
            }
            if (Vi == "")
            {
                empty++;
                if (empty > 1)
                    return;
            }
            else if (!double.TryParse(Vi, out v))
            {
                return;
            }
            if (N == "")
            {
                empty++;
                if (empty > 1)
                    return;
            }
            else if (!double.TryParse(N, out n))
            {
                return;
            }
            if (T == "")
            {
                empty++;
                if (empty > 1)
                    return;
            }
            else if (!TryParseTemp(UnitT, T, out t))
            {
                return;
            }
            if (empty == 1)
            {
                string output = "";
                if (Pi == "")
                {
                    output = String.Format($"V is {((n*r*t)/v)}");
                }
                else if (Vi == "")
                {
                    output = String.Format($"Ti is {((n * r * t) / p)}");
                }
                else if (N == "")
                {
                    output = String.Format($"Vf is {((p*v) / (r*t))}");
                }
                else if (T == "")
                {
                    SetNumber(ref output, ((p * v) / (r * n)), UnitT);
                    output = String.Format($"Tf is {output} {EnumHelper.GetAttribute<Unit>(UnitT).Name}");
                }
                Output = output;
            }
            else
            {
                return;
            }
        }
    }
}
