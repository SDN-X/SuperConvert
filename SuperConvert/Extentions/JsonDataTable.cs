using Newtonsoft.Json;
using System.Data;

namespace SuperConvert.Extentions
{
    public static class JsonDataTable
    {
        public static DataTable ToDataTable(this string jsonString, string tableName = "")
        {
            if (string.IsNullOrEmpty(jsonString))
                throw new ArgumentNullException("String value can not be empty or null!");
            return JsonToDataTable(jsonString, tableName);
        }
        public static string ToJson(this DataTable dataTable)
        {
            if (dataTable == null)
                throw new ArgumentNullException("DataTable can not be empty or null!");
            return DataTableToJson(dataTable);
        }

        #region Privates
        private static DataTable JsonToDataTable(string data, string tableName = "")
        {
            DataTable dt = new DataTable(tableName);
            List<Dictionary<string, object>>? dictionaryRows = new List<Dictionary<string, object>>();
            try
            {
                dictionaryRows = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(data);
            }
            catch (Exception ex)
            {
                throw new Exception($"Json value not valid ::: {ex.Message}");
            }
            foreach (Dictionary<string, object> row in dictionaryRows)
            {
                DataRow dr = dt.NewRow();
                foreach (KeyValuePair<string, object> innerColumn in row)
                {
                    //Check If column is already there
                    if (!dt.Columns.Contains(innerColumn.Key))
                    {
                        //Add column if not exists
                        dt.Columns.Add(innerColumn.Key);
                    }
                    //Add cell value
                    dr[innerColumn.Key] = innerColumn.Value;
                }
                //Add dataRow to dataTable
                dt.Rows.Add(dr);
            }
            return dt;
        }
        private static string DataTableToJson(DataTable dataTable)
        {
            string jsonValue = "";
            try
            {
                List<Dictionary<string, object>> keyValuePairs = GetDictionary(dataTable);
                jsonValue = JsonConvert.SerializeObject(keyValuePairs);
            }
            catch (Exception ex)
            {
                throw new Exception($"DataTable can not be converted to jaon ::: {ex.Message}");
            }
            return jsonValue;
        }
        private static List<Dictionary<string, object>> GetDictionary(DataTable dt)
        {
            // Iterate through the rows...
            return dt.AsEnumerable().Select(
            // ...then iterate through the columns...
            row => dt.Columns.Cast<DataColumn>().ToDictionary(
                           // ...and find the key value pairs for the dictionary
                           column => column.ColumnName,    // Key
                           column => row[column]  // Value
                       )
                   ).ToList();

        }
        #endregion
    }
}