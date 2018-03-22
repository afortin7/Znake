using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Znake.Models
{
    public class Serpent
    {
        public Position Tete { get; set; }
        public Position DerniereDirection { get; set; }
        public List<Position> Queue { get; set; }
        public int NumSerpent { get; set; }

    }
}
