using WoT.Rush.Core.Interfaces;

namespace WoT.Rush.Core.Cards
{
    public class AchievementCard : IAchievementCard
    {
        public string Name { get; }

        public string Description { get; }

        public short Value { get; }
    }
}
