using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using ProjectCMC_Web.Models;

namespace ProjectCMC_Web.DAL
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(): base("ProjectContext")
        {
            Database.SetInitializer<ProjectContext>(null);
            Database.SetInitializer<ProjectContext>(new DropCreateDatabaseIfModelChanges<ProjectContext>());
            Database.SetInitializer<ProjectContext>(new CreateDatabaseIfNotExists<ProjectContext>()); 
        }
        public DbSet<Connection> Connection { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Node> Node { get; set; }
        public DbSet<Trend> Trend { get; set; }
        public DbSet<WindMill> WindMill { get; set; }
        public DbSet<WindPark> WindPark { get; set; }
       
    }
}