using Model;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunsinessLayer.Commands
{
    public class EmployeCommand
    {
        private readonly MyDbContexte _contexte;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="contexte">Contexte EF à utiliser</param>
        public EmployeCommand(MyDbContexte contexte)
        {
            _contexte = contexte;
        }

        /// <summary>
        /// Ajouter l'employe en base à partir du contexte
        /// </summary>
        /// <param name="e">Employe à ajouter</param>
        /// <returns>Identifiant de l'mploye ajouté</returns>
        public int Ajouter(Employe employeToAdd)
        {
            _contexte.Employes.Add(employeToAdd);
            _contexte.SaveChanges();
            return employeToAdd.Id;
        }

        /// <summary>
        /// Modifier un employe déjà présent en base à partir du contexte
        /// </summary>
        /// <param name="e">Employe à modifier</param>
        public void Modifier(Employe employeToEdit)
        {
            Employe upEmp = _contexte.Employes.Where(emp => emp.Id == employeToEdit.Id).FirstOrDefault();
            if (upEmp != null)
            {
                upEmp.Nom = employeToEdit.Nom;
                upEmp.Anciennete = employeToEdit.Anciennete;
                upEmp.Biographie = employeToEdit.Biographie;
                upEmp.DateDeNaissance = employeToEdit.DateDeNaissance;
                upEmp.Prenom = employeToEdit.Prenom;
            }
            _contexte.SaveChanges();
        }

        /// <summary>
        /// Supprimer un employe en base à partir du contexte et de son identifiant
        /// </summary>
        /// <param name="employeId">Identifiant de l'employe à supprimer</param>
        public void Supprimer(long employeId)
        {
            Employe delEmp = _contexte.Employes.Find(employeId);
            if (delEmp != null)
            {
                _contexte.Employes.Remove(delEmp);
            }
            _contexte.SaveChanges();
        }

        /// <summary>
        /// Ajouter une postulation à un employe
        /// </summary>
        /// <param name="employeId">Identifiant de l'employe</param>
        /// <param name="p">Postulation à ajoutée</param>
        public void AjouterPostulation(int employeId, Postulation p)
        {
            Employe e = _contexte.Employes.Find(employeId);
            if (e != null)
            {
                e.Postulations.Add(p);
            }
        }
    }
}
