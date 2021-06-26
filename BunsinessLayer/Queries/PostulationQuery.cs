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
            return _contexte.Postulations.Where(o => o.OffreId == offreId && o.EmployeId == employeId);
        }

        /// <summary>
        /// Récupérer toutes les postulations d'un employe
        /// </summary>
        /// <returns>IQueryable de Postulation</returns>
        public IQueryable<Postulation> GetByOffreAndEmployeId(int employeId)
        {
            return _contexte.Postulations.Where( o => o.EmployeId == employeId);
        }

    }
}
