using BattleTanks.Editor.Core.Services.Dialogs;

using ReactiveUI;

using System;

namespace BattleTanks.Editor.ViewModels.Dialogs
{
    public class DialogViewModel : ReactiveObject, IDialogWindow
    {
        public event EventHandler? OnClose;

        public void Close()
        {
           OnClose?.Invoke(this, EventArgs.Empty);
        }
    }
}
