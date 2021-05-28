using Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Mapping
{
    public class StatutMapping : EntityTypeConfiguration<Statut>
    {
        public StatutMapping()
        {
            ToTable("APP_STATUT");
            HasKey(o => o.Id);
            Property(o => o.Id).HasColumnName("STA_ID").IsRequired();
            Property(o => o.Libelle).HasColumnName("STA_LIBELLE").IsRequired().HasMaxLength(255);
        }
    }
}
