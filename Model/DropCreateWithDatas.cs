using Model.Entities;
using System;
using System.Data.Entity;

namespace Model
{
    internal class DropCreateWithDatas : DropCreateDatabaseIfModelChanges<MyDbContexte>
    {
        public DropCreateWithDatas()
        {
        }

        protected override void Seed(MyDbContexte context)
        {
            context.Offres.Add(new Entities.Offre()
            {
                Intitule = "Offre 1",
                Date = DateTime.Now,
                Description = "super offre 1 descriptioon",
                Salaire = 50000,
                Statut = new Entities.Statut()
                {
                    Libelle = "Statut 1"
                },
            });

            context.Offres.Add(new Entities.Offre()
            {
                Intitule = "Offre 2",
                Date = DateTime.Now,
                Description = "description  offre 2 ",
                Salaire = 12000,
                Statut = new Entities.Statut()
                {
                    Libelle = "Statut 2"
                },
            });

            context.Offres.Add(new Entities.Offre()
            {
                Intitule = "Offre 3",
                Date = DateTime.Now,
                Description = "description  offre 3 ",
                Salaire = 12000,
                Statut = new Entities.Statut()
                {
                    Libelle = "Statut 3"
                },
            });

            context.Employes.Add(new Entities.Employe()
            {
                Anciennete = 1,
                Biographie = "bonjour je suis un emploiye",
                DateDeNaissance = new DateTime(1980, 05, 06),
                Nom = "Michel",
                Prenom = "Jean",
            }) ;

            context.Employes.Add(new Entities.Employe()
            {
                Anciennete = 5,
                Biographie = "bonjour je suis un emploiye 2",
                DateDeNaissance = new DateTime(1980, 05, 06),
                Nom = "Patrick",
                Prenom = "zebi",
            });

        }
    }
}