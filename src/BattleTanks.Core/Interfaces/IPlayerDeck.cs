namespace BattleTanks.Core.Interfaces
{
    public interface IPlayerDeck
    {
        IEnumerable<IGameCard> Hangar { get; }

        IEnumerable<IGameCard> Warehouse { get; }

        IEnumerable<IGameCard> Hand { get; }

        IEnumerable<IBase> Bases { get; }

        void FillTheHand();

        void Buy(IEnumerable<IGameCard> card);

        void Attack(IPlayerDeck target);
    }
}
