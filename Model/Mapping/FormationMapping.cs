using Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Mapping
{
    public class FormationMapping : EntityTypeConfiguration<Formation>
    {
        public FormationMapping()
        {
            ToTable("APP_FORMATION");
            HasKey(f =>  new { f.EmployeId, f.FormationId });
            Property(e => e.EmployeId).HasColumnName("EMP_ID").IsRequired();
            Property(e => e.FormationId).HasColumnName("FOR_ID").IsRequired();

            Property(e => e.Date).HasColumnName("FOR_DATE");
            Property(e => e.Intitule).HasColumnName("FOR_INTITULE");
        }
    }
}
