using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swift.Mods
{
    public class Randomize
    {
        public static Random C_Random { get; protected set; }
        public int Seed { get; protected set; }
        public Randomize(int seed)
        {
            C_Random = new Random(seed);
            Seed = seed;
        }

        public int Rnd(dynamic min, dynamic max)
        {
            return C_Random.Next((int)(min), (int)(max));
        }
    }
}
