using System.CommandLine;
using System.CommandLine.NamingConventionBinder;

namespace FilesSizes;

internal static class ParamsHandler
{
    internal static async Task<int> Execute(string[] args)
    {
        var streamOption = new Option(new[] {"-q", "--quite"},
                "Признак вывода сообщений в стандартный поток вывода (если указана, " +
                "то не выводить лог в консоль. Только в файл)")
            {IsRequired = false, Arity = ArgumentArity.Zero, Name = "stream"};
        var pathOption = new Option<string>(new[] {"-p", "--path"},
                "Путь к папке для обхода (по-умолчанию текущая папка вызова программы)")
            {IsRequired = false, Arity = ArgumentArity.ExactlyOne, Name = "path"};
        var streamOutputOption = new Option<string>(new[] {"-o", "--output"},
                "Путь к тестовому файлу, куда записать результаты выполнения расчёта " +
                "(по-умолчанию файл sizes-YYYY-MM-DD.txt в текущей папке вызова программы)")
            {IsRequired = false, Arity = ArgumentArity.ExactlyOne, Name = "streamOutput"};
        var humanreadOption = new Option(new[] {"-h", "--humanread"},
                "Признак формирования размеров файлов в человекочитаемой форме " +
                "(размеры до 1Кб указывать в байтах, размеры до 1Мб в килобайтах с 2 знаками после запятой, " +
                "размеры до 1Гб в мегабайтах с 2 знаками после запятой, размеры до 1Тб - в Гб с 2 знаками после запятой)")
            {IsRequired = false, Arity = ArgumentArity.Zero, Name = "humanread"};

        var rootCommand = new RootCommand("Параметры командной строки")
        {
            streamOption,
            pathOption,
            streamOutputOption,
            humanreadOption
        };

        rootCommand.Handler = CommandHandler.Create((bool stream, string path, string streamOutput, bool humanread)
            => ShowParams(stream, path, streamOutput, humanread));
        
        return await rootCommand.InvokeAsync(args);
    }

    private static void ShowParams(bool stream, string path, string streamOutput, bool humanread)
    {
        Console.WriteLine(stream);
        if (path is not null)
            Console.WriteLine(path);
        if (streamOutput is not null)
            Console.WriteLine(streamOutput);
        Console.WriteLine(humanread);
    }
}