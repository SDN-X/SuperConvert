using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml.Linq;
using System.Xml;

[assembly: InternalsVisibleTo("SuperConvert.Files")]
[assembly: InternalsVisibleTo("SuperConvert.Abstraction")]
namespace SuperConvert.Extensions.Helpers
{
    public static class SuperHelper
    {
        #region Json Converters
        /// <summary>
        /// Converts from Json List of object to Datatable,  Json must be List of objects 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        internal static DataTable JsonToDataTable(string data, string tableName = "")
        {
            if (!data.Contains("["))
                data = data.Insert(0, "[");
            if (!data.Contains("]"))
                data = data.Insert(data.Length, "]");
            DataTable dt = new DataTable(tableName);
            List<Dictionary<string, object>> dictionaryRows;
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
        internal static string JsonToXml(string jsonString) =>
            XDocument.Load(JsonReaderWriterFactory.CreateJsonReader(Encoding.ASCII.GetBytes(jsonString), new XmlDictionaryReaderQuotas())).ToString();
        /// <summary>
        /// Getting Dictionary of json values
        /// </summary>
        /// <param name="xml"></param>
        /// <returns>Dictionary<string, object></returns>
        internal static Dictionary<string, object> GetXmlData(XElement xml)
        {
            var attr = xml.Attributes().ToDictionary(d => d.Name.LocalName, d => (object)d.Value);
            if (xml.HasElements) attr.Add("_value", xml.Elements().Select(e => GetXmlData(e)));
            else if (!xml.IsEmpty) attr.Add("_value", xml.Value);

            return new Dictionary<string, object> { { xml.Name.LocalName, attr } };
        }
        /// <summary>
        /// Converts from DataTable to List of object ,Returned Json will be List of objects 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        internal static string DataTableToJson(DataTable dataTable) =>
            Serialize(GetDictionary(dataTable));
        #endregion

        #region Ascii Converters
        /// <summary>
        /// Convert string to array of ascii
        /// </summary>
        /// <param name="textToConvert"></param>
        /// <returns></returns>
        internal static int[] ConvertStringToAscii(string textToConvert) =>
            textToConvert.ToList().Select(character => (int)character).ToArray();
        /// <summary>
        /// Convert array of ascii to string
        /// </summary>
        /// <param name="asciiArray"></param>
        /// <returns></returns>
        internal static string ConvertAsciiToString(int[] asciiArray) =>
            new string(asciiArray.ToList().Select(ascii => (char)ascii).ToArray());
        #endregion

        #region ExcelConverter
        /// <summary>
        /// Converting dataTable To excel
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        internal static string DataTableToCsv(DataTable dataTable, string path, string fileName, char seperator)
        {
            var lines = new List<string>();

            string[] columnNames = dataTable.Columns
                .Cast<DataColumn>()
                .Select(column => column.ColumnName)
                .ToArray();

            var header = string.Join(seperator, columnNames.Select(EscapeCsvField));
            lines.Add(header);
            var valueLines = dataTable.AsEnumerable()
                .Select(row => string.Join(seperator, row.ItemArray.Select(EscapeCsvField)));
            lines.AddRange(valueLines);
            string fullPath = Path.Combine(path, $"{fileName}.csv");
            File.WriteAllLines(fullPath, lines);
            return fullPath;
        }
        internal static byte[] DataTableToCsv(DataTable dataTable, char seperator)
        {
            var lines = new List<string>();

            string[] columnNames = dataTable.Columns
                .Cast<DataColumn>()
                .Select(column => column.ColumnName)
                .ToArray();

            var header = string.Join(seperator, columnNames.Select(EscapeCsvField));
            lines.Add(header);

            var valueLines = dataTable.AsEnumerable()
                .Select(row => string.Join(seperator, row.ItemArray.Select(EscapeCsvField)));
            lines.AddRange(valueLines);

            string data = string.Join("\n", lines);
            byte[] byteArray = Encoding.UTF8.GetBytes(data);

            return byteArray;
        }

        /// <summary>
        /// Converting dataTable To excel
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        internal static string JsonToCsv(string json, string path, string fileName, char seperator) => DataTableToCsv(JsonToDataTable(json, fileName), path, fileName, seperator);
        internal static byte[] JsonToCsv(string json, char seperator) => DataTableToCsv(JsonToDataTable(json), seperator);
        internal static string ConvertCsvToJson(string filePath)
        {
            var csvContent = File.ReadAllText(filePath);
            var csvRows = ParseCsvRows(csvContent, ',');
            if (csvRows.Count == 0)
                return Serialize(new List<Dictionary<string, string>>());

            var properties = csvRows[0];

            var listObjResult = new List<Dictionary<string, string>>();

            for (int i = 1; i < csvRows.Count; i++)
            {
                var objResult = new Dictionary<string, string>();
                var currentRow = csvRows[i];
                for (int j = 0; j < properties.Length; j++)
                {
                    var value = j < currentRow.Length ? currentRow[j] : string.Empty;
                    objResult[properties[j]] = value;
                }

                listObjResult.Add(objResult);
            }

            return Serialize(listObjResult);
        }
        internal static DataTable ConvertCsvToDatatable(string filePath) =>
            ConvertCsvToJson(filePath).ToDataTable();
        #endregion

        #region Serializers
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
        private static T Deserialize<T>(string body) =>
            JsonSerializer.Deserialize<T>(body) ?? throw new InvalidOperationException("Failed to deserialize JSON payload.");
        /// <summary>
        /// Serialize an object to json
        /// </summary>
        internal static string Serialize<T>(T item) => JsonSerializer.Serialize(item);

        private static string EscapeCsvField(object? value)
        {
            var content = value?.ToString() ?? string.Empty;
            return $"\"{content.Replace("\"", "\"\"")}\"";
        }

