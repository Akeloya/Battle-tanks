namespace BattleTanks.Core.Interfaces
{
    public enum CardType
    {
        FirstMoveCard,
        Achievement,
        Medal,
        Base,
        LightTank,
        MiddleTank,
        HeavyTank,
        PtSau,
        Sau,
        AuxiliaryTroops
    }
    public interface IGameCard
    {
        string Name { get; init;}
        Type Type {get; init;}
    }
}
