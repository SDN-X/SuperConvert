# SuperConvert.Abstraction Documentation

## Introduction

SuperConvert.Abstraction is a powerful library that provides data conversion functionalities for your .NET applications. With this library, you can easily convert between different data formats, such as JSON, CSV, and XLS, using a simple and intuitive API. The library also introduces a new Dependency Injection (DI) service to streamline the usage of its features.

## Getting Started

To get started with SuperConvert.Abstraction, follow these steps:

1. Install the NuGet package:
`Install-Package SuperConvert.Abstraction -Version 1.0.0`


2. Register the `ISuperConvertExcelService` in the DI container using the `UseSuperConvertExcelService` extension method:

`services.UseSuperConvertExcelService();`


3. Inject the **ISuperConvertExcelService** into your classes where you need to perform data conversion operations.

**ISuperConvertExcelService Interface**

The **ISuperConvertExcelService** interface provides various methods for data conversion. Here are some of the methods available:

- **DataTableToCsv**: Converts a DataTable to CSV format.
- **JsonToCsv**: Converts JSON data to CSV format.
- **CsvToJson**: Converts CSV data to JSON format.
- **CsvToDataTable**: Converts CSV data to a DataTable.
- **JsonToXls**: Converts JSON data to XLS format.
- **DataTableToXls**: Converts a DataTable to XLS format.

**Example Usage**

 ```cs
public class MyService
 {
	private readonly ISuperConvertExcelService _excelService;
	public MyService(ISuperConvertExcelService excelService)
	{
		_excelService = excelService;
	}
	public void ConvertDataTableToCsv(DataTable dataTable)
	{
		string csv = _excelService.DataTableToCsv(dataTable);
		// Use the CSV data as needed
	}
	public void ConvertJsonToXls(string jsonData)
	{
		string xlsPath = _excelService.JsonToXls(jsonData, "path", "filename");
		// Use the path of the XLS file as needed
	}
 }
```

**Next Version: SuperConvert.Abstraction**

In the next version of SuperConvert, the **SuperConvert.Abstraction** library will be introduced to provide a more flexible and modular approach to data conversion. This library will build upon the **ISuperConvertExcelService** interface and offer additional features and extensibility options.

Stay tuned for more updates and enhancements coming in the next version!

**Conclusion**

SuperConvert.Abstraction is a versatile library that simplifies data conversion tasks and enhances your .NET applications. By leveraging the Dependency Injection service and the **ISuperConvertExcelService** interface, you can seamlessly integrate data conversion capabilities into your projects. Get started today and experience the benefits of effortless data conversion!

For more details, check out the [SuperConvert.Abstraction GitHub repository](https://github.com/SDN-X/SuperConvert).

Happy coding!
