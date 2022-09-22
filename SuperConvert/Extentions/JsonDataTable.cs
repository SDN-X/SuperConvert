using System.Data;

namespace SuperConvert.Extentions
{
    public static class JsonDataTable
    {

        /// <summary>
        /// Converts from Json List of object to Datatable,  Json must be List of objects 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static DataTable ToDataTable(this string jsonString, string tableName = "") => string.IsNullOrEmpty(jsonString)
                ? throw new ArgumentNullException("String value can not be empty or null!")
                : Helpers.JsonToDataTable(jsonString, tableName);
        /// <summary>
        /// Converts from DataTable to List of object ,Returned Json will be List of objects 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string ToJson(this DataTable dataTable)
        => dataTable == null ? throw new ArgumentNullException("DataTable can not be empty or null!") : Helpers.DataTableToJson(dataTable);
    }
}