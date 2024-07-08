using AppsettingsWpf.DAL.Entityes;
using Microsoft.EntityFrameworkCore;

namespace AppsettingsWpf.DAL.Context
{
    public class cntxDBAppsettingsWpf : DbContext
    {
        public DbSet<Deal> Deals { get; set; }        
        
        public DbSet<Picture> Pictures { get; set; }        

        public cntxDBAppsettingsWpf(DbContextOptions<cntxDBAppsettingsWpf> options) : base(options)
        {
            
        }
    }
}
