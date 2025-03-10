namespace BattleTanks.Core.Storage
{
    public class PathConfigurations
    {
        public const string AppFolderName = "BattleTanks";
        public static string GetAppDirectory()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), AppFolderName);
            if(!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return path;
        }

        public static string GetDirectory(params string[] paths)
        {
            var path = GetAppDirectory();
            foreach(var p in paths)
                path = Path.Combine(path, p);

            if(!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return path;
        }
    }
}
