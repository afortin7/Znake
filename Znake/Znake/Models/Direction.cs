using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Znake.Models
{
    public static class Direction
    {
        public static Position Nord => new Position() { X = 0, Y = -1 };
        public static Position Sud => new Position() { X = 0, Y = 1 };
        public static Position Est => new Position() { X = -1, Y = 0 };
        public static Position Ouest => new Position() { X = 1, Y = 0 };

    }
}
