using ccwc;

if (!Console.IsInputRedirected && args.Length == 0)
    return;

var fileContent = string.Empty;
var fileName = string.Empty;
var operation = string.Empty;

if (Console.IsInputRedirected)
{
    fileContent = await Console.In.ReadToEndAsync();

    Console.WriteLine($"InputRedirected length: {fileContent.Length}");

    if (string.IsNullOrEmpty(fileContent))
    {
        Console.Error.WriteLine("Input was empty.");
        return;
    }

    if (args.Length > 0)
    {
        operation = args[0];
    }
}
else if (args.Length == 1)
{
    fileName = args[0];
}
else if (args.Length == 2)
{
    operation = args[0];
    fileName = args[1];
}
else
{
    Console.Error.WriteLine("Invalid number of parameters.");
    return;
}

var utilMethods = new UtilMethods();

if (Console.IsInputRedirected)
{
    if (args.Length == 0)
    {
        var bytesCount = utilMethods.GetBytesCountFromString(fileContent);
        var linesCount = utilMethods.GetLinesCountFromString(fileContent);
        var wordsCount = utilMethods.GetWordsCountFromString(fileContent);

        Console.WriteLine($"{linesCount} {wordsCount} {bytesCount}");
        return;
    }
    else if (args.Length == 1)
    {
        if (operation == "-c")
        {
            var bytesCount = utilMethods.GetBytesCountFromString(fileContent);
            Console.WriteLine($"{bytesCount}");
            return;
        }

        else if (operation == "-l")
        {
            var linesCount = utilMethods.GetLinesCountFromString(fileContent);
            Console.WriteLine($"{linesCount}");
            return;
        }

        else if (operation == "-w")
        {
            var wordsCount = utilMethods.GetWordsCountFromString(fileContent);
            Console.WriteLine($"{wordsCount}");
            return;
        }

        else if (operation == "-m")
        {
            var charactersCount = utilMethods.GetCharactersCountFromString(fileContent);
            Console.WriteLine($"{charactersCount}");
            return;
        }

        else
        {
            Console.Error.WriteLine("Command not supported.");
            return;
        }
    }
}
else
{
    if (args.Length == 1)
    {
        var bytesCount = await utilMethods.GetBytesCountFromFile(fileName);
        var linesCount = await utilMethods.GetLinesCountFromFile(fileName);
        var wordsCount = await utilMethods.GetWordsCountFromFile(fileName);

        Console.WriteLine($"{linesCount} {wordsCount} {bytesCount} {fileName}");
        return;
    }
    else if (args.Length == 2)
    {
        if (args[0] == "-c")
        {
            var bytesCount = await utilMethods.GetBytesCountFromFile(fileName);
            Console.WriteLine($"{bytesCount} {fileName}");
            return;
        }
        else if (args[0] == "-l")
        {
            var linesCount = await utilMethods.GetLinesCountFromFile(fileName);
            Console.WriteLine($"{linesCount} {fileName}");
            return;
        }
        else if (args[0] == "-w")
        {
            var wordsCount = await utilMethods.GetWordsCountFromFile(fileName);
            Console.WriteLine($"{wordsCount} {fileName}");
            return;
        }
        else if (args[0] == "-m")
        {
            var charactersCount = await utilMethods.GetCharactersCountFromFile(fileName);
            Console.WriteLine($"{charactersCount} {fileName}");
            return;
        }
        else
        {
            Console.Error.WriteLine("Command not supported.");
            return;
        }
    }
}