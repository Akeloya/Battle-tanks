using System;

namespace BattleTanks.Editor.Core.Services.Dialogs
{
    public interface IDialogWindow
    {
        event EventHandler OnClose;
    }
}
