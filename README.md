# Super Convert
## _Make your data conversion_

[![BuildStatus](https://img.shields.io/github/workflow/status/SDN-X/SuperConvert/Build%20and%20Test)](https://github.com/SDN-X/SuperConvert/actions)
[![codecov](https://codecov.io/gh/esamelzain/SuperConvert/branch/main/graph/badge.svg)](https://codecov.io/gh/esamelzain/SuperConvert)
[![License](https://img.shields.io/github/license/SDN-X/SuperConvert)](https://github.com/SDN-X/SuperConvert/blob/master/LICENSE.txt)


🚀 SuperConvert is the ultimate tool for data conversion in C#/.NET! It supports JSON, XML, CSV, XLS and much more! With SuperConvert, you can easily convert any data format to another with just a few lines of code. 💪

📖 Its documentation provides clear and detailed explanations of all the methods and features available, making it easy to use and master. 🤓

💻 And if you're looking for more resources, the SuperConvert blog has plenty of articles on data conversion and best practices. 📰

🔧 Don't miss out on the powerful features SuperConvert has to offer, such as encoding and decoding files to/from base64, converting between data formats with customizable options, and more! ⚙️

👍 Whether you're a seasoned developer or just starting out, SuperConvert is the perfect tool to simplify your data conversion tasks and improve your workflow. Give it a try today! 💻👨‍💻

## Features

- Convert Json to Datatable
- Convert Datatable to Json
- DateTime convert from Gregorian To Hijri
- DateTime convert from Hijri To Gregorian
- Json convert to Csv
- DataTable convert to Csv
- Csv convert to Json
- Csv convert to DataTable
- Json to Xls
- Datatable to Xls

- Excel sheets (XLS, XLSX) and other data containers/types is already here
Just use 

```cs
 .ToXls() 
```

## Tech

SuperConvet's code is based on .net core technology (netcoreapp3.1, net5.0, net6.0, net7.0)

- [.NetCore3.1, .Net5, .Net6] - C# !

- [GitHub Code](https://github.com/SDN-X/SuperConvert) - SuperConvert Project

## Installation


Run the command on your nuget package console .

```sh
Install-Package SuperConvert -Version 1.0.4.3
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
```
## DataTable to json
```cs
string json = dt.ToJson();
```
## DateTime GregorianToHijri
```cs
DateTime timeNow = DateTime.Now;
DateTime hijri = DateConverter.GregorianToHijri(timeNow);
```
## DateTime HijriToGregorian
```cs
DateTime gregorian = DateConverter.HijriToGregorian(hijri);
```
## Excels
## Datatable to Csv
```cs
string path = string.Empty;
string fileName = "DtToExcel";
string csvPath = dt.ToCsv(path, fileName);
```
## Json To CSV
```cs
fileName = "JsonToExcel";
path = string.Empty;
string csvPath = json.ToCsv(path, fileName)
```
## Json To XLS
```cs
fileName = "JsonToExcel";
path = string.Empty;
string csvPath = json.ToXls(path, fileName)
```
## CSV To Json
```cs
string jsonFromCsv = ExcelConverter.CsvToJson(csvPath);
```
## CSV To Datatable
```cs
DataTable csvDt = ExcelConverter.CsvToDataTable(csvPath);
```
| Version | README |
| ------  | ------ |
| 1.0.4.6 | https://www.nuget.org/packages/SuperConvert/1.0.4.6
| 1.0.4.5 | https://www.nuget.org/packages/SuperConvert/1.0.4.5
| 1.0.4.4 | https://www.nuget.org/packages/SuperConvert/1.0.4.4
| 1.0.4.3 | https://www.nuget.org/packages/SuperConvert/1.0.4.3
| 1.0.4.2 | https://www.nuget.org/packages/SuperConvert/1.0.4.2
| 1.0.4.1 | [Deprecated]|
| 1.0.4 | [Deprecated]|
| 1.0.3.7 | https://www.nuget.org/packages/SuperConvert/1.0.3.7
| 1.0.3.6 | https://www.nuget.org/packages/SuperConvert/1.0.3.6
| 1.0.3.5 | https://www.nuget.org/packages/SuperConvert/1.0.3.5
| 1.0.3.4 | https://www.nuget.org/packages/SuperConvert/1.0.3.4
| 1.0.3.3 | https://www.nuget.org/packages/SuperConvert/1.0.3.3
| 1.0.3.2 | https://www.nuget.org/packages/SuperConvert/1.0.3.2
| 1.0.3.1 | [Deprecated] 
| 1.0.3 | https://www.nuget.org/packages/SuperConvert/1.0.3
| 1.0.2 | https://www.nuget.org/packages/SuperConvert/1.0.2
| 1.0.1 | https://www.nuget.org/packages/SuperConvert/1.0.1
| 1.0.0 | https://www.nuget.org/packages/SuperConvert/1.0.0
