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
            return _contexte.Offres.Include(o => o.Statut);
        }


        /// <summary>
        /// Récupérer toutes les offres
        /// </summary>
        /// <returns>IQueryable d'offres</returns>
        public Offre GetById(int id)
        {
            Offre offre = _contexte.Offres.Where(o => o.Id == id).Include(o => o.Statut).FirstOrDefault();
            if (offre != null)
            {
                return offre;
            }
            return null;
        }

        /// <summary>
        /// Récupérer toutes les offres
        /// </summary>
        /// <returns>IQueryable d'offres</returns>
        public IQueryable<Offre> GetAllWithStatus(Statut statut)
        {
            return _contexte.Offres.Where(o => o.Statut.Id == statut.Id);
        }

        public IQueryable<Offre>RechercheByIntituleOrDescription(string recherche)
        {
            return _contexte.Offres.Where(o => o.Intitule.ToUpper().Contains(recherche.ToUpper()) || o.Description.ToUpper().Contains(recherche.ToUpper())).Include( o => o.Statut);
        }
    }
}
