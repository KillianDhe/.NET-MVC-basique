using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MyDbContexte contexte = new MyDbContexte();
                contexte.Employes.Add(new Model.Entities.Employe() { Nom = "jean", Prenom = "Paul", Anciennete = 1, Biographie = " iufh QH UHsbf FB Quhhf uiQHF", DateDeNaissance = DateTime.Now });
                contexte.Employes.Add(new Model.Entities.Employe() { Nom = "Clément", Prenom = "Maisonhaute", Anciennete = 8, Biographie = "Bonjour, je m'appelle cleménet et nik", DateDeNaissance = DateTime.Now.AddDays(-1), });

                contexte.Offres.Add(new Model.Entities.Offre() { Description = "Description", Intitule = "c une offre", Salaire = 10000, Date = DateTime.Now, Statut = new Model.Entities.Statut() { Libelle = "statut" } });
                contexte.SaveChanges();

            }catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
          
        }
    }
}
