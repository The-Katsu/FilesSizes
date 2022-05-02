using System.Text;

namespace FilesSizes;

internal static class TreeView
{
    private const char RootPrefix = '-';
    private static string _rootPath; 
    private static readonly string[] suffixes =  
        { "bytes", "KB", "MB", "GB", "TB"};
    
    internal static void Write(bool stream, string path, string streamOutput, bool humanread)
    {
        if (!Directory.Exists(path))
        {
            Console.WriteLine($"Директории - {path} не существует, используем текующую директорию запуска программы.");
            path = "./";
        }
        var view = new StringBuilder();
        var dir = new DirectoryInfo(path);

        _rootPath = dir.FullName;

        view.Append($"{RootPrefix}{_rootPath} ");
        if (humanread) view.Append(HumanReadForm(CalculateFolderSize(dir)));
        else view.Append($"({CalculateFolderSize(dir)} bytes)");
        
        GetSubfoldersTree(dir, view, humanread);
        GetFilesTree(dir, view, humanread);

        if (!stream)
            Console.WriteLine(view);
        else
        {
            if (!File.Exists(streamOutput))
            {
                Console.WriteLine($"Файла по указанному пути не существует - {streamOutput}, сохраняем в текующую директории.");
                using var sw = new StreamWriter($"sizes-{DateTime.Now:yyyy-MM-dd}.txt");
                sw.Write(view.ToString());
            }
            else
            {
                using var sw = new StreamWriter(streamOutput);
                sw.Write(view.ToString());
            }
        }
    }
    
    private static void GetSubfoldersTree(DirectoryInfo dir, StringBuilder view, bool humanread)
    {
        foreach (var folder in dir.GetDirectories())
        {
            var count = folder.FullName
                .Replace(_rootPath, "")
                .Count(c => c == '\\') + 1;

            view.Append('\n')
                .Append(RootPrefix, count)
                .Append(folder.Name);

            if (humanread) view.Append(HumanReadForm(CalculateFolderSize(folder)));
            else view.Append($" ({CalculateFolderSize(folder)} bytes)");
            
            GetFilesTree(folder, view, humanread);
            
            GetSubfoldersTree(folder, view, humanread);
        }
    }

    private static void GetFilesTree(DirectoryInfo folder, StringBuilder view, bool humanread)
    {
        foreach (var file in folder.GetFiles())
        {
            var count = file.FullName
                .Replace(_rootPath, "")
                .Count(c => c == '\\') + 1;

            view.Append('\n')
                .Append(RootPrefix, count)
                .Append(file.Name);

            if (humanread) view.Append(HumanReadForm(file.Length));
            else view.Append($" ({file.Length} bytes)");
        }
    }
    
    private static long CalculateFolderSize(DirectoryInfo dir)
        => dir.EnumerateFiles("*", SearchOption.AllDirectories).Sum(file => file.Length);

    private static string HumanReadForm(long bytes)
    {
        var counter = 0;
        var number = (decimal) bytes;
        while (number / 1024 >= 1)  
        {  
            number = number / 1024;  
            counter++;  
        }

        return $" ({Math.Round(number, 2)} {suffixes[counter]})";
    }
}