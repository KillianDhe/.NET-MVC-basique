using ApplicationWeb.Models;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicationWeb.Converter
{
    internal static class OffreViewModelConverter
    {
        internal static OffreViewModel ConvertOffreToOffreViewModel(Offre model)
        {
            if (model == null)
            {
                return null;
            }

            return new OffreViewModel()
            {
                Date = model.Date,
                Description = model.Description,
                Id = model.Id,
                Intitule = model.Intitule,
                Responsable = model.Responsable,
                Salaire = model.Salaire,
                Statut = StatutViewModelConverter.ConvertStatutToStatutViewModel(model.Statut),
                StatutId = model.StatutId,
            };
        }

        internal static Offre ConvertOffreViewModelToOffre(OffreViewModel viewModel)
        {
            if (viewModel == null)
            {
                return null;
            }
            
            return new Offre()
            {
                Date = viewModel.Date,
                Description = viewModel.Description,
                Id = viewModel.Id,
                Intitule = viewModel.Intitule,
                Responsable = viewModel.Responsable,
                Salaire = viewModel.Salaire,
                Statut = StatutViewModelConverter.ConvertStatutViewModelToStatut(viewModel.Statut),
                StatutId = viewModel.StatutId,
            };
        }
    }
}