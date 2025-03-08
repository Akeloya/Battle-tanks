using System;

namespace BattleTanks.Editor.ViewModels.Dialogs
{
    public class ErrorViewModel : DialogViewModel
    {
        public string ErrorMessage { get; set; }
        public Exception Exception { get; set; }
    }
}
