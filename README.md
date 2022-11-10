# dotnet-guid

.NET Tool for creating GUIDs/UUIDs.

The tool creates a single or multiple random GUIDs/UUIDs,
which can be formatted in multiple ways.

## Installation

Download the [latest version of .NET](https://dot.net).
Then install the [`dotnet-guid`](https://www.nuget.org/packages/dotnet-guid)
.NET Tool, using the command-line:

```
dotnet tool install -g dotnet-guid
```

## Usage

```
USAGE:
    dotnet-guid [count] [OPTIONS]

EXAMPLES:
    dotnet-guid 5 -f N
    dotnet-guid -f X -u
    dotnet-guid -f B64
    dotnet-guid -e

ARGUMENTS:
    [count]    Number of GUIDs/UUIDs to generate. Defaults to 1

OPTIONS:
    -h, --help         Prints help information
    -e, --empty        Uses empty, zero-value GUIDs/UUIDs only
    -l, --lowercase    Sets GUIDs/UUIDs to use lower-cased letters, where applicable
    -u, --uppercase    Sets GUIDs/UUIDs to use upper-cased letters, where applicable
    -f, --format       Sets the formatting of generated GUIDs/UUIDs
                       - B64: Base64 string (ABCDEfghij12345abcdefg)
                       - B64F: Base64 full string (ABCDEfghij12345abcdefg==)
                       - N: 32 digits (00000000000000000000000000000000)
                       - H: 32 digits separated by hyphens (00000000-0000-0000-0000-000000000000)
                       - HB: 32 digits separated by hyphens, enclosed in braces ({00000000-0000-0000-0000-000000000000})
                       - HP: 32 digits separated by hyphens, enclosed in parentheses
                       ((00000000-0000-0000-0000-000000000000))
                       - X: Four hexadecimal values enclosed in braces
                       ({0x00000000,0x0000,0x0000,{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00}})
```

### Examples

To get a single GUID/UUID, simply type:

```
dotnet-guid
```

To get 3 random GUIDs/UUIDs, with letters in upper-case, formatted with brackets:

```
dotnet-guid 3 -f H -u
```