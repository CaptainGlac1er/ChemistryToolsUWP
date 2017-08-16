using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemistryToolsUWP.Models
{
    public class MoleculesDB
    {
        public static MoleculesDB MoleculeDB = new MoleculesDB();
        public MoleculesDB()
        {
            
        }
        public async Task<Molecule> GetMolecule(string chemicalFormula)
        {
            List<Molecule> query = await DatabaseModel.PeriodTableConnection.QueryAsync<Molecule>($"select m.Name as Name, m.Molecule as Molecule, m.MolID as MolID, a.Type as Type, m.Root as Root, m.Charge as Charge from Molecules m left join AtomicTypes a on m.Type = a.ATID where Molecule='{chemicalFormula}'");
            if (query.Count > 1)
                throw new NotImplementedException();
            else if (query.Count == 0)
                return null;
            return query[0];
        }
        public async Task<List<Molecule>> GetPolyatomicMolecules()
        {
            List<Molecule> query =  await DatabaseModel.PeriodTableConnection.QueryAsync<Molecule>($"select m.Name as Name, m.Molecule as Molecule, m.MolID as MolID, a.Type as Type, m.Root as Root, m.Charge as Charge from Molecules m join Polyatomic p on m.MolID = p.MolID left join AtomicTypes a on m.Type = a.ATID");
            Debug.WriteLine(query.Count);
            return query;
        }
    }
}
