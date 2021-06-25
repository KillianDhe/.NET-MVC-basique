using BunsinessLayer;
using Model.Entities;
using System.Collections.ObjectModel;
using System.Linq;
using WPF.ViewModels.Common;

namespace WPF.ViewModels
{
    public class ListEmployesViewModel : BaseViewModel
    {
        private ObservableCollection<DetailEmployeViewModel> _employes = null;
        private DetailEmployeViewModel _selectedEmploye;

        public ListEmployesViewModel(int offreId)
        {
            _employes = new ObservableCollection<DetailEmployeViewModel>();
            foreach (Employe employe in BusinessManager.Instance.GetAllPostulantsByOffreId(offreId))
            {
                _employes.Add(new DetailEmployeViewModel(employe));
            }

            if (_employes != null && _employes.Count > 0)
                _selectedEmploye = _employes.ElementAt(0);
        }

        /// <summary>
        /// Obtient ou définit une collection de DetailEmployeViewModel (Observable)
        /// </summary>
        public ObservableCollection<DetailEmployeViewModel> Employes
        {
            get { return _employes; }
            set
            {
                _employes = value;
                OnPropertyChanged("Employes");
            }
        }

        /// <summary>
        /// Obtient ou défini l'emplloyé en cours de sélection dans la liste de DetaiEmployeViewModel
        /// </summary>
        public DetailEmployeViewModel SelectedEmploye
        {
            get { return _selectedEmploye; }
            set
            {
                _selectedEmploye = value;
                OnPropertyChanged("SelectedEmploye");
            }
        }
    }
}