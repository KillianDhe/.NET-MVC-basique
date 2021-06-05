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
    public class DetailOffreViewModel : BaseViewModel
    {

        private string _intitule;
        private DateTime _date;
        private string _description;
        private float _salaire;
        private string _responsable;
        private Statut _statut;
        private ICollection<Postulation> _postulations;
        private RelayCommand _saveOffre;

        /// <summary>
        /// Constructeur par défaut
        /// <param name="o">Offre à transformer en DetailOffreViewModel</param>
        /// </summary>
        public DetailOffreViewModel(Offre o)
        {

            _intitule = o.Intitule;
            _date = o.Date;
            _description = o.Description;
            _salaire = o.Salaire;
            _responsable = o.Responsable;
            _statut = o.Statut;
            _postulations = o.Postuations;
        }

        /// <summary>
        /// Intitule de l'offre
        /// </summary>
        public string Intitule
        {
            get { return _intitule; }
            set { 
                _intitule = value;
                OnPropertyChanged("Intitule");
            }
        }

        /// <summary>
        /// Date de l'offre
        /// </summary>
        public DateTime Date
        {
            get { return _date; }
            set { 
                _date = value;
                OnPropertyChanged("Date");
            }
        }

        /// <summary>
        /// Description de l'offre
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { 
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        /// <summary>
        /// Salaire de l'offre
        /// </summary>
        public float Salaire
        {
            get { return _salaire; }
            set { 
                _salaire = value;
                OnPropertyChanged("Salaire");
            }
        }

        /// <summary>
        /// Responsable de l'offre
        /// </summary>
        public string Responsable
        {
            get { return _responsable; }
            set { 
                _responsable = value;
                OnPropertyChanged("Responsable");
            }
        }

        /// <summary>
        /// Statut de l'offre
        /// </summary>
        public Statut Statut
        {
            get { return _statut; }
            set { 
                _statut = value;
                OnPropertyChanged("Statut");
            }
        }

        /// <summary>
        /// Postulation pour cette offre
        /// </summary>
        public ICollection<Postulation> Postulations
        {
            get { return _postulations; }
            set
            {
                _postulations = value;
                OnPropertyChanged("Postulations");
            }
        }

        /// <summary>
        /// Commande pour sauvegarder une offre
        /// </summary>
        public ICommand SaveOffre
        {
            get
            {
                if (_saveOffre == null)
                    _saveOffre = new RelayCommand(() => this.saveOffre());
                return _saveOffre;
            }
        }

        private void saveOffre()
        {
            // Todo : Save l'offre en BDD
        }
    }
}
