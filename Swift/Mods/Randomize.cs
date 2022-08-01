using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swift.Mods
{
    internal class Randomize
    {
        static Random RND = new Random();
        public static double rnddouble(int max)
        {
            double fixmax = RND.NextDouble() + max;
            return fixmax;
        }
    }
}
