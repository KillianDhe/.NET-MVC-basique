using ApplicationWeb.Models;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicationWeb.Converter
{
    internal static class PostulationViewModelConverter
    {
        internal static PostulationViewModel ConvertToViewModel(Postulation model)
        {
            if(model is null)
            {
                return null;
            }

            PostulationViewModel vm = new PostulationViewModel()
            {
                Date = model.Date,
                EmployeId = model.EmployeId,
                Offre = OffreViewModelConverter.ConvertOffreToOffreViewModel(model.Offre),
                Statut = model.Statut,
                OffreId = model.OffreId,
            };

            return vm;
        }
    }
}