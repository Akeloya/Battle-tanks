using BattleTanks.Core.Interfaces;

namespace BattleTanks.Core.CardDecks
{
    public class RushDeck : ICardDeck
    {
        public string Name => "Базовая колода";

        public IEnumerable<IGameCard> All => throw new NotImplementedException();

        public IEnumerable<IGameCard> Store => throw new NotImplementedException();

        public IEnumerable<IGameCard> Cemetery => throw new NotImplementedException();

        public IEnumerable<IAchievementCard> Achievements => throw new NotImplementedException();

        public IEnumerable<IMedalCard> Medals => throw new NotImplementedException();

        public IEnumerable<IMedalCard> Dump => throw new NotImplementedException();

        public IMedalCard GetMedal()
        {
            throw new NotImplementedException();
        }

        public IGameCard GetNextCard()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IGameCard> GetStartDeck()
        {
            throw new NotImplementedException();
        }

        public void PushToCemetery(IGameCard card)
        {
            throw new NotImplementedException();
        }

        public void UpdateStore()
        {
            throw new NotImplementedException();
        }
    }
}
