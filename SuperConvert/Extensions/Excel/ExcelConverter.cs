using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperConvert.Extensions.Helpers;
using SuperConvert.Statics;

namespace SuperConvert.Extensions
{
    public static class ExcelConverter
    {
        /// <summary>
        /// Converting dataTable To CSV
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string ToCsv(this DataTable dataTable, string path = "", string fileName = "excel", char seperator = SuperConvertExcelSeperator.COMMA) =>
                 SuperHelper.DataTableToCsv(dataTable, path, fileName, seperator);

        public static byte[] ToCsv(this DataTable dataTable, char seperator = SuperConvertExcelSeperator.COMMA) =>
                 SuperHelper.DataTableToCsv(dataTable, seperator);
        /// <summary>
        /// Converting json To CSV
        /// </summary>
        /// <param name="jsonData"></param>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string ToCsv(this string jsonData, string path = "", string fileName = "excel", char seperator = SuperConvertExcelSeperator.COMMA) =>
             SuperHelper.JsonToCsv(jsonData, path, fileName, seperator);

        public static byte[] ToCsv(this string jsonData, char seperator = SuperConvertExcelSeperator.COMMA) =>
            SuperHelper.JsonToCsv(jsonData, seperator);
        /// <summary>
        /// Converting Csv to json, receives the csv path and returns json object 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string CsvToJson(string filePath) =>
            SuperHelper.ConvertCsvToJson(filePath);
        /// <summary>
        /// Converting Csv to dataTable, receives the csv path and returns dataTable object
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static DataTable CsvToDataTable(string filePath) =>
            SuperHelper.ConvertCsvToDatatable(filePath);
        public static string ToXls(this string jsonString, string path, string fileName) => SuperHelper.ConvertJsonToXls(jsonString, fileName, path);
        public static string ToXls(this DataTable dataTable, string path, string fileName) => SuperHelper.ConvertDataTableToXls(dataTable, fileName, path);


        public static byte[] ToXls(this string jsonString) => SuperHelper.ConvertJsonToXls(jsonString);
        public static byte[] ToXls(this DataTable dataTable) => SuperHelper.ConvertDataTableToXls(dataTable);
    }
}
