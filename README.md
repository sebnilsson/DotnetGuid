# dotnet-guid

.NET Core Global Tool for creating GUIDs/UUIDs.

The tool creates a single or multiple random GUIDs/UUIDs,
which can be formatted in multiple ways.

## Installation

Download the [.NET Core SDK 2.1](https://aka.ms/DotNetCore21) or later.
The install the [`dotnet-guid`](https://www.nuget.org/packages/dotnet-guid)
.NET Global Tool, using the command-line:

```
dotnet tool install -g dotnet-guid
```

## Usage

```
Usage: guid [arguments] [options]

Arguments:
  Count         Defines how may GUIDs/UUIDs to generate. Defaults to 1.

Options:
  -?|-h|--help  Show help information
  -n            Formatted as 32 digits:
                00000000000000000000000000000000
  -d            Formatted as 32 digits separated by hyphens:
                00000000-0000-0000-0000-000000000000
  -b            Formatted as 32 digits separated by hyphens, enclosed in braces:
                {00000000-0000-0000-0000-000000000000}
  -p            Formatted as 32 digits separated by hyphens, enclosed in parentheses:
                (00000000-0000-0000-0000-000000000000)
  -x            Formatted as four hexadecimal values enclosed in braces,
                where the fourth value is a subset of eight hexadecimal values that is also enclosed in braces:
                {0x00000000,0x0000,0x0000,{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00}}
  -e            Defines if the GUIDs/UUIDs should be empty, using zero-values only.
  -u            Defines if the GUIDs/UUIDs generated should be upper-cased letters.
```

### Examples

To get a single GUID/UUID, simply type:

```
guid
```

To get 3 random GUIDs/UUIDs, with letters in upper-case, formatted with brackets:

```
guid 3 -b -u
```