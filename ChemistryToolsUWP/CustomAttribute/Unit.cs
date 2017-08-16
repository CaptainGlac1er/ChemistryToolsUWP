using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemistryToolsUWP.CustomAttribute
{
    class Unit : Attribute
    {
        private string _Name, _Shortname;
        public string Name
        {
            get
            {
                return _Name;
            }
        }
        public string Shortname
        {
            get
            {
                return _Shortname;
            }
        }
        public Unit(string name, string shortname)
        {
            _Name = name;
            _Shortname = shortname;
        }

    }
}
