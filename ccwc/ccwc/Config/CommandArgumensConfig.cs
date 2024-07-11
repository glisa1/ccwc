using CommandLine;

namespace ccwc.Config;

internal class CommandArgumensConfig
{
    [Option('c', "bytes", Required = false, HelpText = "Print number of bytes.")]
    public bool BytesCount { get; set; }

    [Option('l', "lines", Required = false, HelpText = "Print number of lines.")]
    public bool LinesCount { get; set; }

    [Option('w', "words", Required = false, HelpText = "Print number of words.")]
    public bool WordsCount { get; set; }

    [Option('m', "characters", Required = false, HelpText = "Print number of characters.")]
    public bool CharactersCount { get; set; }
}

internal class CommandArgumensWithValueConfig : CommandArgumensConfig
{
    [Value(0, HelpText = "Name of file to process.", MetaName = "File name.", Required = true)]
    public string? FileName { get; set; }
}
