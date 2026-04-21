# SuperConvert
## Make your data conversion simple

[![BuildStatus](https://img.shields.io/github/workflow/status/SDN-X/SuperConvert/Build%20and%20Test)](https://github.com/SDN-X/SuperConvert/actions)
[![codecov](https://codecov.io/gh/esamelzain/SuperConvert/branch/main/graph/badge.svg)](https://codecov.io/gh/esamelzain/SuperConvert)
[![License](https://img.shields.io/github/license/SDN-X/SuperConvert)](https://github.com/SDN-X/SuperConvert/blob/master/LICENSE.txt)

SuperConvert is a lightweight .NET library for converting between common data formats with a simple API.

## Packages

- `SuperConvert` (core conversions): [NuGet](https://www.nuget.org/packages/SuperConvert)
- `SuperConvert.Files` (file conversion helpers): [NuGet](https://www.nuget.org/packages/SuperConvert.Files)
- `SuperConvert.Abstraction` (DI-friendly service abstraction): [NuGet](https://www.nuget.org/packages/SuperConvert.Abstraction)

## What's new (SuperConvert)

### 1.0.5.2

- Updated NuGet package icon (`electric-generator.png`).

### 1.0.5.x

- Fixed CSV escaping/unescaping issue for quote characters (`"`).
- Export now escapes quotes as doubled quotes (`""`) in CSV fields.
- Import now correctly parses quoted values and restores escaped quotes.
- Added regression tests for CSV quote handling and quoted comma fields.

## Features

- JSON to `DataTable`
- `DataTable` to JSON
- JSON to CSV / CSV to JSON
- `DataTable` to CSV / CSV to `DataTable`
- JSON to XLS / `DataTable` to XLS
- Gregorian and Hijri date conversion
- String and file Base64 conversion helpers

## Target frameworks

Current package targets:

- `netcoreapp3.1`
- `net5.0`
- `net6.0`
- `net7.0`
- `net8.0`
- `net9.0`
- `net10.0`

## Installation

### Core package

```powershell
Install-Package SuperConvert -Version 1.0.5.2
```

### Files package

```powershell
Install-Package SuperConvert.Files -Version 1.0.4.0
```

### Abstraction package

```powershell
Install-Package SuperConvert.Abstraction -Version 1.0.0.4
```

## Usage

### Namespaces

```cs
using SuperConvert.Extensions;
using System.Data;
```

### JSON to DataTable

```cs
string customers = "[{\"CompanyID\":\"k123\",\"Role\":\"Admin\",\"Country\":\"UK\"}]";
DataTable dt = customers.ToDataTable("TableName");
```

### DataTable to JSON

```cs
string json = dt.ToJson();
```

### DataTable to CSV

```cs
string path = string.Empty;
string fileName = "DtToCsv";
string csvPath = dt.ToCsv(path, fileName);
```

### CSV to DataTable

```cs
DataTable csvDt = ExcelConverter.CsvToDataTable(csvPath);
```

### CSV quote behavior (example)

Input text:

```txt
The "elephant" in the room.
```

CSV field output:

```txt
"The ""elephant"" in the room."
```

Import returns:

```txt
The "elephant" in the room.
```

## Latest versions

| Package | Version | Link |
| ------  | ------- | ---- |
| SuperConvert | 1.0.5.2 | https://www.nuget.org/packages/SuperConvert/1.0.5.2 |
| SuperConvert.Files | 1.0.4.0 | https://www.nuget.org/packages/SuperConvert.Files |
| SuperConvert.Abstraction | 1.0.0.4 | https://www.nuget.org/packages/SuperConvert.Abstraction |
