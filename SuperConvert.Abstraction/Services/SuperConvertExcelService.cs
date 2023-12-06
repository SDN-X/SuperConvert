using System.Data;
using SuperConvert.Statics;
using SuperConvert.Extensions.Helpers;

namespace SuperConvert.Abstraction
{
    internal class SuperConvertExcelService : ISuperConvertExcelService
    {
        /// <summary>
        /// Converting dataTable To CSV, 
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>

        public string DataTableToCsv(DataTable dataTable, string path = "", string fileName = "excel", char seperator = SuperConvertExcelSeperator.COMMA) =>
                 SuperHelper.DataTableToCsv(dataTable, path, fileName, seperator);
        /// <summary>
        /// Convert Datatable to byte[] Csv , 
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="seperator"></param>
        /// <returns></returns>

        public byte[] DataTableToCsv(DataTable dataTable, char seperator = SuperConvertExcelSeperator.COMMA) =>
                 SuperHelper.DataTableToCsv(dataTable, seperator);
        /// <summary>
        /// Converting json To CSV, 
        /// </summary>
        /// <param name="jsonData"></param>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string JsonToCsv(string jsonData, string path = "", string fileName = "excel", char seperator = SuperConvertExcelSeperator.COMMA) =>
             SuperHelper.JsonToCsv(jsonData, path, fileName, seperator);
        /// <summary>
        /// Convert Json to byte[] Csv , 
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="seperator"></param>
        /// <returns></returns>

        public byte[] JsonToCsv(string jsonData, char seperator = SuperConvertExcelSeperator.COMMA) =>
            SuperHelper.JsonToCsv(jsonData, seperator);
        /// <summary>
        /// Converting Csv to json, receives the csv path and returns json object  , 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>

        public string CsvToJson(string filePath) =>
            SuperHelper.ConvertCsvToJson(filePath);
        /// <summary>
        /// Converting Csv to dataTable, receives the csv path and returns dataTable object , 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>

        public DataTable CsvToDataTable(string filePath) =>
            SuperHelper.ConvertCsvToDatatable(filePath);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="jsonString"></param>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>

        public string JsonToXls(string jsonString, string path, string fileName) => SuperHelper.ConvertJsonToXls(jsonString, fileName, path);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>

        public string DataTableToXls(DataTable dataTable, string path, string fileName) => SuperHelper.ConvertDataTableToXls(dataTable, fileName, path);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>

        public byte[] JsonToXls(string jsonString) => SuperHelper.ConvertJsonToXls(jsonString);
        /// <summary>
        /// Converting Datatable to byte[] xls
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>

        public byte[] DataTableToXls(DataTable dataTable) => SuperHelper.ConvertDataTableToXls(dataTable);
    }
}