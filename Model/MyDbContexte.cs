using Model.Entities;
using Model.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MyDbContexte : DbContext
    {
        public MyDbContexte() : base("connectionString")
        {
            Database.SetInitializer<MyDbContexte>(new DropCreateDatabaseIfModelChanges<MyDbContexte>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
     


            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Configurations.Add(new EmployeMapping());
            modelBuilder.Configurations.Add(new OffreMapping());
            modelBuilder.Configurations.Add(new StatutMapping());
            modelBuilder.Configurations.Add(new ExperienceMapping());
            modelBuilder.Configurations.Add(new PostulationMapping());
            modelBuilder.Configurations.Add(new FormationMapping());

        }

        public IDbSet<Employe> Employes { get; set; }
        public IDbSet<Offre> Offres { get; set; }
        public IDbSet<Statut> Statuts { get; set; }
        public IDbSet<Experience> Experiences { get; set; }
        public IDbSet<Postulation> Postulations { get; set; }
        public IDbSet<Formation> Formations { get; set; }

    }
}
