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

        public ActionResult ModifierOffre(int id)
        {
            Offre offretoModify = businessManager.GetOffreById(id);

            OffreViewModel offreVmToModify = OffreViewModelConverter.ConvertOffreToOffreViewModel(offretoModify);

            List<Statut> statuts = businessManager.GetAllStatuts();
            offreVmToModify.Statuts = new SelectList(statuts, "Id", "Libelle");

            return View(offreVmToModify);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModifierOffre(OffreViewModel offreVm)
        {
            if (ModelState.IsValid)
            {
                Offre offretoModify = OffreViewModelConverter.ConvertOffreViewModelToOffre(offreVm);
                Offre offreUpdated = businessManager.ModifierOffre(offretoModify);
                offreVm = OffreViewModelConverter.ConvertOffreToOffreViewModel(offreUpdated);
            }

            return View("DetailOffre", offreVm);
        }


        public ActionResult DetailOffre(int id)
        {
            Offre offre = businessManager.GetOffreById(id);
            return View(OffreViewModelConverter.ConvertOffreToOffreViewModel(offre));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SupprimerOffre(int id)
        {
            businessManager.SupprimerOffre(id);
            return RedirectToAction("Index");
        }

        public ActionResult AjouterOffre()
        {
            OffreViewModel vm = new OffreViewModel();

            List<Statut> statuts = businessManager.GetAllStatuts();
            vm.Statuts = new SelectList(statuts, "Id", "Libelle");

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjouterOffre(OffreViewModel offreVm)
        {
            if (ModelState.IsValid)
            {
                Offre offretoAdd = OffreViewModelConverter.ConvertOffreViewModelToOffre(offreVm);
                int idNouvelOffre = businessManager.AjouterOffre(offretoAdd);
                return RedirectToAction("DetailOffre", new { id = idNouvelOffre });
            }
            return View(offreVm); 

        }
    }
}