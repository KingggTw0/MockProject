using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTRequest.Core.Models
{
    public class OTRequestDbContext : DbContext
    {
        public OTRequestDbContext() : base("OTRequestContext")
        {
            Database.SetInitializer<OTRequestDbContext>(new CreateDatabaseIfNotExists<OTRequestDbContext>());
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<DetailRequest> DetailRequests { get; set; }
    }
    
}
