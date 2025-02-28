using BattleTanks.Core.Interfaces;

namespace BattleTanks.Core.Cards
{
    public class BaseCard : IBase
    {
        public IDefenceCard Defence { get; set; }

        public bool Attacked { get; }

        public short Value { get; init;}

        public void DoDefence(IEnumerable<IAttackCard> attackCards)
        {
            throw new NotImplementedException();
        }
    }
}
