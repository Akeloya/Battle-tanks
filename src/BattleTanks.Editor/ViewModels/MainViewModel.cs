using System;
using Avalonia.Platform.Storage;

using BattleTanks.Core.Store;

using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using BattleTanks.Core.Interfaces;

namespace BattleTanks.Editor.ViewModels;

public class MainViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";

    public ObservableCollection<CardDefinitinon> TankItemsSource { get; } = new();
    public async Task Open()
    {
        try
        {
            var files = await DialogService.OpenFilePickerAsync(fileTypeChoices: [FilePickerFileTypes.TextPlain, FilePickerFileTypes.All]);
            var file = files.First();
            using var fs = await file.OpenReadAsync();
            using var streamReader = new StreamReader(fs);
            string? line;
            line = await streamReader.ReadLineAsync();//header
            line = await streamReader.ReadLineAsync();
            while(!string.IsNullOrWhiteSpace(line))
            {
                var values = line.Split(';');

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
                    AbilitesValues = new System.Collections.Generic.List<CardDefinitinon.Ability>()
                });
                line = await streamReader.ReadLineAsync();
            }
        }
        catch(Exception ex)
        {
            await DialogService.ShowErrorAsync(ex);
        }
    }
}
