namespace BattleTanks.Core.Interfaces
{
    public interface IAttackCard : IGameCard, INational
    {
        short Attack { get; init;}
        void DoAttack(IEnumerable<IAttackCard> with, IDefenceCard target);
    }
}
