using System;
using System.Data;
using System.Text.Json;
using SuperConvert.Helpers;

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
                : Helper.JsonToDataTable(jsonString, tableName);



        /// <summary>
        /// Converts from DataTable to List of object ,Returned Json will be List of objects 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string ToJson(this DataTable dataTable)
        => dataTable == null ? throw new ArgumentNullException("DataTable can not be empty or null!") : Helper.DataTableToJson(dataTable);



        /// <summary>
        /// Safe deserializing json string to object
        /// </summary>
        /// <param name="json"></param>
        /// <param name="returnedType"></param>
        /// <param name="serializeOptions"></param>
        /// <returns>object</returns>
        public static object SafeDeserialize(this string json, Type returnedType, JsonSerializerOptions serializeOptions = null)
        {
            try
            {
                if (serializeOptions == null)
                {
                    serializeOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                }
                return JsonSerializer.Deserialize(json, returnedType, serializeOptions);
            }
            catch 
            {
                return null;
            }
        }
    }
}