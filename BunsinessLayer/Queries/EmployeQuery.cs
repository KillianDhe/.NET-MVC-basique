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
            return _contexte.Employes;
        }


        /// <summary>
        /// Récupérer toutes les Employees
        /// </summary>
        /// <returns>IQueryable d'Employees</returns>
        public Employe GetById(int id)
        {
            Employe e = _contexte.Employes.Find(id);
            if (e != null)
            {
                return e;
            }
            return null;
        }

        /// <summary>
        /// Récupérer toutes les offres
        /// </summary>
        /// <returns>IQueryable d'offres</returns>
        public IQueryable<Employe> GetAllByNom(string nom)
        {
            return _contexte.Employes.Where(e => e.Nom == nom);
        }


        /// <summary>
        /// Récupérer toutes les Employees
        /// </summary>
        /// <returns>IQueryable d'Employees</returns>
        public IQueryable<Employe> GetAllByNomPrenom(string nom, string prenom)
        {
            return _contexte.Employes.Where(e => e.Prenom == prenom && e.Nom == nom);
        }

        public IQueryable<Employe> GetAllPostulantsByOffreId(int offreId)
        {
            return _contexte.Postulations.Where(p => p.OffreId == offreId).Select(p => p.Employe);    
        }


        public void AjouterPostulation(int employeId, Postulation postulation)
        {
            Employe employe = _contexte.Employes.Find(employeId);
            if(employe != null)
            {
                employe.Postulations.Add(postulation);
            }
            _contexte.SaveChanges();
        }
    }
}
