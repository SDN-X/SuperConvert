//Json to dataTable
using SuperConvert.Extentions;
using System.Data;

string customers = "[{\"CompanayID\":\"k123\",\"Role\":\"Admin\",\"Country\":\"UK\",\"Asset\":\"HD\",\"incident\":null}, {\"CompanayID\":\"k234\",\"Role\":\"User\",\"Country\":\"US\",\"Asset\":\"HD12\",\"incident\":\"abc 1\"}]";
DataTable dt = customers.ToDataTable("TableName");
//Printing the Result
foreach (DataRow row in dt.Rows)
{
    foreach (DataColumn column in dt.Columns)
    {
        Console.Write($"{column.ColumnName} : {row[column.ColumnName]} \t");
    }
    Console.WriteLine("");
}
//DataTable to json
string json = dt.ToJson();
Console.WriteLine($"\n Json: \n {json} \n");
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
Console.WriteLine($"the file {dt.ToCsv(path, fileName)} has been successfully saved\n");
//Json To CSV
fileName = "JsonToExcel";
Console.WriteLine($"the file {json.ToCsv(path, fileName)} has been successfully saved\n");
Console.ReadLine();
