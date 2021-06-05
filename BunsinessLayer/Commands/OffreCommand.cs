using Console;
using Model;
using Model.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunsinessLayer.Commands
{
    public class OffreCommand
    {
        private readonly MyDbContexte _contexte;

        public OffreCommand(MyDbContexte contexte)
        {
            _contexte = contexte;
        }

        /// <summary>
        /// Ajouter une offre
        /// </summary>
        public int AjouterOffre(Offre offre)
        {
           _contexte.Offres.Add(offre);
            _contexte.SaveChanges();
            return offre.Id;
        }


        /// <summary>
        /// Supprimer une offre
        /// </summary>
        public void SupprimerOffre(Offre offre)
        {
            Offre offreToDelete = _contexte.Offres.Find(offre.Id);
            if (offreToDelete != null)
            {
                _contexte.Offres.Remove(offre);

            }
            _contexte.SaveChanges();
        }


        public void ModifierOffre(Offre offre)
        {
            Offre offreToEdit = _contexte.Offres.Find(offre.Id);
            if(offreToEdit != null)
            {
                offre.Description = offre.Description;
                offre.Date = offre.Date;
                offre.Intitule = offre.Intitule;
                offre.Salaire = offre.Salaire;
                offre.Statut = offre.Statut;
            }
            _contexte.SaveChanges();
        }

    }
}
