using BattleTanks.Core.Interfaces;

namespace BattleTanks.Core.Process
{
    public class GameManager
    {
        private List<IPlayerDeck> _playerDecks = new();
        public ICardDeck? CardDeck { get; }
        public IReadOnlyCollection<IPlayerDeck> PlayerDecks => _playerDecks;
        public void NextTurn()
        {

        }
    }
}
