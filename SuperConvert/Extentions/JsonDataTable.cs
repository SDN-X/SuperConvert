using System.Data;

namespace SuperConvert.Extentions
{
    public static class JsonDataTable
    {
        public static DataTable ToDataTable(this string jsonString, string tableName = "")
        {
            if (string.IsNullOrEmpty(jsonString))
                throw new ArgumentNullException("String value can not be empty or null!");
            return Helpers.JsonToDataTable(jsonString, tableName);
        }
        public static string ToJson(this DataTable dataTable)
        {
            if (dataTable == null)
                throw new ArgumentNullException("DataTable can not be empty or null!");
            return Helpers.DataTableToJson(dataTable);
        }
    }
}