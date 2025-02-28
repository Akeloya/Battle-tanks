using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTanks.Core.Interfaces
{
    public interface IPlayer
    {
        public string Name {get;set;}
        public uint Score {get;set;}
        public uint Winner {get;set;}
        public uint Looser {get;set;}
    }
}
