namespace BattleTanks.Core.Interfaces
{
    public interface ICardDeck
    {
        string Name { get; }
        IEnumerable<IGameCard> All { get; }
        IEnumerable<IGameCard> Store { get; }
        IEnumerable<IGameCard> Cemetery { get; }
        IEnumerable<IAchievementCard> Achievements { get; }
        IEnumerable<IMedalCard> Medals { get; }
        IEnumerable<IMedalCard> Dump { get; }
        IEnumerable<IGameCard> GetStartDeck();
        IGameCard GetNextCard();
        void PushToCemetery(IGameCard card);
        IMedalCard GetMedal();
        void UpdateStore();
    }
}
