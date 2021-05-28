using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Experience
    {
        public int Id { get; set; }
        public int EmployeId { get; set; }

        public Employe employe { get; set; }

        public string Intitule { get; set; }

        public DateTime Date { get; set; }


    }
}
