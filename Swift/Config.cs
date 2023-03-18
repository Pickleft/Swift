namespace Swift
{
    internal class Config
    {
        public Config(uint boostmax, uint dropmax, uint boostmin, uint dropmin, uint chanceboost, uint randomseed)
        {
            BoostMax = boostmax;
            DropMax = dropmax;
            BoostMin = boostmin;
            DropMin = dropmin;
            ChanceBoost = chanceboost;
            RandomSeed = randomseed;
        }

        public uint BoostMax { get; set; }

        public uint DropMax { get; set; }

        public uint BoostMin { get; set; }

        public uint DropMin { get; set; }

        public uint ChanceBoost { get; set; }

        public uint RandomSeed { get; set; }
    }
}
