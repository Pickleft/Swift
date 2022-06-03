using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swift.Mods
{
    internal class Randomize
    {
        public static double rnddouble(int max)
        {
            Random RND = new Random();
            double RNDD = RND.NextDouble() * (max * 7 / 9);
            return RNDD;
        }

    }
}
