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
    public class DetailOffreViewModel : BaseViewModel
    {
        private ListEmployesViewModel listEmployeViewModel = null;


        private int _id;
        private string _intitule;
        private DateTime? _date;
        private string _description;
        private float _salaire;
        private string _responsable;
        private string _statut;
        private ICollection<Employe> employes;
        private RelayCommand _saveOffre;

        /// <summary>
        /// Constructeur par défaut
        /// <param name="o">Offre à transformer en DetailOffreViewModel</param>
        /// </summary>
        public DetailOffreViewModel(Offre o)
        {
            listEmployeViewModel = new ListEmployesViewModel(o.Id);

            _id = o.Id;
            _intitule = o.Intitule;
            _date = o.Date;
            _description = o.Description;
            _salaire = o.Salaire;
            _responsable = o.Responsable;
            _statut = o.Statut?.Libelle;
        }

        /// <summary>
        /// Obtient ou définit le listEmployesViewModel
        /// </summary>
        public ListEmployesViewModel ListEmployeViewModel
        {
            get { return listEmployeViewModel; }
            set { listEmployeViewModel = value; }
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
        public DateTime? Date
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
        public string Statut
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
        public ICollection<Employe> Employes
        {
            get { return employes; }
            set
            {
                employes = value;
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
            BusinessManager.Instance.ModifierOffre(new Offre
            {
                Id = _id,
                Intitule = _intitule,
                Date = _date,
                Description = _description,
                Salaire = _salaire,
                Responsable = _responsable
            });
        }
    }
}
