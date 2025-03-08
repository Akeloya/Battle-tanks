using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Platform;

using BattleTanks.Editor.Views;

using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleTanks.Editor.Core.Services.Windows
{
    public class WindowManager : IDisposable
    {
        private Window _current;
        private readonly List<Window> _openedWindows = [];

        public Window Current => _current;
        public void Dispose()
        {
            foreach (var wnd in _openedWindows)
            {
                wnd.GotFocus -= WndClosed;
                wnd.Closed -= WndClosed;
            }
        }

        public Window RegisterMainWindow()
        {
            //TODO: нужно сделать, тогда у диалога будет нормальный провайдер
            return new MainWindow();
        }
        public Window Create()
        {
            var wnd = new Window();
            wnd.Icon = new WindowIcon(new Avalonia.Media.Imaging.Bitmap(AssetLoader.Open(new Uri("avares://BattleTanks.Editor/Assets/appIcon.ico"))));
            wnd.Closed += WndClosed;
            wnd.GotFocus += WndGotFocus;
            wnd.Opened += WndOpened;
            wnd.DataContextChanged += Wnd_DataContextChanged;
            if(_current == null && !_openedWindows.Any())
            {
                _current = wnd;
            }
            return wnd;
        }

        private void Wnd_DataContextChanged(object? sender, EventArgs e)
        {
            var wnd = sender as Window;
            if(wnd == null)
                return;
            var locator = new ViewLocator();
            if(locator.Match(wnd.DataContext))
                wnd.Content = locator.Build(wnd.DataContext);
        }

        private void WndOpened(object sender, EventArgs e)
        {
            lock(_openedWindows)
                _openedWindows.Add((Window)sender);
        }

        private void WndGotFocus(object sender, GotFocusEventArgs e)
        {
            _current = (Window)sender;
        }

        private void WndClosed(object sender, EventArgs e)
        {
            var wnd = (Window)sender;
            lock(_openedWindows)
                _openedWindows.Remove(wnd);
        }
    }
}
