using Console;
using Model;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunsinessLayer.Queries
{
    public class EmployeQuery
    {
        private readonly MyDbContexte _contexte;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexte"></param>
        public EmployeQuery(MyDbContexte contexte)
        {
            _contexte = contexte;
        }

        /// <summary>
        /// Récupérer toutes les Employees
        /// </summary>
        /// <returns>IQueryable d'Employees</returns>
        public IQueryable<Employe> GetAll()
        {
            return _contexte.Employees;
        }


        /// <summary>
        /// Récupérer toutes les Employees
        /// </summary>
        /// <returns>IQueryable d'Employees</returns>
        public IQueryable<Employe> GetById(int id)
        {
            return _contexte.Employees.Where(e => e.Id == id);
        }

        /// <summary>
        /// Récupérer toutes les offres
        /// </summary>
        /// <returns>IQueryable d'offres</returns>
        public IQueryable<Employe> GetAllByNom(string nom)
        {
            return _contexte.Employees.Where(e => e.Nom == nom);
        }


        /// <summary>
        /// Récupérer toutes les Employees
        /// </summary>
        /// <returns>IQueryable d'Employees</returns>
        public IQueryable<Employe> GetAllByNomPrenom(string nom, string prenom)
        {
            return _contexte.Employees.Where(e => e.Prenom == prenom && e.Nom == nom);
        }

        public void AjouterPostulation(int employeId, Postulation postulation)
        {
            Employe employe = _contexte.Employees.Find(employeId);
            if(employe != null)
            {
                employe.Postuations.Add(postulation);
            }
            _contexte.SaveChanges();
        }
    }
}
