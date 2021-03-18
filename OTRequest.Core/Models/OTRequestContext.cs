using System;
using System.Data.Entity;
using System.Linq;

namespace OTRequest.Core.Models
{
    public class OTRequestContext : DbContext
    {
        // Your context has been configured to use a 'OTRequestContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'OTRequest.Core.Models.OTRequestContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'OTRequestContext' 
        // connection string in the application configuration file.
        public OTRequestContext()
            : base("name=OTRequestContext")
        {
            Database.SetInitializer<OTRequestContext>(new CreateDatabaseIfNotExists<OTRequestContext>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<UserProjectMap> UserProjectMaps { get; set; }
        public virtual DbSet<DetailRequest> DetailRequests { get; set; }
    }
}