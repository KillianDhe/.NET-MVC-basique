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
                contexte.Employees.Add(new Model.Entities.Employe() { Nom = "jean", Prenom = "Paul", Anciennete = 1, Biographie = " iufh QH UHsbf FB Quhhf uiQHF" , DateDeNaissance = DateTime.Now})
                contexte.Employees.Add(new Model.Entities.Employe() { Nom = "Clément", Prenom = "Maisonhaute", Anciennete = 8, Biographie = "Bonjour, je m'appelle cleménet et nik", DateDeNaissance = DateTime.Now.AddDays(-1), });


                contexte.SaveChanges();
            }catch(Exception ex)
            {

            }
          
        }
    }
}
