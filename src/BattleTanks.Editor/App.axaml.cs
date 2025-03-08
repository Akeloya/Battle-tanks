using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

using BattleTanks.Editor.Core.Services;
using BattleTanks.Editor.Core.Services.Dialogs;
using BattleTanks.Editor.Core.Services.Windows;
using BattleTanks.Editor.ViewModels;
using BattleTanks.Editor.Views;

using Microsoft.Extensions.DependencyInjection;

using ReactiveUI;

namespace BattleTanks.Editor;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }
    
    public override void OnFrameworkInitializationCompleted()
    {
        RegisterAppServices();
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow!.DataContext = ServicesLocator.Get<MainViewModel>();
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView!.DataContext = ServicesLocator.Get<MainViewModel>();
        }

        base.OnFrameworkInitializationCompleted();
    }
    private void RegisterAppServices()
    {
        ServicesLocator.RegisterServices(collection =>
        {
            var wndSrv = new WindowManager();
            collection.AddSingleton(wndSrv);

            if (Design.IsDesignMode)
            {
                collection.AddSingleton(wndSrv.Create().StorageProvider);
            }

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = wndSrv.Create();
                collection.AddSingleton(desktop.MainWindow.StorageProvider);
                
            }
            else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
            {
                singleViewPlatform.MainView = new MainView();
                collection.AddSingleton(TopLevel.GetTopLevel(singleViewPlatform.MainView)!.StorageProvider);
            }
            collection.AddSingleton<IDialogService, DialogService>();
            collection.AddTransient<MainViewModel>();
        });
    }
}
