using Avalonia.Platform.Storage;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BattleTanks.Editor.Core.Services.Dialogs
{
    public class DialogFolderProperties
    {
        public string? Title { get; set; }
        public bool AllowMultiple { get; set; }
        public string? SuggestedFileName { get; set; }
        public IStorageFolder? SuggestedLocation { get; set; }

        public static DialogFolderProperties Default => new DialogFolderProperties();
    }

    public class DialogFileProperties : DialogFolderProperties
    {
        private readonly List<FilePickerFileType> _fileTypeList = [];
        public IReadOnlyList<FilePickerFileType>? FileTypeChoices => _fileTypeList;
        public DialogFileProperties RegisterType(string name, string[]? patterns = null, string[]? appleUniformTypeIdentifiers = null, string[]? mimeTypes = null)
        {
            _fileTypeList.Add(new FilePickerFileType(name)
            {
                Patterns = patterns,//new[] { "*.png", "*.jpg", "*.jpeg", "*.gif", "*.bmp", "*.webp" },
                AppleUniformTypeIdentifiers = appleUniformTypeIdentifiers,//new[] { "public.image" },
                MimeTypes = mimeTypes//new[] { "image/*" }
            });
             
            return this;
        }
        public static new DialogFileProperties Default => new DialogFileProperties();
    }

    public class SaveFileProperties : DialogFileProperties
    {
        public string? DefaultExtension {get; set;}
        public bool? ShowOverwritePrompt {get;set;}

        public static new SaveFileProperties Default => new SaveFileProperties();
    }
    public interface IDialogService
    {
        Task<IReadOnlyList<IStorageFolder>> OpenFolderPickerAsync(DialogFolderProperties? dialogFileProperties = null);
        public Task<IReadOnlyList<IStorageFile>> OpenFilePickerAsync(DialogFileProperties? fileProperties = null);
        public Task<IStorageFile?> SaveFilePickerAsync(SaveFileProperties? saveFileProperties = null);
        public Task ShowErrorAsync(string message);
        public Task ShowErrorAsync(Exception exception);
        public Task ShowInfoAsync(string message);
        public Task ShowWarningAsync(string message);
        public Task ShowDialogAsync(object data);
    }
}
