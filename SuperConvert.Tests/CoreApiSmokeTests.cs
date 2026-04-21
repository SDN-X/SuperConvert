using SuperConvert.Extensions;

namespace SuperConvert.Tests;

public class CoreApiSmokeTests
{
    [Fact]
    public void FileConverter_ToFile_WritesToProvidedDirectory()
    {
        var tempDirectory = Path.Combine(Path.GetTempPath(), $"sc-{Guid.NewGuid():N}");
        var fileName = "sample.txt";
        var sourceText = "superconvert-file-test";
        var base64 = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(sourceText));

        try
        {
            FileConverter.ToFile(base64, fileName, tempDirectory);
            var fullPath = Path.Combine(tempDirectory, fileName);

            Assert.True(File.Exists(fullPath));
            Assert.Equal(sourceText, File.ReadAllText(fullPath));
        }
        finally
        {
            if (Directory.Exists(tempDirectory))
                Directory.Delete(tempDirectory, true);
        }
    }

    [Fact]
    public void EncodeingDecoding_AsciiRoundTrip_ReturnsOriginalText()
    {
        const string original = "Hello 123";
        var ascii = original.ToAsciiArray();
        var restored = ascii.AsciiToString();

        Assert.Equal(original, restored);
    }

    [Fact]
    public void EncodeingDecoding_ToByte_ThrowsOverflowException_WhenValueOutOfRange()
    {
        Assert.Throws<OverflowException>(() => 300.ToByte());
    }

    [Fact]
    public void DateConverter_AgeHelpers_ReturnExpectedResults()
    {
        var birthDate = DateTime.UtcNow.Date.AddYears(-20).AddDays(-1);

        Assert.True(birthDate.IsAgeGreaterThan(18));
        Assert.True(birthDate.IsAgeEqualsTo(20));
        Assert.False(birthDate.IsAgeLessThan(20));
    }
}
