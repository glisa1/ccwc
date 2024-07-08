if (args.Length < 1)
    return;

if (args[0] == "-c")
{
    var inputFile = args[1] ?? throw new ArgumentException("File not provided as a parameter.");

    var bytes = await File.ReadAllBytesAsync(inputFile);

    if (bytes == null)
        throw new Exception("File not found");

    Console.WriteLine($"{bytes.Length} {inputFile}");
}