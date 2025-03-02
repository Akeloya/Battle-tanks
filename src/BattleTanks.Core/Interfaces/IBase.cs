namespace BattleTanks.Core.Interfaces
{
    public interface IBase : IResource, IGameCard
    {
        public IDefenceCard Defence { get; set; }

        bool Attacked { get; }

        void DoDefence(IEnumerable<IAttackCard> attackCards);
    }
}
