using WoT.Rush.Core.Interfaces;

namespace WoT.Rush.Core.Cards
{
    public class MedalCard : IMedalCard
    {
        public short Value {get; private set;}

        public Nation Nation {get; private set;}
    }
}
