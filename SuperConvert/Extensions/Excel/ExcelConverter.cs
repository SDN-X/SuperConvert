using System;
using System.Data;
using SuperConvert.Extensions.Helpers;
using SuperConvert.Statics;

namespace SuperConvert.Extensions
{
    public static class ExcelConverter
    {
        /// <summary>
        /// Converting dataTable To CSV, This method is deprecated, please use the new <a href = "https://www.superconvert.live/documentation"> SuperConvert </a>  services instead, click <a href = "https://www.superconvert.live/documentation"> here </a> to know more..)
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        
        public static string ToCsv(this DataTable dataTable, string path = "", string fileName = "excel", char seperator = SuperConvertExcelSeperator.COMMA) =>
                 SuperHelper.DataTableToCsv(dataTable, path, fileName, seperator);
        /// <summary>
        /// Convert Datatable to byte[] Csv , This method is deprecated, please use the new <a href = "https://www.superconvert.live/documentation"> SuperConvert </a>  services instead, click <a href = "https://www.superconvert.live/documentation"> here </a> to know more..)
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="seperator"></param>
        /// <returns></returns>
        
        public static byte[] ToCsv(this DataTable dataTable, char seperator = SuperConvertExcelSeperator.COMMA) =>
                 SuperHelper.DataTableToCsv(dataTable, seperator);
        /// <summary>
        /// Converting json To CSV, This method is deprecated, please use the new <a href = "https://www.superconvert.live/documentation"> SuperConvert </a>  services instead, click <a href = "https://www.superconvert.live/documentation"> here </a> to know more..)
        /// </summary>
        /// <param name="jsonData"></param>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string ToCsv(this string jsonData, string path = "", string fileName = "excel", char seperator = SuperConvertExcelSeperator.COMMA) =>
             SuperHelper.JsonToCsv(jsonData, path, fileName, seperator);
        /// <summary>
        /// Convert Json to byte[] Csv , This method is deprecated, please use the new <a href = "https://www.superconvert.live/documentation"> SuperConvert </a>  services instead, click <a href = "https://www.superconvert.live/documentation"> here </a> to know more..)
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="seperator"></param>
        /// <returns></returns>
        
        public static byte[] ToCsv(this string jsonData, char seperator = SuperConvertExcelSeperator.COMMA) =>
            SuperHelper.JsonToCsv(jsonData, seperator);
        /// <summary>
        /// Converting Csv to json, receives the csv path and returns json object  , This method is deprecated, please use the new <a href = "https://www.superconvert.live/documentation"> SuperConvert </a>  services instead, click <a href = "https://www.superconvert.live/documentation"> here </a> to know more..)
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        
        public static string CsvToJson(string filePath) =>
            SuperHelper.ConvertCsvToJson(filePath);
        /// <summary>
        /// Converting Csv to dataTable, receives the csv path and returns dataTable object , This method is deprecated, please use the new <a href = "https://www.superconvert.live/documentation"> SuperConvert </a>  services instead, click <a href = "https://www.superconvert.live/documentation"> here </a> to know more..)
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        
        public static DataTable CsvToDataTable(string filePath) =>
            SuperHelper.ConvertCsvToDatatable(filePath);
        /// <summary>
        ///  This method is deprecated, please use the new <a href = "https://www.superconvert.live/documentation"> SuperConvert </a>  services instead, click <a href = "https://www.superconvert.live/documentation"> here </a> to know more..)
        /// </summary>
        /// <param name="jsonString"></param>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        
        public static string ToXls(this string jsonString, string path, string fileName) => SuperHelper.ConvertJsonToXls(jsonString, fileName, path);
        /// <summary>
        ///  This method is deprecated, please use the new <a href = "https://www.superconvert.live/documentation"> SuperConvert </a>  services instead, click <a href = "https://www.superconvert.live/documentation"> here </a> to know more..)
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        
        public static string ToXls(this DataTable dataTable, string path, string fileName) => SuperHelper.ConvertDataTableToXls(dataTable, fileName, path);
        /// <summary>
        ///  This method is deprecated, please use the new <a href = "https://www.superconvert.live/documentation"> SuperConvert </a>  services instead, click <a href = "https://www.superconvert.live/documentation"> here </a> to know more..)
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        
        public static byte[] ToXls(this string jsonString) => SuperHelper.ConvertJsonToXls(jsonString);
        /// <summary>
        /// This method is deprecated, please use the new <a href = "https://www.superconvert.live/documentation"> SuperConvert </a>  services instead, click <a href = "https://www.superconvert.live/documentation"> here </a> to know more..)
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        
        public static byte[] ToXls(this DataTable dataTable) => SuperHelper.ConvertDataTableToXls(dataTable);

    }
}
