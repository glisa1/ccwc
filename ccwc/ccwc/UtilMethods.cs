using System.Text;

namespace ccwc;

internal sealed class UtilMethods
{
    private string? FileName { get; init; }
    private string? FileContent { get; init; }

    public UtilMethods(string? fileName = null, string? fileContent = null)
    {
        if (fileName is null && fileContent is null)
            throw new ArgumentException("File name or file content must be specified");

        FileName = fileName;
        FileContent = fileContent;
    }

    public async Task<int> GetByteCount()
    {
        if (FileName is not null)
            return await GetByteCountFromFile();
        if (FileContent is not null)
            return await Task.Run(() => GetByteCountFromString());

        throw new Exception("Could not calculate bytes.");
    }

    public async Task<int> GetLineCount()
    {
        if (FileName is not null)
            return await GetLineCountFromFile();
        if (FileContent is not null)
            return await Task.Run(() => GetLineCountFromString());

        throw new Exception("Could not calculate lines.");
    }

    public async Task<int> GetWordCount()
    {
        if (FileName is not null)
            return await GetWordCountFromFile();
        if (FileContent is not null)
            return await Task.Run(() => GetWordCountFromString());

        throw new Exception("Could not calculate lines.");
    }

    public async Task<int> GetCharacterCount()
    {
        if (FileName is not null)
            return await GetCharacterCountFromFile();
        if (FileContent is not null)
            return await Task.Run(() => GetCharacterCountFromString());

        throw new Exception("Could not calculate lines.");
    }

    private async Task<int> GetByteCountFromFile()
    {
        if (!File.Exists(FileName))
            throw new FileNotFoundException();

        var bytes = await File.ReadAllBytesAsync(FileName);
        return bytes.Length;
    }

    private int GetByteCountFromString()
    {
        if (FileContent is null)
            throw new ArgumentNullException(nameof(FileContent));

        var bytes = Encoding.UTF8.GetBytes(FileContent);
        return bytes.Length;
    }

    private async Task<int> GetLineCountFromFile()
    {
        if (!File.Exists(FileName))
            throw new FileNotFoundException();

        var lines = await File.ReadAllLinesAsync(FileName);
        return lines.Length;
    }

    private int GetLineCountFromString()
    {
        if (FileContent is null)
            throw new ArgumentNullException(nameof(FileContent));
        var lines = FileContent.Split('\n');
        return lines.Length;
    }

    public async Task<int> GetWordCountFromFile()
    {
        if (!File.Exists(FileName))
            throw new FileNotFoundException();

        var text = await File.ReadAllTextAsync(FileName);
        var words = text.Split([' ', '\r', '\n', '\t'], StringSplitOptions.RemoveEmptyEntries);
        return words.Length;
    }
    public int GetWordCountFromString()
    {
        if (FileContent is null)
            throw new ArgumentNullException(nameof(FileContent));
        var words = FileContent.Split([' ', '\r', '\n', '\t'], StringSplitOptions.RemoveEmptyEntries);
        return words.Length;
    }

    public async Task<int> GetCharacterCountFromFile()
    {
        if (!File.Exists(FileName))
            throw new FileNotFoundException();

        var text = await File.ReadAllTextAsync(FileName);
        var chars = text.ToCharArray();
        return chars.Length;
    }

    public int GetCharacterCountFromString()
    {
        if (FileContent is null)
            throw new ArgumentNullException(nameof(FileContent));
        var chars = FileContent.ToCharArray();
        return chars.Length;
    }
}
