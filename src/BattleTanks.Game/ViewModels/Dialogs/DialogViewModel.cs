using BattleTanks.Game.Core.Services.Dialogs;

using System;

namespace BattleTanks.Game.ViewModels.Dialogs
{
    public class DialogViewModel : ViewModelBase, IDialogWindow
    {
        public event EventHandler? OnClose;
        public object? Content { get; set; }
        public void Close()
        {
            OnClose?.Invoke(this, EventArgs.Empty);
        }
    }
}
