using System;

namespace BattleTanks.Game.ViewModels.Dialogs
{
    public class ErrorViewModel : DialogViewModel
    {
        public string? ErrorMessage { get; set; }
        public Exception? Exception { get; set; }
    }
}
