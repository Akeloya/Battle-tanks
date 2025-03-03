
using BattleTanks.Core.Interfaces;

namespace BattleTanks.Core.Cards
{
    public class MedalCard : IMedalCard
    {
        public short Value { get; init; }

        public required Nation Nation { get; init; }
        public required string Name { get; init; }
        public CardType Type { get; init; }
    }
}
