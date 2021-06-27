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



        public Postulation Postuler(int employeId, int offreId)
        {
            Postulation existante = _contexte.Postulations.Where(p => p.OffreId == offreId  && p.EmployeId == employeId).FirstOrDefault();
            if(existante != null)
            {
                return existante;
            }

            Postulation postulation = new Postulation()
            {
                Date = DateTime.Now,
                Statut = "nouveau",
                EmployeId = employeId,
                OffreId = offreId,
            };

            _contexte.Postulations.Add(postulation);
            _contexte.SaveChanges();
            return postulation;
        }
    }
}
