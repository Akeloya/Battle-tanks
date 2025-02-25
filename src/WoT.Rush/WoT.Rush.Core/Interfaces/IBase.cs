namespace WoT.Rush.Core.Interfaces
{
    public interface IBase : IResource
    {
        public IDefenceCard Defence { get; set; }

        bool Attacked { get; }

        void DoDefence(IEnumerable<IAttackCard> attackCards);
    }
}
