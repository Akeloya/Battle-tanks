using Avalonia.Controls;
using Avalonia.Platform.Storage;

using BattleTanks.Editor.Core.Services.Windows;
using BattleTanks.Editor.ViewModels.Dialogs;
using BattleTanks.Editor.Views.Dialogs;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BattleTanks.Editor.Core.Services.Dialogs
{
    public class DialogService : IDialogService
    {
        private readonly IStorageProvider _storageProvider;
        private readonly WindowManager _windowManager;
        public DialogService(IStorageProvider storageProvider, WindowManager windowManager)
        {
            _storageProvider = storageProvider;
            _windowManager = windowManager;
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
            var dialogWindow = _windowManager.Create();
            dialogWindow.DataContext = new ErrorViewModel
            {
                Exception = ex
            };
            await dialogWindow.ShowDialog(_windowManager.Current);
        }

        public async Task ShowErrorAsync(string message)
        {
            var dialogWindow = _windowManager.Create();
            var vm = new ErrorViewModel
            {
                ErrorMessage = message
            };
            vm.OnClose += (_,_)=> dialogWindow.Close();
            dialogWindow.DataContext = vm;
            dialogWindow.SizeToContent = SizeToContent.WidthAndHeight;
            await dialogWindow.ShowDialog(_windowManager.Current);
        }
    }
}
