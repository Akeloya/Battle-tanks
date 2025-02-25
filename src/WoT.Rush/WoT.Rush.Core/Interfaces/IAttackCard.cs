namespace WoT.Rush.Core.Interfaces
{
    public interface IAttackCard : IGameCard, INational
    {
        short Attack { get; }
        void DoAttack(IEnumerable<IAttackCard> with, IDefenceCard target);
    }
}
