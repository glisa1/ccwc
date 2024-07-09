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