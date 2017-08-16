using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemistryToolsUWP.Models
{
    public class DatabaseModel
    {
        public static SQLiteAsyncConnection PeriodTableConnection = new SQLiteAsyncConnection("PeriodTable.db");
    }
}
