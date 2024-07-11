using System.Text;

namespace ccwc;

internal sealed class UtilMethods
{
    public async Task<int> GetBytesCountFromFile(string fileName)
    {
        if (!File.Exists(fileName))
            throw new FileNotFoundException();

        var bytes = await File.ReadAllBytesAsync(fileName);
        return bytes.Length;
    }

    public async Task<int> GetLinesCountFromFile(string fileName)
    {
        if (!File.Exists(fileName))
            throw new FileNotFoundException();

        var lines = await File.ReadAllLinesAsync(fileName);
        return lines.Length;
    }

    public async Task<int> GetWordsCountFromFile(string fileName)
    {
        if (!File.Exists(fileName))
            throw new FileNotFoundException();

        var text = await File.ReadAllTextAsync(fileName);
        var words = text.Split([' ', '\r', '\n', '\t'], StringSplitOptions.RemoveEmptyEntries);
        return words.Length;
    }

    public async Task<int> GetCharactersCountFromFile(string fileName)
    {
        if (!File.Exists(fileName))
            throw new FileNotFoundException();

        var text = await File.ReadAllTextAsync(fileName);
        var chars = text.ToCharArray();
        return chars.Length;
    }

    public int GetBytesCountFromString(string input)
    {
        var bytes = Encoding.UTF8.GetBytes(input);
        return bytes.Length;
    }

    public int GetLinesCountFromString(string input)
    {
        var lines = input.Split('\n');
        return lines.Length;
    }

    public int GetWordsCountFromString(string input)
    {
        var words = input.Split([' ', '\r', '\n', '\t'], StringSplitOptions.RemoveEmptyEntries);
        return words.Length;
    }

    public int GetCharactersCountFromString(string input)
    {
        var chars = input.ToCharArray();
        return chars.Length;
    }
}
