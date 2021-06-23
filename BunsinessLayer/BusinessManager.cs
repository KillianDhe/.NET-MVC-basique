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
            EmployeQuery employeQuery = new EmployeQuery(contexte);
            return employeQuery.GetAll().ToList();
        }

        /// <summary>
        /// Récupérer un employe en base avec son identifiant
        /// </summary>
        /// <param name="employeID">Identifiant de l'employe à supprimer</param>
        /// <returns>L'employe recherché</returns>
        public Employe GetEmployeById(int employeID)
        {
            EmployeQuery employeQuery = new EmployeQuery(contexte);
            return employeQuery.GetById(employeID);
        }

        /// <summary>
        /// Ajouter un employe en base
        /// </summary>
        /// <param name="e">Employe à ajouter</param>
        /// <returns>Identifiant du nouveau employe</returns>
        public int AjouterEmploye(Employe e)
        {
            // TODO : ajouter des contrôles sur le employe (exemple : vérification de champ, etc.)
            EmployeCommand employeCommand = new EmployeCommand(contexte);
            return employeCommand.Ajouter(e);
        }

        /// <summary>
        /// Modifier un employe en base
        /// </summary>
        /// <param name="e">Employe à modifier</param>
        public void ModifierEmploye(Employe e)
        {
            // TODO : ajouter des contrôles sur le employe (exemple : vérification de champ, etc.)
            EmployeCommand employeCommand = new EmployeCommand(contexte);
            employeCommand.Modifier(e);
        }

        /// <summary>
        /// Supprimer un employe en base
        /// </summary>
        /// <param name="employeID">Identifiant de l'employe à supprimer</param>
        public void SupprimerEmploye(int employeId)
        {
            EmployeCommand employeCommand = new EmployeCommand(contexte);
            employeCommand.Supprimer(employeId);
        }

        /// <summary>
        /// Ajouter une postulation à un employe
        /// </summary>
        /// <param name="employeId">Identifiant de l'employe</param>
        /// <param name="p">Postulation à ajoutée</param>
        public void AjouterPostulationToEmploye(int employeId, Postulation p)
        {
            EmployeCommand employeCommand = new EmployeCommand(contexte);
            employeCommand.AjouterPostulation(employeId, p);
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
            OffreQuery offreQuery = new OffreQuery(contexte);
            return offreQuery.GetAll().ToList();
        }

        /// <summary>
        /// Récupérer une offre en base avec son identifiant
        /// </summary>
        /// <param name="offreID">Identifiant de l'offre à supprimer</param>
        /// <returns>L'employe recherché</returns>
        public Offre GetOffreById(int offreID)
        {
            OffreQuery offreQuery = new OffreQuery(contexte);
            return offreQuery.GetById(offreID);
        }

        /// <summary>
        /// Ajouter une offre en base
        /// </summary>
        /// <param name="o">Offre à ajouter</param>
        /// <returns>Identifiant de la nouvelle offre</returns>
        public int AjouterOffre(Offre offre)
        {
            Statut newStatut = GetStatutById(offre.StatutId);
            offre.Statut = newStatut;
            // TODO : ajouter des contrôles sur le employe (exemple : vérification de champ, etc.)
            OffreCommand offreCommand = new OffreCommand(contexte);
            return offreCommand.Ajouter(offre);
        }

        /// <summary>
        /// Modifier une offre en base
        /// </summary>
        /// <param name="o">Offre à modifier</param>
        public Offre ModifierOffre(Offre offre)
        {
            Statut newStatut = GetStatutById(offre.StatutId);
            offre.Statut = newStatut;
            OffreCommand offreCommand = new OffreCommand(contexte);
            return offreCommand.Modifier(offre);
        }

        /// <summary>
        /// Supprimer une offre en base
        /// </summary>
        /// <param name="offreID">Identifiant de l'offre à supprimer</param>
        public void SupprimerOffre(int offreID)
        {
            OffreCommand offreCommand = new OffreCommand(contexte);
            offreCommand.Supprimer(offreID);
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

        #region Statut
        /// <summary>
        /// Récupérer tous les statuts en base
        /// </summary>
        /// <returns>Liste de statuts</returns>
        public List<Statut> GetAllStatuts()
        {
            StatutQuery query = new StatutQuery(contexte);
            return query.GetAll().ToList();
        }


        public Statut GetStatutById(int statutId)
        {
            StatutQuery query = new StatutQuery(contexte);
            return query.getById(statutId);
        }
        #endregion


    }
}
