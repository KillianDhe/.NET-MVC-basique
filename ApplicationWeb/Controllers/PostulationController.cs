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
    public class PostulationController : Controller
    {

        private BusinessManager businessManager = BusinessManager.Instance;

        public ActionResult Index()
        {
         
            return View();
        }

        public ActionResult PostulerOffre(int offreId)
        {
            PostulationViewModel postulationViewModel = new PostulationViewModel();
            postulationViewModel.OffreId = offreId;

            List<Employe> employes = businessManager.GetAllEmploye();
            postulationViewModel.Employes = new SelectList(employes, "Id", "Identite");

            return View(postulationViewModel);
        }

        [HttpPost]
        public ActionResult PostulerOffre(PostulationViewModel vm)
        {
            if (ModelState.IsValid)
            {
                businessManager.Postuler(vm.EmployeId, vm.OffreId);
                return RedirectToAction("Index","Home");
            }

            return RedirectToAction("PostulerOffre", new { offreId = vm.OffreId });
        }
    }
}