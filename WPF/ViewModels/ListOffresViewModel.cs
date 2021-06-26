using BunsinessLayer;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.ViewModels.Common;

namespace WPF.ViewModels
{
    public class ListOffresViewModel: BaseViewModel
    {

        private ObservableCollection<DetailOffreViewModel> _offres = null;
        private DetailOffreViewModel _selectedOffres;
        private ObservableCollection<Statut> _statuts;
        private Statut _selectedStatut;
        private RelayCommand _supprSelectedStatut;

        public ListOffresViewModel()
        {
            loadOffre(BusinessManager.Instance.GetAllOffres());
            
            _statuts = new ObservableCollection<Statut>(BusinessManager.Instance.GetAllStatuts());
        }

        /// <summary>
        /// Obtient ou définit une collection de DetailOffreViewModel (Observable)
        /// </summary>
        public ObservableCollection<DetailOffreViewModel> Offres
        {
            get { return _offres; }
            set
            {
                _offres = value;
                OnPropertyChanged("Offres");
            }
        }

        /// <summary>
        /// Obtient ou défini l'offre en cours de sélection dans la liste de DetailOffreViewModel
        /// </summary>
        public DetailOffreViewModel SelectedOffres
        {
            get { return _selectedOffres; }
            set
            {
                _selectedOffres = value;
                OnPropertyChanged("SelectedOffres");
            }
        }

        /// <summary>
        /// Listes des statuts
        /// </summary>
        public ObservableCollection<Statut> Statuts
        {
            get { return _statuts; }
        }

        /// <summary>
        /// Statur sélectionné
        /// </summary>
        public Statut SelectedStatut
        {
            get { return _selectedStatut; }
            set { 
                _selectedStatut = value;
                OnPropertyChanged("SelectedStatut");

                if (!(_selectedStatut == null))
                    loadOffre(BusinessManager.Instance.GetAllOffresByStatut(_selectedStatut));
                else
                    loadOffre(BusinessManager.Instance.GetAllOffres());
                OnPropertyChanged("Offres");
            }
        }

        public RelayCommand SupprSelectedStatut
        {
            get
            {
                if (_supprSelectedStatut == null)
                    _supprSelectedStatut = new RelayCommand(() => this.supprSelectedStatut());
                return _supprSelectedStatut;
            }
        }

        private void loadOffre(List<Offre> offres)
        {
            _offres = new ObservableCollection<DetailOffreViewModel>();
            foreach (Offre o in offres)
            {
                _offres.Add(new DetailOffreViewModel(o));
            }
            OnPropertyChanged("Offres");

            if (_offres != null && _offres.Count > 0)
                _selectedOffres = _offres.ElementAt(0);
            OnPropertyChanged("SelectedOffres");
        }

        private void supprSelectedStatut()
        {
            SelectedStatut = null;
            OnPropertyChanged("SelectedStatut");
        }

    }
}
