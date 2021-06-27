using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApplicationWeb.Models
{
    public class OffreViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Intitule { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Un salaire négatif ??")]
        public float Salaire { get; set; }

        [Required]
        public string Description { get; set; }

        public StatutViewModel Statut { get; set; }

        [Display(Name = "Statut")]
        public int StatutId { get; set; }

        public SelectList Statuts { get; set; }

        public string Responsable { get; set; }

    }
}