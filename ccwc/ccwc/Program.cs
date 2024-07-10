using ccwc;

if (args.Length == 0)
    return;

if (args.Length == 1)
{
    var inputFile = args[0];
    var fileMethods = new FileMethods(inputFile);
    var bytesCount = await fileMethods.GetBytesCount();
    var linesCount = await fileMethods.GetLinesCount();
    var wordsCount = await fileMethods.GetWordsCount();

    Console.WriteLine($"{linesCount} {wordsCount} {bytesCount} {inputFile}");

}
else if (args.Length == 2)
{
    var inputFile = args[1];
    var fileMethods = new FileMethods(inputFile);

    if (args[0] == "-c")
    {
        var bytesCount = await fileMethods.GetBytesCount();
        Console.WriteLine($"{bytesCount} {inputFile}");
    }

    else if (args[0] == "-l")
    {
        var linesCount = await fileMethods.GetLinesCount();
        Console.WriteLine($"{linesCount} {inputFile}");
    }

    else if (args[0] == "-w")
    {
        var wordsCount = await fileMethods.GetWordsCount();
        Console.WriteLine($"{wordsCount} {inputFile}");
    }

    else if (args[0] == "-m")
    {
        var charactersCount = await fileMethods.GetCharactersCount();
        Console.WriteLine($"{charactersCount} {inputFile}");
    }

    else
        Console.WriteLine("Command not supported.");
}