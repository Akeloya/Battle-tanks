namespace BattleTanks.Core.Interfaces
{
    public interface IAchievementCard : IResource
    {
        string Name { get; init; }
        string Description { get; init; }
        int GetScoreFromDeck(IEnumerable<IGameCard> cards); 
    }
}
