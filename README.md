### Для вызова справки введите в терминале, в папке с *.csproj :
```powershell
>dotnet run -- --help

Description:
  Параметры командной строки

Usage:
  FilesSizes [options]

Options:
  stream, -q, --quite                        Используйте для записи в файл, параметры не требуются
  path <path>                                Путь к папке для обхода (по-умолчанию текущая папка вызова программы)
                                             [default: ./]
  streamOutput, -o, --output <streamOutput>  Путь к тестовому файлу, куда записать результаты выполнения расчёта
                                             (по-умолчанию файл sizes-YYYY-MM-DD.txt в текущей папке вызова программы)
                                             [default: sizes-yyyy-MM-dd.txt]
  humanread                                  Признак формирования размеров файлов в человекочитаемой форме (размеры до 1Кб
                                             указывать в байтах, размеры до 1Мб в килобайтах с 2 знаками после запятой,
                                             размеры до 1Гб в мегабайтах с 2 знаками после запятой, размеры до 1Тб - в Гб с
                                             2 знаками после запятой)
  --version                                  Show version information
  -?, -h, --help                             Show help and usage information
```  
### Входными параметрами по-условию являются:  
* -q, --quite (дополнительный аргумент не требуется) 
* -p, --path (-p используется системой как -p|--project, потому исключен из параметров.  
дополнительный аргумент - строка, по-умолчанию каталог извлечения)
* -o, --output (дополнительный аргумент - строка, по умолчанию текстовый файл в каталоге извлечения "sizes-yyyy-MM-dd.txt")  
* -h, --humanread (-h используется системой как -h|--help, исключён аналогично -p,  
допольнительный аргумент не требуется)  

### При отсутствии параметров, приложения будет запущено со значениями по-умолчанию :  
* --quite - false  
* --path - "./"  
* --output - "sizes-yyyy-MM-dd.txt"  
* --humanread - false

### Пример работы приложения  
```powershell
>dotnet run --humanread  
-C:\Users\karma\RiderProjects\FilesSizes\FilesSizes\  (972,30 KB)
-bin (692,20 KB)
--Debug (692,20 KB)
---net6.0 (692,20 KB)
----FilesSizes.deps.json (3,30 KB)
----FilesSizes.dll (13,5 KB)
----FilesSizes.exe (146 KB)
----FilesSizes.pdb (11,90 KB)
----FilesSizes.runtimeconfig.json (147 bytes)
----System.CommandLine.dll (216,39 KB)
----System.CommandLine.NamingConventionBinder.dll (49,89 KB)
----cs (18,89 KB)
-----System.CommandLine.resources.dll (18,89 KB)
----de (18,89 KB)
-----System.CommandLine.resources.dll (18,89 KB)
----es (18,89 KB)
-----System.CommandLine.resources.dll (18,89 KB)
----fr (18,89 KB)
-----System.CommandLine.resources.dll (18,89 KB)
----it (18,89 KB)
-----System.CommandLine.resources.dll (18,89 KB)
----ja (18,89 KB)
-----System.CommandLine.resources.dll (18,89 KB)
----ko (18,89 KB)
-----System.CommandLine.resources.dll (18,89 KB)
----pl (18,89 KB)
-----System.CommandLine.resources.dll (18,89 KB)
----pt-BR (18,89 KB)
-----System.CommandLine.resources.dll (18,89 KB)
----ref (6,5 KB)
-----FilesSizes.dll (6,5 KB)
----ru (18,89 KB)
-----System.CommandLine.resources.dll (18,89 KB)
----tr (17,88 KB)
-----System.CommandLine.resources.dll (17,88 KB)
----zh-Hans (18,89 KB)
-----System.CommandLine.resources.dll (18,89 KB)
----zh-Hant (18,89 KB)
-----System.CommandLine.resources.dll (18,89 KB)
-obj (273,73 KB)
--FilesSizes.csproj.nuget.dgspec.json (2,18 KB)
--FilesSizes.csproj.nuget.g.props (1,11 KB)
--FilesSizes.csproj.nuget.g.targets (150 bytes)
--project.assets.json (7,34 KB)
--project.nuget.cache (618 bytes)
--project.packagespec.json (1,03 KB)
--rider.project.restore.info (20 bytes)
--Debug (261,30 KB)
---net6.0 (261,30 KB)
----.NETCoreApp,Version=v6.0.AssemblyAttributes.cs (190 bytes)
----apphost.exe (146 KB)
----FilesSizes.AssemblyInfo.cs (963 bytes)
----FilesSizes.AssemblyInfoInputs.cache (42 bytes)
----FilesSizes.assets.cache (4,81 KB)
----FilesSizes.csproj.AssemblyReference.cache (73,56 KB)
----FilesSizes.csproj.CopyComplete (0 bytes)
----FilesSizes.csproj.CoreCompileInputs.cache (42 bytes)
----FilesSizes.csproj.FileListAbsolute.txt (3,04 KB)
----FilesSizes.dll (13,5 KB)
----FilesSizes.GeneratedMSBuildEditorConfig.editorconfig (452 bytes)
----FilesSizes.genruntimeconfig.cache (42 bytes)
----FilesSizes.GlobalUsings.g.cs (295 bytes)
----FilesSizes.pdb (11,90 KB)
----ref (6,5 KB)
-----FilesSizes.dll (6,5 KB)
-FilesSizes.csproj (416 bytes)
-ParamsHandler.cs (2,50 KB)
-Program.cs (48 bytes)
-TreeView.cs (3,42 KB)
```

### Пример работы приложения с записью в файл  
```powershell
>dotnet run --quite --path "C:\Games" --output "../sizes-test.txt" --humanread
```
Результат выполнения программы можно наблюдать в репозитории на главной странице или [по ссылке](https://github.com/The-Katsu/FilesSizes/blob/main/sizes-test.txt).