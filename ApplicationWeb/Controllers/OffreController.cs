using ApplicationWeb.Converter;
using ApplicationWeb.Models;
using BunsinessLayer;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApplicationWeb.Controllers
{
    public class OffreController : Controller
    {

        private BusinessManager businessManager = BusinessManager.Instance;

        public ActionResult Index()
        {

            List<Offre> offres = businessManager.GetAllOffres();

            List<OffreViewModel> offresViewModel = new List<OffreViewModel>();

            foreach(Offre offre in offres)
            {
                offresViewModel.Add(OffreViewModelConverter.ConvertOffreToOffreViewModel(offre));
            }

            return View(offresViewModel);
        }

        public ActionResult AffichageModifierOffre(int id)
        {
            Offre offretoModify = businessManager.GetOffreById(id);
            return View(OffreViewModelConverter.ConvertOffreToOffreViewModel(offretoModify));
        }

        public ActionResult ModifierOffre(OffreViewModel offreVm)
        {
            Offre offretoModify = OffreViewModelConverter.ConvertOffreViewModelToOffre(offreVm);
            Offre offreUpdated = businessManager.ModifierOffre(offretoModify);
            OffreViewModel offreUpdatedViewModem = OffreViewModelConverter.ConvertOffreToOffreViewModel(offreUpdated);
            return View("DetailOffre", offreUpdatedViewModem);
        }


        public ActionResult DetailOffre(int id)
        {
            Offre offre = businessManager.GetOffreById(id);
            return View(OffreViewModelConverter.ConvertOffreToOffreViewModel(offre));
        }

        public ActionResult SupprimerOffre(int id)
        {
            businessManager.SupprimerOffre(id);
            return RedirectToAction("Index");
        }


    }
}