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

            if (Design.IsDesignMode)
            {
                var wnd = new MainWindow();
                collection.AddSingleton<IDialogService>(new DialogService(wnd.StorageProvider, wnd.MainView.DialogHost));
            }

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var wnd = new MainWindow();
                desktop.MainWindow = wnd;
                collection.AddSingleton<IDialogService>(new DialogService(wnd.StorageProvider, wnd.MainView.DialogHost));
                
            }
            else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
            {
                var mv = new MainView();
                singleViewPlatform.MainView = mv;
                collection.AddSingleton<IDialogService>(new DialogService(TopLevel.GetTopLevel(mv)!.StorageProvider, mv.DialogHost));
            }
            
            collection.AddTransient<MainViewModel>();
        });
    }
}
