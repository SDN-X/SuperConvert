using SuperConvert.Extensions;
using System.Data;

//Json to dataTable
string customers = "[{\"CompanayID\":\"k123\",\"Role\":\"Admin\",\"Country\":\"UK\",\"Asset\":\"HD\",\"incident\":null}, {\"CompanayID\":\"k234\",\"Role\":\"User\",\"Country\":\"US\",\"Asset\":\"HD12\",\"incident\":\"abc 1\"}]";
DataTable dt = customers.ToDataTable("TableName");
//Printing the Result
foreach (DataRow row in dt.Rows)
{
    foreach (DataColumn column in dt.Columns)
    {
        Console.Write($"{column.ColumnName} : {row[column.ColumnName]} \t");
    }
    Console.WriteLine("\n ");
}

//DataTable to json
string json = dt.ToJson();
Console.WriteLine($"Json: \n {json} \n");

//GregorianToHijri
DateTime timeNow = DateTime.Now;
DateTime hijri = DateConverter.GregorianToHijri(timeNow);
Console.WriteLine($"GregorianToHijri \n {hijri.ToString("dd/MM/yyyy")}\n");

//HijriToGregorian
DateTime gregorian = DateConverter.HijriToGregorian(hijri);
Console.WriteLine($"HijriToGregorian \n {gregorian.ToString("dd/MM/yyyy")} \n");

//Datatble To CSV
string path = string.Empty;
string fileName = "DtToExcel";
string csvPath = dt.ToCsv(path, fileName);
Console.WriteLine($"the file {csvPath} has been successfully saved\n");

//Json To CSV
fileName = "JsonToExcel";
Console.WriteLine($"the file {json.ToCsv(path, fileName)} has been successfully saved\n");

//CSV To Json
Console.WriteLine($"CSV To Json {ExcelConverter.CsvToJson(csvPath)}\n");

//CSV To Datatable
DataTable csvDt = ExcelConverter.CsvToDataTable(csvPath);
Console.WriteLine($"CSV To Datatable: \n");
foreach (DataRow row in csvDt.Rows)
{
    foreach (DataColumn column in dt.Columns)
    {
        Console.Write($"{column.ColumnName} : {row[column.ColumnName]} \t");
    }
    Console.WriteLine("\n ");
}

//string to ascii
string toAscii = "Hello world";
var asciiArray = toAscii.ToAsciiArray();
Console.WriteLine($"string to ascii: ");
asciiArray.ToList().ForEach(i => Console.Write($"{i} "));

//ascii to string
toAscii = asciiArray.AsciiToString();
Console.WriteLine($"\n\nascii to string: ");
Console.WriteLine($"{toAscii} \n");

//File to Base64
string base64File = FileConverter.ToBase64String(csvPath);
Console.WriteLine($"File to Base64 => {base64File}\n");

//Base64 to File
FileConverter.ToFile(base64File, "MyFile");

//Json to xml
string xmlString = customers.ToXml();
Console.WriteLine($"Json to Xml\n{xmlString}\n");

//Xml to json
Console.WriteLine($"Xml to Json\n{xmlString.ToJson()}\n");
//Age Calculations
Console.WriteLine("Age Calculations");
DateTime birthDate = new DateTime(1993,08,09);
Console.WriteLine($"birthDate: {birthDate} is age = 29 ? {birthDate.IsAgeEqualsTo(29)}");
Console.WriteLine($"birthDate: {birthDate} is age > 28 ? {birthDate.IsAgeGreaterThan(28)}"); 
Console.WriteLine($"birthDate: {birthDate} is age < 25 ? {birthDate.IsAgeLessThan(25)}");
Console.ReadLine();
