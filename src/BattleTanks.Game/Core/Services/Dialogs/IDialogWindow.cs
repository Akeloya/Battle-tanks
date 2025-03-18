using System;

namespace BattleTanks.Game.Core.Services.Dialogs
{
    public interface IDialogWindow
    {
        event EventHandler OnClose;
    }
}
