using Avalonia.Platform.Storage;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace BattleTanks.Editor.Core.Services.Dialogs
{
    public class DialogService : IDialogService
    {
        private readonly IStorageProvider _storageProvider;
        public DialogService(IStorageProvider storageProvider)
        {
            _storageProvider = storageProvider;
        }
        public Task<IReadOnlyList<IStorageFolder>> OpenFolderPickerAsync(bool allowMultiple, 
            string? title, string? suggestedFileName, IStorageFolder? suggestedLocation)
        {
           return _storageProvider.OpenFolderPickerAsync(new FolderPickerOpenOptions()
            {
                AllowMultiple = allowMultiple,
                Title = title,
                SuggestedFileName = suggestedFileName,
                SuggestedStartLocation = suggestedLocation
            });
        }

        public Task<IStorageFile?> SaveFilePickerAsync(string? defaultExtension, bool? showOverwritePrompt,
            string? title, string? suggestedFileName, IReadOnlyList<FilePickerFileType>? fileTypeChoices,
            IStorageFolder? suggestedLocation)
        {
           return _storageProvider.SaveFilePickerAsync(new FilePickerSaveOptions()
            {
               Title = title,
               DefaultExtension = defaultExtension,
               FileTypeChoices = fileTypeChoices,
               ShowOverwritePrompt = showOverwritePrompt,
               SuggestedFileName = suggestedFileName,
               SuggestedStartLocation = suggestedLocation
            });
        }

        public Task OpenFilePickerAsync(bool allowMultiple, 
            string? title, string? suggestedFileName, IStorageFolder? suggestedLocation,
            IReadOnlyList<FilePickerFileType>? fileTypeChoices)
        {
            return _storageProvider.OpenFilePickerAsync(new FilePickerOpenOptions()
            {
                AllowMultiple = allowMultiple,
                Title = title,
                SuggestedFileName = suggestedFileName,
                SuggestedStartLocation = suggestedLocation,
                FileTypeFilter = fileTypeChoices
            });
        }
    }
}
