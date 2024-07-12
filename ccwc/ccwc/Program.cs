using ccwc;
using ccwc.Config;
using CommandLine;
using System.Text;

internal class Program
{
    private static async Task Main(string[] args)
    {
        if (Console.IsInputRedirected)
        {
            await Parser.Default.ParseArguments<CommandArgumensConfig>(args)
                .WithParsedAsync(RunWithParsedArgumentsAsync);
        }
        else
        {
            await Parser.Default.ParseArguments<CommandArgumensWithValueConfig>(args)
                .WithParsedAsync(RunWithParsedArgumentsAndValues);
        }
    }

    private static async Task RunWithParsedArgumentsAsync(CommandArgumensConfig opts)
    {
        var fileContent = await Console.In.ReadToEndAsync();

        if (string.IsNullOrEmpty(fileContent))
        {
            Console.Error.WriteLine("Input was empty.");
            return;
        }

        var methods = new UtilMethods(fileContent: fileContent);
        var opts1 = new CommandArgumensWithValueConfig
        {
            BytesCount = opts.BytesCount,
            CharactersCount = opts.CharactersCount,
            LinesCount = opts.LinesCount,
            WordsCount = opts.WordsCount,
        };

        await PrintOutputAsync(methods, opts1);
    }

    private static async Task RunWithParsedArgumentsAndValues(CommandArgumensWithValueConfig opts)
    {
        var methods = new UtilMethods(opts.FileName);
        await PrintOutputAsync(methods, opts);
    }

    private static async Task PrintOutputAsync(UtilMethods utilMethods, CommandArgumensWithValueConfig opts)
    {
        var fileName = opts.FileName ?? string.Empty;
        if (opts.NoOptionsParsed())
        {
            var byteCount = await utilMethods.GetByteCount();
            var lineCount = await utilMethods.GetLineCount();
            var wordCount = await utilMethods.GetWordCount();

            Console.WriteLine($"{lineCount} {wordCount} {byteCount} {fileName}");
            return;
        }

        var stringBuilder = new StringBuilder();

        if (opts.LinesCount)
        {
            var lineCount = await utilMethods.GetLineCount();
            stringBuilder.Append($"{lineCount} ");
        }

        if (opts.WordsCount)
        {
            var wordCount = await utilMethods.GetWordCount();
            stringBuilder.Append($"{wordCount} ");
        }

        if (opts.BytesCount)
        {
            var byteCount = await utilMethods.GetByteCount();
            stringBuilder.Append($"{byteCount} ");
        }

        if (opts.CharactersCount)
        {
            var charactersCount = await utilMethods.GetCharacterCount();
            stringBuilder.Append($"{charactersCount} ");
        }

        Console.WriteLine(stringBuilder.Append(fileName).ToString());
    }
}