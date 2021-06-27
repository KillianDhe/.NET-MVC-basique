using Console;
using Model;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunsinessLayer.Queries
{
    public class PostulationQuery
    {
        private readonly MyDbContexte _contexte;

        public PostulationQuery(MyDbContexte contexte)
        {
            _contexte = contexte;
        }

        /// <summary>
        /// Récupérer toutes les offres
        /// </summary>
        /// <returns>IQueryable d'offres</returns>
        public IQueryable<Postulation> GetAll()
        {
            return _contexte.Postulations;
        }


        /// <summary>
        /// Récupérer 
        /// </summary>
        /// <returns>IQueryable d'Postulation</returns>
        public IQueryable<Postulation> GetByOffreIdAndEmployeId(int offreId, int employeId)
        {
            return _contexte.Postulations.Where(p => p.OffreId == offreId && p.EmployeId == employeId);
        }

        /// <summary>
        /// Récupérer toutes les postulations d'un employe
        /// </summary>
        /// <returns>IQueryable de Postulation</returns>
        public IQueryable<Postulation> GetAllByEmployeId(int employeId)
        {
            return _contexte.Postulations.Where( p => p.EmployeId == employeId).Include(p => p.Offre);
        }

    }
}   
