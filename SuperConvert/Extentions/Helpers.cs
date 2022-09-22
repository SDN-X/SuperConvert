using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;

namespace SuperConvert.Extentions
{
    public static class Helpers
    {
        /// <summary>
        /// Converts from Json List of object to Datatable,  Json must be List of objects 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        internal static DataTable JsonToDataTable(string data, string tableName = "")
        {
            DataTable dt = new DataTable(tableName);
            List<Dictionary<string, object>>? dictionaryRows = new List<Dictionary<string, object>>();
            try
            {
                dictionaryRows = Deserialize<List<Dictionary<string, object>>>(data);
            }
            catch (Exception ex)
            {
                throw new Exception($"Json value not valid : Must be List of objects :: {ex.Message}");
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
        /// <summary>
        /// Converts from DataTable to List of object ,Returned Json will be List of objects 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        internal static string DataTableToJson(DataTable dataTable)
        {
            string jsonValue = "";
            try
            {
                List<Dictionary<string, object>> keyValuePairs = GetDictionary(dataTable);
                jsonValue = Serialize(keyValuePairs);
            }
            catch (Exception ex)
            {
                throw new Exception($"DataTable can not be converted to jaon ::: {ex.Message}");
            }
            return jsonValue;
        }

        internal static int[] ConvertStringToAscii(string textToConvert)
        {
            List<int> result = new List<int>();
            textToConvert.ToList().ForEach(character => result.Add(character));
            return result.ToArray();
        }
        internal static string ConvertAsciiToString(int[] asciiArray)
        {
            string text = string.Empty;
            asciiArray.ToList().ForEach(ascii => { text += (char)ascii; });
            return text;
        }
        /// <summary>
        /// Get Dictionary from datatable
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private static List<Dictionary<string, object>> GetDictionary(DataTable dt) =>
            // Iterate through the rows...
            dt.AsEnumerable().Select(
            // ...then iterate through the columns...
            row => dt.Columns.Cast<DataColumn>().ToDictionary(
                           // ...and find the key value pairs for the dictionary
                           column => column.ColumnName,    // Key
                           column => row[column]  // Value
                       )
                   ).ToList();
        /// <summary>
        /// Deserialize an from json string
        /// </summary>
        private static T Deserialize<T>(string body) => JsonSerializer.Deserialize<T>(body);
        /// <summary>
        /// Serialize an object to json
        /// </summary>
        private static string Serialize<T>(T item) => JsonSerializer.Serialize<T>(item);
    }
}
