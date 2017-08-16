using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemistryToolsUWP.CustomAttribute
{
    class TagName : Attribute
    {
        private string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
        }
        public TagName(string name)
        {
            _Name = name;
        }
    }
}
