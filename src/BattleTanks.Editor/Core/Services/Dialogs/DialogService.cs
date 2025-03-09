using Avalonia.Controls;
using Avalonia.Platform.Storage;

using BattleTanks.Editor.Core.Services.Windows;
using BattleTanks.Editor.ViewModels.Dialogs;
using BattleTanks.Editor.Views;
using BattleTanks.Editor.Views.Dialogs;

using DialogHostAvalonia;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BattleTanks.Editor.Core.Services.Dialogs
{
    public class DialogService : IDialogService
    {
        private readonly IStorageProvider _storageProvider;
        private readonly DialogHost _dialogHost;
        public DialogService(IStorageProvider storageProvider, DialogHost dialogHost)
        {
            _storageProvider = storageProvider;
            _dialogHost = dialogHost;
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

        public Task<IReadOnlyList<IStorageFile>> OpenFilePickerAsync(bool allowMultiple, 
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

        public async Task ShowErrorAsync(Exception ex)
        {
            var vm = new ErrorViewModel(){Exception = ex};
            using var semaphoreSlim = new SemaphoreSlim(0);
            vm.OnClose +=(_,_) => 
            {
                _dialogHost.IsOpen = false;
                _dialogHost.DialogContent = null;
                semaphoreSlim.Release();
            };
            _dialogHost.DialogContent = new ViewLocator().Build(vm);
            _dialogHost.IsOpen = true;
            await semaphoreSlim.WaitAsync();
        }

        public async Task ShowErrorAsync(string message)
        {
            var vm = new ErrorViewModel(){ErrorMessage = message};
            using var semaphoreSlim = new SemaphoreSlim(0);
            vm.OnClose +=(_,_) => 
            {
                _dialogHost.IsOpen = false;
                _dialogHost.DialogContent = null;
                semaphoreSlim.Release();
            };
            _dialogHost.DialogContent = new ViewLocator().Build(vm);
            _dialogHost.IsOpen = true;
            await semaphoreSlim.WaitAsync();
        }
    }
}
