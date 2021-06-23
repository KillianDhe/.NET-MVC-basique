using Model;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunsinessLayer.Queries
{
    public class StatutQuery
    {
        private readonly MyDbContexte _contexte;

        public StatutQuery(MyDbContexte contexte)
        {
            _contexte = contexte;
        }

        /// <summary>
        /// Récupérer tous les statuts
        /// </summary>
        /// <returns>IQueryable d'offres</returns>
        public IQueryable<Statut> GetAll()
        {
            return _contexte.Statuts;
        }

        public Statut getById(int statutId)
        {
            return _contexte.Statuts.Find(statutId);
        }
    }
}
