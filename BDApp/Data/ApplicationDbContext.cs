using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BDApp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<ConstructionProject> Projects { get; set; }
        public DbSet<ConstructionWorker> Workers { get; set; }
        public DbSet<Material> Materials { get; set; }
    }

    public class ConstructionProject
    {
        //public DbSet<BDApp.Models.ConstructionProject> Projects { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public DateTime StartDate { get; set; }
        public string Status { get; set; }
    }

    public class ConstructionWorker
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public int ProjectID { get; set; }
        public ConstructionProject Project { get; set; }
    }

    public class Material
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int ProjectID { get; set; }
        public ConstructionProject Project { get; set; }
    }
}
