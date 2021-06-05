using Model.Entities;
using WPF.ViewModels.Common;

namespace WPF.ViewModels
{
    public class DetailEmployeViewModel : BaseViewModel
    {
        private string nom;
        private string prenom;

        public DetailEmployeViewModel(Employe employe)
        {
            nom = employe.Nom;
            prenom = employe.Prenom;
        }

        /// <summary>
        /// Nom
        /// </summary>
        public string Nom
        {
            get { return nom; }
            set
            {
                nom = value;
                OnPropertyChanged("Nom");
            }
        }

        /// <summary>
        /// Prenom
        /// </summary>
        public string Prenom
        {
            get { return prenom; }
            set
            {
                prenom = value;
                OnPropertyChanged("Prenom");
            }
        }
    }
}