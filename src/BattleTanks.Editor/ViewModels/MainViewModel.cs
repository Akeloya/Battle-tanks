using System.Threading.Tasks;
using BattleTanks.Editor.Core.Services.Dialogs;
using BattleTanks.Editor.Core.Services;

namespace BattleTanks.Editor.ViewModels;

public class MainViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";

    public async Task Open()
    {
        await ServicesLocator.Get<IDialogService>().OpenFolderPickerAsync();
    }
}
