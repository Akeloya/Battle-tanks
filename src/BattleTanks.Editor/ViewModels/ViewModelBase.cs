using BattleTanks.Editor.Core.Services;
using BattleTanks.Editor.Core.Services.Dialogs;

using ReactiveUI;

namespace BattleTanks.Editor.ViewModels;

public class ViewModelBase : ReactiveObject
{
    public IDialogService DialogService { get; } = ServicesLocator.Get<IDialogService>();
}
