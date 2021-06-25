using System;
using System.Collections.Generic;
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

        public DateTime Date { get; set; }

        public string Statut { get; set; }

        public SelectList Employes { get; set; }
        
    }
}