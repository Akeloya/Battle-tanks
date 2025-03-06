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

        public Task OpenFilePickerAsync(bool allowMultiple, 
            string? title, string? suggestedFileName, IStorageFolder? suggestedLocation,
            IReadOnlyList<FilePickerFileType>? fileTypeChoices);

        public Task<IStorageFile?> SaveFilePickerAsync(string? defaultExtension, bool? showOverwritePrompt,
            string? title, string? suggestedFileName, IReadOnlyList<FilePickerFileType>? fileTypeChoices,
            IStorageFolder? suggestedLocation);
    }
}
