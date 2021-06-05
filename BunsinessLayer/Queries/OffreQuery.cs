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
    public class OffreQuery
    {
        private readonly MyDbContexte _contexte;

        public OffreQuery(MyDbContexte contexte)
        {
            _contexte = contexte;
        }

        /// <summary>
        /// Récupérer toutes les offres
        /// </summary>
        /// <returns>IQueryable d'offres</returns>
        public IQueryable<Offre> GetAll()
        {
            return _contexte.Offres;
        }


        /// <summary>
        /// Récupérer toutes les offres
        /// </summary>
        /// <returns>IQueryable d'offres</returns>
        public Offre GetById(int id)
        {
            Offre o = _contexte.Offres.Find(id);
            if (o != null)
            {
                return o;
            }
            return null;
        }

        /// <summary>
        /// Récupérer toutes les offres
        /// </summary>
        /// <returns>IQueryable d'offres</returns>
        public IQueryable<Offre> GetAllWithStatus(Statut statut)
        {
            return _contexte.Offres.Where(o => o.Statut == statut);
        }


    }
}
