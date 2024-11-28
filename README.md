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
    dotnet guid [count] [OPTIONS]

EXAMPLES:
    dotnet guid 5 -f N
    dotnet guid -f X -u
    dotnet guid -f B64
    dotnet guid -e
    dotbet guid --v7

ARGUMENTS:
    [count]    Number of GUIDs/UUIDs to generate. Defaults to 1

OPTIONS:
    -h, --help            Prints help information
    -e, --empty           Uses empty, zero-value GUIDs/UUIDs only
    -l, --lowercase       Sets GUIDs/UUIDs to use lower-cased letters, where applicable
    -p, --parse           Provides a GUID/UUID string to be used and showed
    -u, --uppercase       Sets GUIDs/UUIDs to use upper-cased letters, where applicable
        --v7              Uses version 7 of GUID/UUID. Only in .NET 9 and newer
        --v7-timestamp    Seeds the version 7 of the GUID/UUID generated with a timestamp. Only in .NET 9 and newer
    -f, --format          Sets the output formatting of generated GUIDs/UUIDs
                          - B64: Base64 string "ABCDEfghij12345abcdefg"
                          - B64F: Base64 full string "ABCDEfghij12345abcdefg=="
                          - N: 32 digits "12345678abcd1234abcd123456789012"
                          - H: 32 digits separated by hyphens "12345678-abcd-1234-abcd-123456789012"
                          - HB: 32 digits separated by hyphens, enclosed in braces
                          "{12345678-abcd-1234-abcd-123456789012}"
                          - HP: 32 digits separated by hyphens, enclosed in parentheses
                          "(12345678-abcd-1234-abcd-123456789012)"
                          - X: Four hexadecimal values enclosed in braces
                          "{0x12345678,0xabcd,0x1234,{0xab,0xcd,0x12,0x34,0x56,0x78,0x90,0x12}}"
```

### Examples

To get a single GUID/UUID, simply type:

```
dotnet guid
```

To get 3 random GUIDs/UUIDs, with letters in upper-case, formatted with brackets:

```
dotnet guid 3 -f H -u
```