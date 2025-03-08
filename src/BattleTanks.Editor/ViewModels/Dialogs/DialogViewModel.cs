using BattleTanks.Editor.Core.Services.Dialogs;

using System;

namespace BattleTanks.Editor.ViewModels.Dialogs
{
    public class DialogViewModel : ViewModelBase, IDialogWindow
    {
        public event EventHandler? OnClose;

        public void Close()
        {
           OnClose?.Invoke(this, EventArgs.Empty);
        }
    }
}
