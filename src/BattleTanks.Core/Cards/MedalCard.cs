
using BattleTanks.Core.Interfaces;

namespace BattleTanks.Core.Cards
{
    public class MedalCard : IMedalCard
    {
        public short Value {get; init;}

        public Nation Nation {get; init;}
        public string Name { get; init; }
        public Type Type { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
    }
}
