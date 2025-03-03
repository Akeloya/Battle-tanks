using BattleTanks.Core.Interfaces;

namespace BattleTanks.Core.Cards
{
    public class BattleCard : IAttackCard, IDefenceCard, INationalResource
    {
        public short Value { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
        public Nation Nation { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }

        public short Defence => throw new NotImplementedException();

        public string Name { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
        public CardType Type { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
        public short Attack { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }

        public void DoAttack(IEnumerable<IAttackCard> with, IDefenceCard target)
        {
            throw new NotImplementedException();
        }

        public void DoDefence(IGameCard target)
        {
            throw new NotImplementedException();
        }
    }
}
