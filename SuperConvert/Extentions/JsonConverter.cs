using System;
using System.Data;
using System.Text.Json;
using System.Xml.Linq;
using SuperConvert.Extentions.Helpers;

namespace SuperConvert.Extentions
{
    public static class JsonConverter
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
        /// Getting Xml string from json string
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns>string</returns>
        public static string ToXml(this string jsonString) => Helper.JsonToXml(jsonString);
        /// <summary>
        /// Getting Json string out of xml string
        /// </summary>
        /// <param name="xmlString"></param>
        /// <returns></returns>
        public static string ToJson(this string xmlString) => Helper.Serialize(Helper.GetXmlData(XElement.Parse(xmlString)));

        /// <summary>
        /// Safe deserializing json string to object
        /// </summary>
        /// <param name="json"></param>
        /// <param name="returnedType"></param>
        /// <param name="serializeOptions"></param>
        /// <returns>object</returns>
        [Obsolete("This function is deprecated, and will be removed within the next versions, Plesae use Helper.Deserialize() instead.")]
        public static object SafeDeserialize(this string json, Type returnedType, JsonSerializerOptions? serializeOptions = null)
            => JsonSerializer.Deserialize(json, returnedType, serializeOptions ?? new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }
}