        private static List<string[]> ParseCsvRows(string content, char separator)
        {
            var rows = new List<string[]>();
            var fields = new List<string>();
            var fieldBuilder = new StringBuilder();
            var inQuotes = false;

            for (int i = 0; i < content.Length; i++)
            {
                var current = content[i];

                if (inQuotes)
                {
                    if (current == '"')
                    {
                        var hasEscapedQuote = i + 1 < content.Length && content[i + 1] == '"';
                        if (hasEscapedQuote)
                        {
                            fieldBuilder.Append('"');
                            i++;
                        }
                        else
                        {
                            inQuotes = false;
                        }
                    }
                    else
                    {
                        fieldBuilder.Append(current);
                    }

                    continue;
                }

                if (current == '"')
                {
                    inQuotes = true;
                }
                else if (current == separator)
                {
                    fields.Add(fieldBuilder.ToString());
                    fieldBuilder.Clear();
                }
                else if (current == '\r' || current == '\n')
                {
                    fields.Add(fieldBuilder.ToString());
                    fieldBuilder.Clear();
                    rows.Add(fields.ToArray());
                    fields.Clear();

                    if (current == '\r' && i + 1 < content.Length && content[i + 1] == '\n')
                        i++;
                }
                else
                {
                    fieldBuilder.Append(current);
                }
            }

            if (inQuotes)
                throw new FormatException("CSV format is invalid: unclosed quoted field.");

            if (fieldBuilder.Length > 0 || fields.Count > 0)
            {
                fields.Add(fieldBuilder.ToString());
                rows.Add(fields.ToArray());
            }

            return rows;
        }

        internal static string ConvertJsonToXls(string jsonString, string fileName, string path) => ConvertDataTableToXls(JsonToDataTable(jsonString), fileName, path);
        internal static byte[] ConvertJsonToXls(string jsonString) => ConvertDataTableToXls(JsonToDataTable(jsonString));
        internal static string ConvertDataTableToXls(DataTable dataTable, string fileName, string path)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                sb.Append(dataTable.Columns[i].ColumnName + "\t");
            }
            sb.Append("\n");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    sb.Append(dataTable.Rows[i][j].ToString() + "\t");
                }
                sb.Append("\n");
            }

            string fullPath = Path.Combine(path, $"{fileName}.xls");

            File.WriteAllText(fullPath, sb.ToString());
            return fullPath;
        }
        internal static byte[] ConvertDataTableToXls(DataTable dataTable)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                sb.Append(dataTable.Columns[i].ColumnName + "\t");
            }
            sb.Append("\n");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    sb.Append(dataTable.Rows[i][j].ToString() + "\t");
                }
                sb.Append("\n");
            }

            string data = sb.ToString();
            byte[] byteArray = Encoding.UTF8.GetBytes(data);

            return byteArray;
        }

        #endregion
    }
}
