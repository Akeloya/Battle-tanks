using BattleTanks.Core.Interfaces;

namespace BattleTanks.Core.Cards
{
    internal class BaseCard : IBase
    {
        public IDefenceCard? Defence { get; set; }
        public bool Attacked { get; }
        public short Value { get; init;}
        public required string Name { get; init; }
        public CardType Type { get; init; }

        public void DoDefence(IEnumerable<IAttackCard> attackCards)
        {
            throw new NotImplementedException();
        }
    }
}
