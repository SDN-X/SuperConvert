using SuperConvert.Extentions;
using System.Data;
internal class Program
{
    private static void Main(string[] args)
    {
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
        string json = dt.ToJson();
        Console.WriteLine($"\n Json: \n {json}");
    }
}