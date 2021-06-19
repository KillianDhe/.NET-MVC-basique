using BunsinessLayer.Commands;
using BunsinessLayer.Queries;
using Console;
using Model;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BunsinessLayer
{
    public class BusinessManager
    {
        private readonly MyDbContexte contexte;
        private static BusinessManager businessManager = null;

        private BusinessManager()
        {
            contexte = new MyDbContexte();
        }

        public static BusinessManager Instance
        {
            get
            {
                if (businessManager == null)
                    businessManager = new BusinessManager();
                return businessManager;
            }
        }

        #region Employe

        /// <summary>
        /// Récupérer une liste d'employes en base
        /// </summary>
        /// <returns>Liste d'employe</returns>
        public List<Employe> GetAllEmploye()
        {
            EmployeQuery eq = new EmployeQuery(contexte);
            return eq.GetAll().ToList();
        }

        /// <summary>
        /// Récupérer un employe en base avec son identifiant
        /// </summary>
        /// <param name="employeID">Identifiant de l'employe à supprimer</param>
        /// <returns>L'employe recherché</returns>
        public Employe GetEmployeById(int employeID)
        {
            EmployeQuery eq = new EmployeQuery(contexte);
            return eq.GetById(employeID);
        }

        /// <summary>
        /// Ajouter un employe en base
        /// </summary>
        /// <param name="e">Employe à ajouter</param>
        /// <returns>Identifiant du nouveau employe</returns>
        public int AjouterEmploye(Employe e)
        {
            // TODO : ajouter des contrôles sur le employe (exemple : vérification de champ, etc.)
            EmployeCommand ec = new EmployeCommand(contexte);
            return ec.Ajouter(e);
        }

        /// <summary>
        /// Modifier un employe en base
        /// </summary>
        /// <param name="e">Employe à modifier</param>
        public void ModifierEmploye(Employe e)
        {
            // TODO : ajouter des contrôles sur le employe (exemple : vérification de champ, etc.)
            EmployeCommand ec = new EmployeCommand(contexte);
            ec.Modifier(e);
        }

        /// <summary>
        /// Supprimer un employe en base
        /// </summary>
        /// <param name="employeID">Identifiant de l'employe à supprimer</param>
        public void SupprimerEmploye(int employeId)
        {
            EmployeCommand ec = new EmployeCommand(contexte);
            ec.Supprimer(employeId);
        }

        /// <summary>
        /// Ajouter une postulation à un employe
        /// </summary>
        /// <param name="employeId">Identifiant de l'employe</param>
        /// <param name="p">Postulation à ajoutée</param>
        public void AjouterPostulationToEmploye(int employeId, Postulation p)
        {
            EmployeCommand ec = new EmployeCommand(contexte);
            ec.AjouterPostulation(employeId, p);
        }

        public Employe GetEmployeByNom(string nom)
        {
            EmployeQuery query = new EmployeQuery(contexte);
            return query.GetAllByNom(nom).FirstOrDefault();
        }

        public Employe GetEmployeByNomPrenom(string nom, string prenom)
        {
            EmployeQuery query = new EmployeQuery(contexte);
            return query.GetAllByNomPrenom(nom, prenom).FirstOrDefault();
        }

        #endregion

        #region Offre

        /// <summary>
        /// Récupérer une liste d'offres en base
        /// </summary>
        /// <returns>Liste d'offres</returns>
        public List<Offre> GetAllOffres()
        {
            OffreQuery oq = new OffreQuery(contexte);
            return oq.GetAll().ToList();
        }

        /// <summary>
        /// Récupérer une offre en base avec son identifiant
        /// </summary>
        /// <param name="offreID">Identifiant de l'offre à supprimer</param>
        /// <returns>L'employe recherché</returns>
        public Offre GetOffreById(int offreID)
        {
            OffreQuery oq = new OffreQuery(contexte);
            return oq.GetById(offreID);
        }

        /// <summary>
        /// Ajouter une offre en base
        /// </summary>
        /// <param name="o">Offre à ajouter</param>
        /// <returns>Identifiant de la nouvelle offre</returns>
        public int AjouterOffre(Offre o)
        {
            // TODO : ajouter des contrôles sur le employe (exemple : vérification de champ, etc.)
            OffreCommand oc = new OffreCommand(contexte);
            return oc.Ajouter(o);
        }

        /// <summary>
        /// Modifier une offre en base
        /// </summary>
        /// <param name="o">Offre à modifier</param>
        public Offre ModifierOffre(Offre o)
        {
            // TODO : ajouter des contrôles sur le employe (exemple : vérification de champ, etc.)
            OffreCommand oc = new OffreCommand(contexte);
            return oc.Modifier(o);
        }

        /// <summary>
        /// Supprimer une offre en base
        /// </summary>
        /// <param name="offreID">Identifiant de l'offre à supprimer</param>
        public void SupprimerOffre(int offreID)
        {
            OffreCommand oc = new OffreCommand(contexte);
            oc.Supprimer(offreID);
        }

        public List<Offre> GetAllOffresByStatut(Statut statut)
        {
            OffreQuery query = new OffreQuery(contexte);
            return query.GetAllWithStatus(statut).ToList();
        }

        #endregion

        #region Postulation

        public List<Postulation> GetAllPostulation()
        {
            PostulationQuery query = new PostulationQuery(contexte);
            return query.GetAll().ToList();
        }

        public Postulation GetPostulation(int offreid, int postulationId)
        {
            PostulationQuery query = new PostulationQuery(contexte);
            return query.GetByOffreIdAndEmployeId(offreid, postulationId).FirstOrDefault();
        }

        #endregion
    }
}
