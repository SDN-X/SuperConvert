# Super Convert
## _Make your data conversion_

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://github.com/esamelzain/SuperConvert)

SuperConvert is a tool to convert your data in c#
- Create some json strings / Data tables
- Convert between them
- ✨Magic ✨

## Features

- Convert Json to datatable
- Convert Datatable to json

## Coming soon !

- Excel sheets and other data containers/types

## Tech

SuperConvet's code is based on .net technology (>6)

- [.Net6] - C# !

- [GitHub Code](https://github.com/esamelzain/SuperConvert) - SuperConvert Project

## Installation


Run the command on your nuget package console .

```sh
Install-Package SuperConvert -Version 1.0.1
```
## Or 

Open your nuget package manager and type the name of 'SuperConvert' on the search

## Usage 
```cs
using SuperConvert.Extentions;
using System.Data;
internal class Program
{
    private static void Main(string[] args)
    {
        string customers = "[{\"CompanayID\":\"k123\",\"Role\":\"Admin\",\"Country\":\"UK\",\"Asset\":\"HD\",\"incident\":null},{\"CompanayID\":\"k234\",\"Role\":\"User\",\"Country\":\"US\",\"Asset\":\"HD12\",\"incident\":\"abc 1\"}]";
        
        /**********************************/
        ///Converting Json to DataTable ////
        /**********************************/
        DataTable dt = customers.ToDataTable("TableName");
        
        //Printing the Result
        foreach (DataRow row in dt.Rows)
        {
            foreach (DataColumn column in dt.Columns)
            {
                Console.Write($"{column.ColumnName} : {row[column.ColumnName]} \t");
            }
            Console.WriteLine("");
        }
        /**********************************/
        ///Converting DataTable to Json ////
        /**********************************/
        string json = dt.ToJson();
        
        Console.WriteLine($"\n Json: \n {json}");
    }
}
```
| Version | README |
| ------  | ------ |
| 1.0.0 | [https://www.nuget.org/packages/SuperConvert/]|
| 1.0.1 | [https://www.nuget.org/packages/SuperConvert/]|
