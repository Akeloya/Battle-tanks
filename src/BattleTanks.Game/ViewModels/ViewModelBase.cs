using BattleTanks.Game.Core.Services;
using BattleTanks.Game.Core.Services.Dialogs;

using ReactiveUI;

namespace BattleTanks.Game.ViewModels;

public class ViewModelBase : ReactiveObject
{
    public IDialogService DialogService { get; } = ServicesLocator.Get<IDialogService>();
}
