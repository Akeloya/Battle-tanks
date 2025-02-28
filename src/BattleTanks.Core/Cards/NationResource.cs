using BattleTanks.Core.Interfaces;

namespace BattleTanks.Core.Cards
{
    public class NationResource : INationalResource
    {
        public short Value {get; init;}

        public Nation Nation {get; init;}
    }
}
