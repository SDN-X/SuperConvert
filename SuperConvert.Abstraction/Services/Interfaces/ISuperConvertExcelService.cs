using SuperConvert.Statics;
using System.Data;


namespace SuperConvert.Abstraction
{
    public interface ISuperConvertExcelService
    {
        /// <summary>
        /// Converting dataTable To CSV
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>

        public string DataTableToCsv(DataTable dataTable, string path = "", string fileName = "excel", char seperator = SuperConvertExcelSeperator.COMMA);
        /// <summary>
        /// Convert Datatable to byte[] Csv
        /// </summary>
        /// <param name="jsonData"></param>
        /// <param name="seperator"></param>
        /// <returns></returns>
        public byte[] DataTableToCsv(DataTable dataTable, char seperator = SuperConvertExcelSeperator.COMMA);
        /// <summary>
        /// Converting json To CSV
        /// </summary>
        /// <param name="jsonData"></param>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string JsonToCsv(string jsonData, string path = "", string fileName = "excel", char seperator = SuperConvertExcelSeperator.COMMA);
        /// <summary>
        /// Convert Json to byte[] Csv
        /// </summary>
        /// <param name="jsonData"></param>
        /// <param name="seperator"></param>
        /// <returns></returns>
        public byte[] JsonToCsv(string jsonData, char seperator = SuperConvertExcelSeperator.COMMA);
        /// <summary>
        /// Converting Csv to json, receives the csv path and returns json object  
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>

        public string CsvToJson(string filePath);
        /// <summary>
        /// Converting Csv to dataTable, receives the csv path and returns dataTable object 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>

        public DataTable CsvToDataTable(string filePath);
        /// <summary>
        /// Converting Csv to DataTable
        /// </summary>
        /// <param name="jsonString"></param>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>

        public string JsonToXls(string jsonString, string path, string fileName);
        /// <summary>
        ///  Converting Json to xls file
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>

        public string DataTableToXls(DataTable dataTable, string path, string fileName);
        /// <summary>
        ///  Converting Json to byte[] xls
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>

        public byte[] JsonToXls(string jsonString);
        /// <summary>
        /// Converting Datatable to byte[] xls
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>

        public byte[] DataTableToXls(DataTable dataTable);
    }
}