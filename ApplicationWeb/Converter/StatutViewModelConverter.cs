using System;
using ApplicationWeb.Models;
using Model.Entities;

namespace ApplicationWeb.Converter
{
    internal class StatutViewModelConverter
    {
        internal static StatutViewModel ConvertStatutToStatutViewModel(Statut model)
        {
            if(model == null)
            {
                return null;
            }

            return new StatutViewModel()
            {
                Id = model.Id,
                Libelle = model.Libelle,
            };
        }

        internal static Statut ConvertStatutViewModelToStatut(StatutViewModel viewModel)
        {
            if (viewModel == null)
            {
                return null;
            }

            return new Statut()
            {
                Id = viewModel.Id,
                Libelle = viewModel.Libelle,
            };
        }
    }
}