# Super Convert
## _Make your data conversion_

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://github.com/esamelzain/SuperConvert)

SuperConvert is a tool to convert your data in c#
- Create some json strings / Data tables
- Convert between them
- Convert DateTime
- Convert Json <=> Csv 
- Convert DataTable <=> Csv
- ✨Magic ✨

## Features

- Convert Json to datatable
- Convert Datatable to json
- DateTime convert from Gregorian To Hijri
- DateTime convert Hijri To Gregorian
- Json convert to Csv
- DataTable convert to Csv
- Csv convert to Json
- Csv convert to DataTable

## Coming soon !

- Excel sheets (XLS, XLSX) and other data containers/types

## Tech

SuperConvet's code is based on .net technology (>6)

- [.Net6] - C# !

- [GitHub Code](https://github.com/SDN-X/SuperConvert) - SuperConvert Project

## Installation


Run the command on your nuget package console .

```sh
Install-Package SuperConvert -Version 1.0.3
```
## Or 

Open your nuget package manager and type the name of 'SuperConvert' on the search

## Usage 
## Namespaces
```cs
using SuperConvert.Extentions;
using System.Data;
```
## Json to dataTable
```cs
string customers = "[{\"CompanayID\":\"k123\",\"Role\":\"Admin\",\"Country\":\"UK\",\"Asset\":\"HD\",\"incident\":null}, {\"CompanayID\":\"k234\",\"Role\":\"User\",\"Country\":\"US\",\"Asset\":\"HD12\",\"incident\":\"abc 1\"}]";
DataTable dt = customers.ToDataTable("TableName");
//Printing the Result
foreach (DataRow row in dt.Rows)
{
    foreach (DataColumn column in dt.Columns)
    {
        Console.Write($"{column.ColumnName} : {row[column.ColumnName]} \t");
    }
    Console.WriteLine("\n ");
}
```
## DataTable to json
```cs
string json = dt.ToJson();
Console.WriteLine($"Json: \n {json} \n");
```
## DateTime GregorianToHijri
```cs
DateTime timeNow = DateTime.Now;
DateTime hijri = DateConverter.GregorianToHijri(timeNow);
Console.WriteLine($"GregorianToHijri \n {hijri.ToString("dd/MM/yyyy")}\n");
```
## DateTime HijriToGregorian
```cs
DateTime gregorian = DateConverter.HijriToGregorian(hijri);
Console.WriteLine($"HijriToGregorian \n {gregorian.ToString("dd/MM/yyyy")} \n");
```
## Excels
```cs
string path = string.Empty;
string fileName = "DtToExcel";
string csvPath = dt.ToCsv(path, fileName);
Console.WriteLine($"the file {csvPath} has been successfully saved\n");
//Json To CSV
fileName = "JsonToExcel";
Console.WriteLine($"the file {json.ToCsv(path, fileName)} has been successfully saved\n");
//CSV To Json
Console.WriteLine($"CSV To Json {ExcelConverter.CsvToJson(csvPath)}\n");
//CSV To Datatable
DataTable csvDt = ExcelConverter.CsvToDataTable(csvPath);
Console.WriteLine($"CSV To Datatable: \n");
foreach (DataRow row in csvDt.Rows)
{
    foreach (DataColumn column in dt.Columns)
    {
        Console.Write($"{column.ColumnName} : {row[column.ColumnName]} \t");
    }
    Console.WriteLine("\n ");
}
Console.ReadLine();


```
| Version | README |
| ------  | ------ |
| 1.0.0 | [https://www.nuget.org/packages/SuperConvert/1.0.0]|
| 1.0.1 | [https://www.nuget.org/packages/SuperConvert/1.0.1]|
| 1.1.2 | [https://www.nuget.org/packages/SuperConvert/1.0.2]|
| 1.1.3 | [https://www.nuget.org/packages/SuperConvert/1.0.3]|
