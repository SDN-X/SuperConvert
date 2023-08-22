using System;
using System.Data;
using System.Text.Json;
using System.Xml.Linq;
using SuperConvert.Extensions.Helpers;

namespace SuperConvert.Extensions
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
                : SuperHelper.JsonToDataTable(jsonString, tableName);

        /// <summary>
        /// Converts from DataTable to List of object ,Returned Json will be List of objects 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string ToJson(this DataTable dataTable)
        => dataTable == null ? throw new ArgumentNullException("DataTable can not be empty or null!") : SuperHelper.DataTableToJson(dataTable);
        /// <summary>
        /// Getting Xml string from json string
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns>string</returns>
        public static string ToXml(this string jsonString) => SuperHelper.JsonToXml(jsonString);
        /// <summary>
        /// Getting Json string out of xml string
        /// </summary>
        /// <param name="xmlString"></param>
        /// <returns></returns>
        public static string ToJson(this string xmlString) => SuperHelper.Serialize(SuperHelper.GetXmlData(XElement.Parse(xmlString)));

        /// <summary>
        /// Safe deserializing json string to object
        /// </summary>
        /// <param name="json"></param>
        /// <param name="returnedType"></param>
        /// <param name="serializeOptions"></param>
        /// <returns>object</returns>
        public static object? SafeDeserialize(this string json, Type returnedType, JsonSerializerOptions? serializeOptions = null)
            => JsonSerializer.Deserialize(json, returnedType, serializeOptions ?? new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }
}