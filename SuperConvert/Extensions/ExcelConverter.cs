using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperConvert.Extensions.Helpers;

namespace SuperConvert.Extensions
{
    [Obsolete("This Class is Deprecated, it will be removed on future versions, Please use \"SuperConvert.Files\"")]
    public static class ExcelConverter
    {
        /// <summary>
        /// Converting dataTable To CSV
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        [Obsolete("This Method is Deprecated, it will be removed on future versions, Please use 'SuperConvert.Files'")]
        public static string ToCsv(this DataTable dataTable, string path = "", string fileName = "excel") =>
                 SuperHelper.DataTableToExcel(dataTable, path, fileName);

        /// <summary>
        /// Converting json To CSV
        /// </summary>
        /// <param name="jsonData"></param>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        [Obsolete("This Method is Deprecated, it will be removed on future versions, Please use 'SuperConvert.Files'")]
        public static string ToCsv(this string jsonData, string path = "", string fileName = "excel") =>
             SuperHelper.JsonToExcel(jsonData, path, fileName);
        /// <summary>
        /// Converting Csv to json, receives the csv path and returns json object 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        [Obsolete("This Method is Deprecated, it will be removed on future versions, Please use 'SuperConvert.Files'")]
        public static string CsvToJson(string filePath) =>
            SuperHelper.ConvertCsvToJson(filePath);
        /// <summary>
        /// Converting Csv to dataTable, receives the csv path and returns dataTable object
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        [Obsolete("This Method is Deprecated, it will be removed on future versions, Please use 'SuperConvert.Files'")]
        public static DataTable CsvToDataTable(string filePath) =>
            SuperHelper.ConvertCsvToDatatable(filePath);
    }
}
