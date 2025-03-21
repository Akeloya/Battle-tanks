﻿using Avalonia.Controls;
using Avalonia.Controls.Templates;

using BattleTanks.Game.ViewModels;

using System;

namespace BattleTanks.Game.Core.Services.Windows
{
    public class ViewLocator : IDataTemplate
    {
        public Control Build(object? data)
        {
            var name = data?.GetType()?.FullName?.Replace("ViewModel", "View");
            if (string.IsNullOrEmpty(name))
                return new TextBlock { Text = "Not Found: " + name };
            var type = Type.GetType(name);

            if (type != null)
            {
                if (Activator.CreateInstance(type) is Control inst)
                {
                    inst.DataContext = data;
                    return inst;
                }
            }
            return new TextBlock { Text = "Not Found: " + name };
        }

        public bool Match(object? data)
        {
            return data is ViewModelBase;
        }
    }
}
