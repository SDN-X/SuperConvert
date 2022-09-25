using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperConvert.Extentions
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
        public static string ToCsv(this DataTable dataTable, string path, string fileName) =>
             Helpers.DataTableToExcel(dataTable,path,fileName);

        /// <summary>
        /// Converting json To CSV
        /// </summary>
        /// <param name="jsonData"></param>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string ToCsv(this string jsonData, string path, string fileName) =>
             Helpers.JsonToExcel(jsonData, path, fileName);
    }
}
