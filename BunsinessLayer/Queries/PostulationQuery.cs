using Console;
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
        /// Récupérer toutes les offres
        /// </summary>
        /// <returns>IQueryable d'offres</returns>
        public IQueryable<Postulation> GetByOffreIdAndEmployeId(int offreId, int employeId)
        {
            return _contexte.Postulations.Where(o => o.OffreId == offreId && o.EmployeId == employeId);
        }


    }
}
