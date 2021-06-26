using Model;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunsinessLayer.Commands
{
    public class PostulationCommand
    {
        private readonly MyDbContexte _contexte;

        public PostulationCommand(MyDbContexte contexte)
        {
            _contexte = contexte;
        }



        public Postulation Postuler(int employeId, int OffreId)
        {
            Postulation postulation = new Postulation()
            {
                Date = DateTime.Now,
                Statut = "nouveau",
                EmployeId = employeId,
                OffreId = OffreId,
            };

            _contexte.Postulations.Add(postulation);
            _contexte.SaveChanges();
            return postulation;
        }
    }
}
