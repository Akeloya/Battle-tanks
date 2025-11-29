using ReactiveUI;

namespace BattleTanks.Game.ViewModels.Menu
{
    public class MenuViewModel(string header, string icon, IReactiveCommand menuItemCommand)
    {
        public MenuViewModel() : this("test", "", ReactiveCommand.Create(() => { }))
        {

        }
        public string Header { get; } = header;
        public string Icon { get; } = icon;
        public IReactiveCommand MenuItemCommand { get; } = menuItemCommand;
        public double ButtonSize { get; set; }
    }    
}
