using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.ViewModels.Common;

namespace WPF.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private ListOffresViewModel _listeOffreViewModel = null;
        private RelayCommand _addOffre;

        public HomeViewModel()
        {
            _listeOffreViewModel = new ListOffresViewModel();
        }

        /// <summary>
        /// Obtient ou définit le ListOffreViewModel
        /// </summary>
        public ListOffresViewModel ListOffresViewModel
        {
            get { return _listeOffreViewModel; }
            set { _listeOffreViewModel = value; }
        }

        public ICommand AddOffre
        {
            get
            {
                if (_addOffre == null)
                    _addOffre = new RelayCommand(() => this.addOffre());
                return _addOffre;
            }
        }

        private void addOffre()
        {
            //Do nothing
        }

    }
}
