using Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Mapping
{
    public class ExperienceMapping : EntityTypeConfiguration<Experience>
    {
        public ExperienceMapping()
        {
            ToTable("APP_EXPERIENCE");
            HasKey(e => e.Id);
            Property(e => e.Id).HasColumnName("EXP_ID").IsRequired();
            Property(e => e.EmployeId).HasColumnName("EMP_ID").IsRequired();
            Property(e => e.Intitule).HasColumnName("EXP_INTITULE").IsRequired();
            Property(e => e.Date).HasColumnName("EXP_DATE");
        }
    }
}
