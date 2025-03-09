
using BattleTanks.Core.Interfaces;

namespace BattleTanks.Core.Cards
{
    public abstract class AAchievementCard : IAchievementCard
    {
        public required string Name { get; init;}

        public required string Description { get; init;}

        public short Value { get; init;}

        public abstract int GetScoreFromDeck(IEnumerable<IGameCard> cards);
    }
}
