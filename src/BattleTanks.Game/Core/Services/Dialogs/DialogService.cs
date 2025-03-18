using Avalonia.Platform.Storage;

using BattleTanks.Game.Core.Services.Windows;
using BattleTanks.Game.ViewModels.Dialogs;

using DialogHostAvalonia;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BattleTanks.Game.Core.Services.Dialogs
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
        public Task<IReadOnlyList<IStorageFolder>> OpenFolderPickerAsync(DialogFolderProperties? dialogFolderProperties = null)
        {
            dialogFolderProperties ??= DialogFolderProperties.Default;
            return _storageProvider.OpenFolderPickerAsync(new FolderPickerOpenOptions()
            {
                AllowMultiple = dialogFolderProperties.AllowMultiple,
                Title = dialogFolderProperties.Title,
                SuggestedFileName = dialogFolderProperties.SuggestedFileName,
                SuggestedStartLocation = dialogFolderProperties.SuggestedLocation
            });
        }

        public Task<IStorageFile?> SaveFilePickerAsync(SaveFileProperties? saveFileProperties = null)
        {
            saveFileProperties ??= SaveFileProperties.Default;
            return _storageProvider.SaveFilePickerAsync(new FilePickerSaveOptions()
            {
                Title = saveFileProperties.Title,
                DefaultExtension = saveFileProperties.DefaultExtension,
                FileTypeChoices = saveFileProperties.FileTypeChoices,
                ShowOverwritePrompt = saveFileProperties.ShowOverwritePrompt,
                SuggestedFileName = saveFileProperties.SuggestedFileName,
                SuggestedStartLocation = saveFileProperties.SuggestedLocation
            });
        }

        public Task<IReadOnlyList<IStorageFile>> OpenFilePickerAsync(DialogFileProperties? fileProperties = null)
        {
            fileProperties ??= DialogFileProperties.Default;
            return _storageProvider.OpenFilePickerAsync(new FilePickerOpenOptions()
            {
                AllowMultiple = fileProperties.AllowMultiple,
                Title = fileProperties.Title,
                SuggestedFileName = fileProperties.SuggestedFileName,
                SuggestedStartLocation = fileProperties.SuggestedLocation,
                FileTypeFilter = fileProperties.FileTypeChoices
            });
        }

        public async Task ShowErrorAsync(string message)
        {
            var vm = new ErrorViewModel
            {
                ErrorMessage = message
            };
            using var semaphoreSlim = new SemaphoreSlim(0);
            vm.OnClose += (_, _) =>
            {
                _dialogHost.IsOpen = false;
                _dialogHost.DialogContent = null;
                semaphoreSlim.Release();
            };
            _dialogHost.DialogContent = new ViewLocator().Build(vm);
            _dialogHost.IsOpen = true;
            await semaphoreSlim.WaitAsync();
        }

        public Task ShowErrorAsync(Exception ex)
        {
            return ShowDialogAsync(new ErrorViewModel { Exception = ex });
        }

        public Task ShowInfoAsync(string data)
        {
            return ShowDialogAsync(new DialogViewModel { Content = data });
        }

        public async Task ShowWarningAsync(string data)
        {
            await ShowDialogAsync(new DialogViewModel { Content = data });
        }

        public async Task ShowDialogAsync(object data)
        {
            if (data is not DialogViewModel vm)
            {
                vm = new DialogViewModel
                {
                    Content = data
                };
            }

            using var semaphoreSlim = new SemaphoreSlim(0);
            vm.OnClose += (_, _) =>
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
