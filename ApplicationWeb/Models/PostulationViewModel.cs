using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApplicationWeb.Models
{
    public class PostulationViewModel
    {
        public int OffreId { get; set; }

        public OffreViewModel Offre { get; set; }

        public int EmployeId { get; set; }

        [Display(Name = "Date de postultation")]
        public DateTime Date { get; set; }

        [Display(Name = "Statut postultation")]
        public string Statut { get; set; }

        public SelectList Employes { get; set; }
        
    }
}