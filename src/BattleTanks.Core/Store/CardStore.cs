namespace BattleTanks.Core.Store
{
    public class CardDefinitinon
    {
        public string Name {get;set;}
        public int Attack {get;set;}
        public int Defence {get;set;}
        public string Nation {get;set;}
        public short Resource {get; set;}
        public string ResourceNation {get;set;}
        public string[] Abilities {get;set;} 
        public string Image {get;set;}
    }
    public class CardStore
    {
        public List<CardDefinitinon> BattleCards { get; set; }
    }
}
