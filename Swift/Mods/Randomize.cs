using System;

namespace Swift.Mods
{
    public class Randomize
    {
        #region Properties
        public static Random C_Random { get; protected set; }
        public int Seed { get; protected set; }
        #endregion

        #region Constructor .ctor
        public Randomize(uint seed)
        {
            C_Random = new Random((int)seed);
            Seed = (int)seed;
        }
        #endregion

        #region Methods
        public int Rnd(dynamic min, dynamic max)
        {
            return C_Random.Next((int)min, (int)max);
        }
        #endregion
    }
}
