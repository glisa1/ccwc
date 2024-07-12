using CommandLine;

namespace ccwc.Config;

internal class CommandArgumensConfig
{
    [Option('c', "bytes", Required = false, HelpText = "Print number of bytes.")]
    public bool BytesCount { get; init; }

    [Option('l', "lines", Required = false, HelpText = "Print number of lines.")]
    public bool LinesCount { get; init; }

    [Option('w', "words", Required = false, HelpText = "Print number of words.")]
    public bool WordsCount { get; init; }

    [Option('m', "characters", Required = false, HelpText = "Print number of characters.")]
    public bool CharactersCount { get; init; }

    public bool NoOptionsParsed() => !BytesCount && !LinesCount && !WordsCount && !CharactersCount;
}

internal class CommandArgumensWithValueConfig : CommandArgumensConfig
{
    [Value(0, HelpText = "Name of file to process.", MetaName = "File name.", Required = true)]
    public string? FileName { get; init; }
}
