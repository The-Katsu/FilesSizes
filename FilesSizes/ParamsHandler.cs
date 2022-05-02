using System.CommandLine;
using System.CommandLine.NamingConventionBinder;

namespace FilesSizes;

internal static class ParamsHandler
{
    internal static async Task<int> Execute(string[] args)
    {
        var streamOption = new Option(new[] {"-q", "--quite"},
                "Используйте для записи в файл, параметры не требуются")
            {IsRequired = false, Arity = ArgumentArity.Zero, Name = "stream"};
        var pathOption = new Option<string>(new[] {"--path"},
                getDefaultValue: () => "./",
                "Путь к папке для обхода (по-умолчанию текущая папка вызова программы)")
            {IsRequired = false, Arity = ArgumentArity.ZeroOrOne, Name = "path"};
        var streamOutputOption = new Option<string>(new[] {"-o", "--output"},
                getDefaultValue: () => $"sizes-{DateTime.Now:yyyy-MM-dd}.txt",
                "Путь к тестовому файлу, куда записать результаты выполнения расчёта " +
                "(по-умолчанию файл sizes-YYYY-MM-DD.txt в текущей папке вызова программы)")
            {IsRequired = false, Arity = ArgumentArity.ZeroOrOne, Name = "streamOutput"};
        var humanreadOption = new Option(new[] {"--humanread"},
                "Признак формирования размеров файлов в человекочитаемой форме " +
                "(размеры до 1Кб указывать в байтах, " +
                "размеры до 1Мб в килобайтах с 2 знаками после запятой, " +
                "размеры до 1Гб в мегабайтах с 2 знаками после запятой, " +
                "размеры до 1Тб - в Гб с 2 знаками после запятой)")
            {IsRequired = false, Arity = ArgumentArity.Zero, Name = "humanread"};

        var rootCommand = new RootCommand("Параметры командной строки")
        {
            streamOption,
            pathOption,
            streamOutputOption,
            humanreadOption
        };

        rootCommand.Handler = CommandHandler.Create((bool stream, string path, string streamOutput, bool humanread)
            => TreeView.Write(stream, path, streamOutput, humanread));
        
        return await rootCommand.InvokeAsync(args);
    }
}