using ccwc;

if (args.Length < 2)
    return;

var inputFile = args[1] ?? throw new ArgumentException("File not provided as a parameter.");

var fileMethods = new FileMethods(inputFile);

if (args[0] == "-c")
{
    var bytesCount = await fileMethods.GetBytesCount();
    Console.WriteLine($"{bytesCount} {inputFile}");
}

if (args[0] == "-l")
{
    var linesCount = await fileMethods.GetLinesCount();
    Console.WriteLine($"{linesCount} {inputFile}");
}

if (args[0] == "-w")
{
    var wordsCount = await fileMethods.GetWordsCount();
    Console.WriteLine($"{wordsCount} {inputFile}");
}

if (args[0] == "-m")
{
    var charactersCount = await fileMethods.GetCharactersCount();
    Console.WriteLine($"{charactersCount} {inputFile}");
}