using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace SuperConvert.Extentions
{
    public static class Helpers
    {

        public static DataTable JsonToDataTable(string data, string tableName = "")
        {
            DataTable dt = new DataTable(tableName);
            List<Dictionary<string, object>>? dictionaryRows = new List<Dictionary<string, object>>();
            try
            {
                dictionaryRows = Deserialize<List<Dictionary<string, object>>>(data);
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
        public static string DataTableToJson(DataTable dataTable)
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
        /// <summary>
        /// Get Dictionary from datatable
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Deserialize an from json string
        /// </summary>
        private static T Deserialize<T>(string body)
        {
            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream))
            {
                writer.Write(body);
                writer.Flush();
                stream.Position = 0;
                return (T)new DataContractJsonSerializer(typeof(T)).ReadObject(stream);
            }
        }
        /// <summary>
        /// Serialize an object to json
        /// </summary>
        private static string Serialize<T>(T item)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                new DataContractJsonSerializer(typeof(T)).WriteObject(ms, item);
                return Encoding.Default.GetString(ms.ToArray());
            }
        }
    }
}
