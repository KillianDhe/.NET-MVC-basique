using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Employe
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        public string Prenom { get; set; }

        public DateTime DateDeNaissance { get; set; }

        public int Anciennete { get; set; }

        public string Biographie { get; set; }
        public List<Postulation> Postulations { get; set; }

        public List<Formation> Formations { get; set; }
        public List<Experience> Experience { get; set; }


    }
}
