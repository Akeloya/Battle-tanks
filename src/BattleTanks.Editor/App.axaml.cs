using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Platform.Storage;

using BattleTanks.Editor.Core.Services;
using BattleTanks.Editor.Core.Services.Dialogs;
using BattleTanks.Editor.ViewModels;
using BattleTanks.Editor.Views;

using Microsoft.Extensions.DependencyInjection;

namespace BattleTanks.Editor;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        IStorageProvider? storageProvider = null;
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainViewModel()
            };

            storageProvider = desktop.MainWindow.StorageProvider;
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = new MainViewModel()
            };
            storageProvider = TopLevel.GetTopLevel(singleViewPlatform.MainView)!.StorageProvider;
        }

        base.OnFrameworkInitializationCompleted();

        ServicesLocator.RegisterServices(collection =>
        {
            if(storageProvider != null)
                collection.AddSingleton<IDialogService>(new DialogService(storageProvider));
        });
    }
}
