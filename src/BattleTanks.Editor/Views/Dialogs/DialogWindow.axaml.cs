using Avalonia.Controls;

using BattleTanks.Editor.Core.Services.Dialogs;

namespace BattleTanks.Editor.Views.Dialogs;

public partial class DialogWindow : Window
{
    public DialogWindow()
    {
        InitializeComponent();
        DataContextChanged += DialogWindow_DataContextChanged;
    }

    private void DialogWindow_DataContextChanged(object? sender, System.EventArgs e)
    {
        if(DataContext is IDialogWindow wnd)
            wnd.OnClose += Wnd_OnClose;
    }

    private void Wnd_OnClose(object? sender, System.EventArgs e)
    {
        Close();
    }
}