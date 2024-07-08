using System.Linq;
using AppsettingsWpf.DAL.Context;
using AppsettingsWpf.DAL.Entityes;
using Microsoft.EntityFrameworkCore;

namespace AppsettingsWpf.DAL
{
    class PicturesRepository : DbRepository<Picture>
    {
        public override IQueryable<Picture> Items => base.Items;

        public PicturesRepository(cntxDBAppsettingsWpf db) : base(db) { }
    }
}