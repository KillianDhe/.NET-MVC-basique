using Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Mapping
{
    public class EmployeMapping : EntityTypeConfiguration<Employe>
    {
        public EmployeMapping()
        {
            ToTable("APP_EMPLOYE");
            HasKey(e => e.Id);

            Property(e => e.Id).HasColumnName("EMP_ID").IsRequired();
            Property(e => e.Nom).HasColumnName("EMP_NOM").IsRequired();
            Property(e => e.Prenom).HasColumnName("EMP_PRENOM");
            Property(e => e.DateDeNaissance).HasColumnName("EMP_DATENAISSANCE");
            Property(e => e.Anciennete).HasColumnName("EMP_ANCIENNETE");
            Property(e => e.Biographie).HasColumnName("EMP_BIOGRAPHIE");
            HasMany(e => e.Postulations).WithRequired(p => p.Employe).HasForeignKey(p => p.EmployeId);
            HasMany(e => e.Formations).WithRequired(p => p.Employe).HasForeignKey(p => p.EmployeId);
            HasMany(e => e.Experience).WithRequired(p => p.employe).HasForeignKey(p => p.EmployeId);

        }


    }
}
