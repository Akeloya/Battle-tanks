using Avalonia.Platform.Storage;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BattleTanks.Editor.Core.Services.Dialogs
{
    public interface IDialogService
    {
        Task<IReadOnlyList<IStorageFolder>> OpenFolderPickerAsync(bool allowMultiple = false,
            string? title = null, string? suggestedFileName = null,
            IStorageFolder? suggestedLocation = null);

        public Task<IReadOnlyList<IStorageFile>> OpenFilePickerAsync(bool allowMultiple = false,
            string? title = null, string? suggestedFileName = null, IStorageFolder? suggestedLocation = null,
            IReadOnlyList<FilePickerFileType>? fileTypeChoices = null);

        public Task<IStorageFile?> SaveFilePickerAsync(string? defaultExtension = null, bool? showOverwritePrompt = null,
            string? title = null, string? suggestedFileName = null, IReadOnlyList<FilePickerFileType>? fileTypeChoices = null,
            IStorageFolder? suggestedLocation = null);

        public Task ShowErrorAsync(Exception ex);

        public Task ShowErrorAsync(string message);
    }
}
