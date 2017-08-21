using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ChemistryToolsUWP.Models
{
    public class PeriodicTable : INotifyPropertyChanged
    {
        private static PeriodicTable periodTableData = new PeriodicTable();
        private ObservableCollection<Element> elements;
        public ObservableCollection<Element> Elements
        {
            get
            {
                return elements;
            }
            set
            {
                if (value != elements)
                {
                    elements = value;
                    RaisePropertyChanged();
                }
            }
        }
        public static PeriodicTable PeriodTableData { get
            {
                return periodTableData;
            }
            set
            {
                if(value != periodTableData)
                {
                    periodTableData = value;
                }
            }
        }
        public PeriodicTable()
        {

        }
        public async void SetupDatabases()
        {

            Int32 count = await DatabaseModel.PeriodTableConnection.ExecuteScalarAsync<Int32>("select count(*) from sqlite_master where name = 'Elements'");
            try
            {
                if (count == 0 || true)
                {
                    FileInfo ElementFile = new FileInfo("Data/ChemistryTable.db.sql");
                    Debug.WriteLine(ElementFile.Exists);
                    using (StreamReader reader = new StreamReader(ElementFile.OpenRead()))
                    {
                        string[] commands = (await reader.ReadToEndAsync()).Split(new char[] { ';' });
                        foreach (string command in commands)
                        {
                            if (command.Length > 0)
                            {
                                await DatabaseModel.PeriodTableConnection.ExecuteAsync(command);
                            }
                        }
                    }
                }
                Elements = new ObservableCollection<Element>((await DatabaseModel.PeriodTableConnection.QueryAsync<Element>("select * from Elements")).ToList<Element>());
                RaisePropertyChanged("Elements");
            }
            catch(SQLiteException e)
            {
                Debug.WriteLine($"{e.Message}");
            }
        }
        public async Task<Element> GetElement(string search)
        {
            List<Element> searchResult = await DatabaseModel.PeriodTableConnection.QueryAsync<Element>($"select * from Elements where ChemicalSymbol = '{search}'");
            if (searchResult.Count > 0)
                return searchResult[0];
            else
                return null;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
