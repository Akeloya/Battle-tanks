using BattleTanks.Core.Interfaces;

namespace BattleTanks.Core.Store
{
    public class CardDefinitinon
    {
        public required string Name { get; set; }
        public CardType Type { get; set; }
        public required string Nation { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public short Resource { get; set; }
        public required string ResourceNation { get; set; }
        public string[]? Abilities { get; set; }
        public required List<Ability> AbilitesValues { get; set; }
        public string? Image { get; set; }

        public class Ability
        {
            public string? Name { get; set; }
            public int? Value { get; set; }
        }
    }
    public class CardStore
    {
        public required List<CardDefinitinon> BattleCards { get; set; }
    }
}
