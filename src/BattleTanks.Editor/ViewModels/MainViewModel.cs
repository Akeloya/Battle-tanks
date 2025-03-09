using System;
using Avalonia.Platform.Storage;
using System.Collections.Generic;
using BattleTanks.Core.Store;

using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.IO;
using BattleTanks.Core.Interfaces;
using System.Linq;

namespace BattleTanks.Editor.ViewModels;

public class MainViewModel : ViewModelBase
{
    public ObservableCollection<CardDefinitinon> TankItemsSource { get; } = [];
    public async Task Open()
    {
        try
        {
            var files = await DialogService.OpenFilePickerAsync(fileTypeChoices: [FilePickerFileTypes.TextPlain, FilePickerFileTypes.All]);
            if(!files.Any())
                return;
            var file = files[0];
            using var fs = await file.OpenReadAsync();
            using var streamReader = new StreamReader(fs);
            string? line;
            line = await streamReader.ReadLineAsync();//header
            line = await streamReader.ReadLineAsync();
            while(!string.IsNullOrWhiteSpace(line))
            {
                var values = line.Split(';');
                var abilities = new List<Ability>();
                for(var i = 0; i <= 2; i+=2)
                { 
                    var index = 8 + i;
                    if(!string.IsNullOrEmpty(values[index]))
                    {
                        var ab = new Ability()
                        {
                            Name = values[index],
                        };
                        if(int.TryParse(values[index + 1], out var val))
                            ab.Value = val;

                        abilities.Add(ab);
                    }
                    else
                        break;
                }

                TankItemsSource.Add(new CardDefinitinon
                {
                    Name = values[0],
                    Type = Enum.Parse<CardType>(values[1]),
                    Nation = values[2],
                    Attack = int.Parse(values[3]),
                    Defence = int.Parse(values[4]),
                    Cost = int.Parse(values[5]),
                    Resource = short.Parse(values[6]),
                    ResourceNation = values[7],
                    AbilitesValues = abilities
                });
                line = await streamReader.ReadLineAsync();
            }
        }
        catch(Exception ex)
        {
            await DialogService.ShowErrorAsync(ex);
        }
    }

    public async Task ShowTestError()
    {
        await DialogService.ShowErrorAsync("test");
    }
}
