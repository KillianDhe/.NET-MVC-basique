using BunsinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestsUnitaires
{
    [TestClass]
    public class TestOffres
    {

        [TestMethod]
        public void GetAllOffre()
        {
            BusinessManager manager = BusinessManager.Instance;
            List<Offre> offres = manager.GetAllOffres();
            Assert.IsNotNull(offres);
        }

        [TestMethod]
        public void GetOffreById()
        {
            BusinessManager manager = BusinessManager.Instance;

            Offre offre = manager.GetAllOffres().FirstOrDefault();

            if(offre is null)
            {
                Assert.Inconclusive("pas d'offres dans la base , pas testeé getById");
            }
            Offre offreToTest = manager.GetOffreById(offre.Id);
            Assert.IsTrue(offre.Id == offreToTest.Id);
        }

        [TestMethod]
        public void AddOffre()
        {
            Offre offreToAdd = new Offre() { Intitule = "super offre ! ", Salaire = 2500, Date = DateTime.Now, Statut = new Statut() { Libelle = "En attente" } };

            BusinessManager manager = BusinessManager.Instance;

            int IdNouveloffre = manager.AjouterOffre(offreToAdd);

            Offre offreRecuepere = manager.GetOffreById(IdNouveloffre);

            Assert.IsTrue(IdNouveloffre != 0);
            Assert.IsTrue(offreRecuepere.Intitule == offreToAdd.Intitule);
            Assert.IsTrue(offreRecuepere.Salaire == offreToAdd.Salaire);
            Assert.IsTrue(offreRecuepere.Date == offreToAdd.Date);
        }


    }
}
