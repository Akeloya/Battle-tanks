using Avalonia.Platform.Storage;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace BattleTanks.Editor.Core.Services.Dialogs
{
    public interface IDialogService
    {
        Task<IReadOnlyList<IStorageFolder>> OpenFolderPickerAsync(bool allowMultiple = false, 
            string? title = null,string? suggestedFileName = null,
            IStorageFolder? suggestedLocation = null);
    }
}
