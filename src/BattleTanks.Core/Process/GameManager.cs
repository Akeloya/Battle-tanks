using BattleTanks.Core.Interfaces;

namespace BattleTanks.Core.Process
{
    public class GameManager
    {
        public ICardDeck CardDeck { get; }
        public IReadOnlyCollection<IPlayerDeck> PlayerDecks { get; }
        public void NextTurn()
        {

        }
    }
}
