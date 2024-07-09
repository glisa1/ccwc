if (args.Length < 2)
    return;

var inputFile = args[1] ?? throw new ArgumentException("File not provided as a parameter.");

if (args[0] == "-c")
{
    var bytes = await File.ReadAllBytesAsync(inputFile) ?? throw new Exception("File not found");
    Console.WriteLine($"{bytes.Length} {inputFile}");
}

if (args[0] == "-l")
{
    var lines = await File.ReadAllLinesAsync(inputFile) ?? throw new Exception("File not found");
    Console.WriteLine($"{lines.Length} {inputFile}");
}

if ( args[0] == "-w")
{
    var text = await File.ReadAllTextAsync(inputFile) ?? throw new Exception("File not found");
    var words = text.Split([' ', '\r', '\n', '\t'], StringSplitOptions.RemoveEmptyEntries);
    Console.WriteLine($"{words.Length} {inputFile}");
}