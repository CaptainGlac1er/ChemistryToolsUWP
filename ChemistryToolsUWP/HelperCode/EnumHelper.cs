using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChemistryToolsUWP.HelperCode
{
    public static class EnumHelper
    {
        public static TAttribute GetAttribute<TAttribute>(this Enum value)
            where TAttribute : Attribute
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            return value.GetType()
                .GetField(name)
                .GetCustomAttributes(false)
                .OfType<TAttribute>()
                .SingleOrDefault();
        }
    }
}
