using System.Linq;
using AppsettingsWpf.DAL.Context;
using AppsettingsWpf.DAL.Entityes;
using Microsoft.EntityFrameworkCore;

namespace AppsettingsWpf.DAL
{
    class DealsRepository : DbRepository<Deal>
    {
        public override IQueryable<Deal> Items => base.Items;

        public Deal GetById(int id)
        {
            return base.Get(id);
        }
        


        public DealsRepository(cntxDBAppsettingsWpf db) : base(db) { }
    }
}