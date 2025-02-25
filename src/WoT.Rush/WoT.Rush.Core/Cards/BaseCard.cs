using WoT.Rush.Core.Interfaces;

namespace WoT.Rush.Core.Cards
{
    public class BaseCard : IBase
    {
        public IDefenceCard Defence { get; set; }

        public bool Attacked { get; }

        public short Value { get; }

        public void DoDefence(IEnumerable<IAttackCard> attackCards)
        {
            throw new NotImplementedException();
        }
    }
}
