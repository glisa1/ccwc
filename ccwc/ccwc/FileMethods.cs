namespace ccwc;

internal sealed class FileMethods
{
    private string FileName { get; init; }

    public FileMethods(string fileName)
    {
        if (!File.Exists(fileName))
            throw new FileNotFoundException();

        FileName = fileName;
    }

    public async Task<int> GetBytesCount()
    {
        var bytes = await File.ReadAllBytesAsync(FileName);
        return bytes.Length;
    }

    public async Task<int> GetLinesCount()
    {
        var lines = await File.ReadAllLinesAsync(FileName);
        return lines.Length;
    }

    public async Task<int> GetWordsCount()
    {
        var text = await File.ReadAllTextAsync(FileName);
        var words = text.Split([' ', '\r', '\n', '\t'], StringSplitOptions.RemoveEmptyEntries);
        return words.Length;
    }

    public async Task<int> GetCharactersCount()
    {
        var text = await File.ReadAllTextAsync(FileName);
        var chars = text.ToCharArray();
        return chars.Length;
    }
}
