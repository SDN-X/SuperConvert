using System.Data;
using System.Text;
using SuperConvert.Extensions;

namespace SuperConvert.Tests;

public class CsvRegressionTests
{
    [Fact]
    public void ToCsv_EscapesInnerQuotes_AsDoubleQuotes()
    {
        var table = new DataTable("Sample");
        table.Columns.Add("Text");
        table.Rows.Add("The \"elephant\" in the room. ");

        var csvBytes = table.ToCsv(',');
        var csv = Encoding.UTF8.GetString(csvBytes);

        Assert.Contains("\"The \"\"elephant\"\" in the room. \"", csv);
    }

    [Fact]
    public void CsvToDataTable_UnescapesDoubledQuotes_ToSingleQuote()
    {
        var path = Path.GetTempFileName();
        try
        {
            File.WriteAllText(path, "\"Text\"\n\"The \"\"elephant\"\" in the room. \"");

            var table = ExcelConverter.CsvToDataTable(path);

            Assert.Equal("The \"elephant\" in the room. ", table.Rows[0]["Text"].ToString());
        }
        finally
        {
            File.Delete(path);
        }
    }

    [Fact]
    public void CsvToDataTable_ParsesQuotedFieldContainingComma()
    {
        var path = Path.GetTempFileName();
        try
        {
            File.WriteAllText(path, "\"Name\",\"State\"\n\"Doe, John\",\"Active\"");

            var table = ExcelConverter.CsvToDataTable(path);

            Assert.Equal("Doe, John", table.Rows[0]["Name"].ToString());
            Assert.Equal("Active", table.Rows[0]["State"].ToString());
        }
        finally
        {
            File.Delete(path);
        }
    }
}
