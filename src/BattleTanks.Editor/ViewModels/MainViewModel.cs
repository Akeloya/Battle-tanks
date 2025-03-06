using System.Threading.Tasks;
using BattleTanks.Editor.Core.Services.Dialogs;

namespace BattleTanks.Editor.ViewModels;

public class MainViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";

    public async Task Open()
    {
        await DialogService.OpenFolderPickerAsync();
    }
}
