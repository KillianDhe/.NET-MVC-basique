using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Postulation
    {
        public int OffreId { get; set; }

        public Offre Offre { get; set; }

        public int EmployeId { get; set; }

        public Employe Employe { get; set; }

        public DateTime Date { get; set; }

        public string Statut { get; set; }

        public List<Postulation> postulations { get; set; }
    }
}
