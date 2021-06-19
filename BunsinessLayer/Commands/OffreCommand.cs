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
        /// Ajouter l'offre en base à partir du contexte
        /// </summary>
        /// <param name="e">Offre à ajouter</param>
        /// <returns>Identifiant de l'offre ajouté</returns>
        public int Ajouter(Offre offretoAdd)
        {
            _contexte.Offres.Add(offretoAdd);
            _contexte.SaveChanges();
            return offretoAdd.Id;

        }

        /// <summary>
        /// Modifier un offre déjà présent en base à partir du contexte
        /// </summary>
        /// <param name="o">Offre à modifier</param>
        public Offre Modifier(Offre offreEdited)
        {
            Offre offreToEdit = _contexte.Offres.Where(emp => emp.Id == offreEdited.Id).FirstOrDefault();
            if (offreToEdit != null)
            {
                offreToEdit.Intitule = offreEdited.Intitule;
                //upOff.Responsable = o.Responsable;
                offreToEdit.Salaire = offreEdited.Salaire;
                offreToEdit.Statut = offreEdited.Statut;
                offreToEdit.Date = offreEdited.Date;
                offreToEdit.Description = offreEdited.Description;
                //upOff.Postuations = o.Postuations;
            }
            _contexte.SaveChanges();
            return offreToEdit;
        }

        /// <summary>
        /// Supprimer un offre en base à partir du contexte et de son identifiant
        /// </summary>
        /// <param name="offreId">Identifiant de l'offre à supprimer</param>
        public void Supprimer(int offreId)
        {
            Offre offreToDelete = _contexte.Offres.Find(offreId);
            if (offreToDelete != null)
            {
                _contexte.Offres.Remove(offreToDelete);
            }
            _contexte.SaveChanges();
        }

    }
}
