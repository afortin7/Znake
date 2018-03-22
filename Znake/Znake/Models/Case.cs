using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Znake.Models
{
    public enum Etat
    {
        Serpent,
        Pomme,
        Vide
    }

    public class Case
    {
        public Etat Etat { get; set; }
        public Position Position { get; set; }
    }
}
