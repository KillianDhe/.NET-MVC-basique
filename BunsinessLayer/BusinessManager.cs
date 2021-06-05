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

        public List<Offre> GetAllOffres()
        {
            OffreQuery query = new OffreQuery(contexte);
            return query.GetAll().ToList();
        }

        public Offre GetOffreById(int offreId)
        {
            OffreQuery query = new OffreQuery(contexte);
            return query.GetById(offreId).FirstOrDefault();
        }

        /// <summary>
        /// Ajouter une offre
        /// </summary>
        /// <param name="p">Offre à ajouter</param>
        /// <returns>identifiant de l'offre ajoutée</returns>
        public int AjouterOffre(Offre offreToAdd)
        {
            if(offreToAdd.Intitule == null) { throw new ArgumentException("l'intitulé de l'offre ne peut pa etre nulle"); }
            OffreCommand offreCommand = new OffreCommand(contexte);
            return offreCommand.AjouterOffre(offreToAdd);
        }

        public List<Offre> GetAllOffresByStatut(Statut statut)
        {
            OffreQuery query = new OffreQuery(contexte);
            return query.GetAllWithStatus(statut).ToList();
        }

        public List<Employe> GetAllEmployees()
        {
            EmployeQuery query = new EmployeQuery(contexte);
            return query.GetAll().ToList();
        }

        public Employe GetEmployeById(int employeId)
        {
            EmployeQuery query = new EmployeQuery(contexte);
            return query.GetById(employeId).FirstOrDefault();
        }

        public Employe GetEmployeByNom(string nom)
        {
            EmployeQuery query = new EmployeQuery(contexte);
            return query.GetAllByNom(nom).FirstOrDefault();
        }

        public Employe GetEmployeByNomPrenom(string nom, string prenom)
        {
            EmployeQuery query = new EmployeQuery(contexte);
            return query.GetAllByNomPrenom(nom,prenom).FirstOrDefault();
        }
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

    }
}
