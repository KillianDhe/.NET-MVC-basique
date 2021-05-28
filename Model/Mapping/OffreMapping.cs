using Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Mapping
{
    public class OffreMapping : EntityTypeConfiguration<Offre>
    {
        public OffreMapping()
        {
            ToTable("APP_OFFRE");
            HasKey(o => o.Id);
            Property(o => o.Id).HasColumnName("OFF_ID").IsRequired();
            Property(o => o.Intitule).HasColumnName("OFF_INTITULE").IsRequired().HasMaxLength(255);
            Property(o => o.Date).HasColumnName("OFF_DATE");
            Property(o => o.Salaire).HasColumnName("OFF_SALAIRE");
            Property(o => o.Description).HasColumnName("OFF_DESCRIPTION");

            Property(o => o.StatutId).IsRequired().HasColumnName("STA_ID");
            Property(o => o.Responsable).HasColumnName("OFF_RESPONSABLE");

            HasRequired(o => o.Statut).WithMany(o => o.Offres).HasForeignKey(o => o.StatutId);
            HasMany(o => o.Postuations).WithRequired(p => p.Offre).HasForeignKey(p => p.OffreId);
        }
    }
}