using System.Text;

namespace FilesSizes;

internal static class TreeView
{
    private const char RootPrefix = '-';
    private static string _rootPath; 
    
    internal static void Print(string path)
    {
        var view = new StringBuilder();
        var dir = new DirectoryInfo(path);

        _rootPath = dir.FullName;

        view.Append($"{RootPrefix}{_rootPath} ({CalculateFolderSize(dir)} bytes)");
        
        GetSubfoldersTree(dir, view);
        GetFilesTree(dir, view);
        
        Console.WriteLine(view);
    }
    
    private static void GetSubfoldersTree(DirectoryInfo dir, StringBuilder view)
    {
        foreach (var folder in dir.GetDirectories())
        {
            var count = folder.FullName
                .Replace(_rootPath, "")
                .Count(c => c == '\\') + 1;

            view.Append('\n')
                .Append(RootPrefix, count)
                .Append(folder.Name)
                .Append($" ({CalculateFolderSize(folder)} bytes)");
            
            GetFilesTree(folder, view);
            
            GetSubfoldersTree(folder, view);
        }
    }

    private static void GetFilesTree(DirectoryInfo folder, StringBuilder view)
    {
        foreach (var file in folder.GetFiles())
        {
            var count = file.FullName
                .Replace(_rootPath, "")
                .Count(c => c == '\\') + 1;

            view.Append('\n')
                .Append(RootPrefix, count)
                .Append(file.Name)
                .Append($" ({file.Length} bytes)");
        }
    }
    
    private static float CalculateFolderSize(DirectoryInfo dir)
        => dir.EnumerateFiles("*", SearchOption.AllDirectories).Sum(file => file.Length);
}