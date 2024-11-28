namespace DotnetGuid;

internal static class DescriptionTexts
{
    public const string Count = "Number of GUIDs/UUIDs to generate. Defaults to 1.";

    public const string Empty = "Uses empty, zero-value GUIDs/UUIDs only.";

    public const string LowerCase = "Sets GUIDs/UUIDs to use lower-cased letters, where applicable.";

    public const string Parse = "Provides a GUID/UUID string to be used and showed.";

    public const string UpperCase = "Sets GUIDs/UUIDs to use upper-cased letters, where applicable.";

#if NET9_0_OR_GREATER
    public const string Version7 = "Uses version 7 of GUID/UUID. Only in .NET 9 and newer.";

    public const string Version7Timestamp = "Seeds the version 7 of the GUID/UUID generated with a timestamp. Only in .NET 9 and newer.";
#endif

    public const string Format =
        $"Sets the output formatting of generated GUIDs/UUIDs\r\n"
        + $"- {nameof(GuidCommandSettings.GuidFormat.B64)}: Base64 string \"ABCDEfghij12345abcdefg\"\r\n"
        + $"- {nameof(GuidCommandSettings.GuidFormat.B64F)}: Base64 full string \"ABCDEfghij12345abcdefg==\"\r\n"
        + $"- {nameof(GuidCommandSettings.GuidFormat.N)}: 32 digits \"12345678abcd1234abcd123456789012\"\r\n"
        + $"- {nameof(GuidCommandSettings.GuidFormat.H)}: 32 digits separated by hyphens \"12345678-abcd-1234-abcd-123456789012\"\r\n"
        + $"- {nameof(GuidCommandSettings.GuidFormat.HB)}: 32 digits separated by hyphens, enclosed in braces \"{{12345678-abcd-1234-abcd-123456789012}}\"\r\n"
        + $"- {nameof(GuidCommandSettings.GuidFormat.HP)}: 32 digits separated by hyphens, enclosed in parentheses \"(12345678-abcd-1234-abcd-123456789012)\"\r\n"
        + $"- {nameof(GuidCommandSettings.GuidFormat.X)}: Four hexadecimal values enclosed in braces \"{{0x12345678,0xabcd,0x1234,{{0xab,0xcd,0x12,0x34,0x56,0x78,0x90,0x12}}}}\"";
}
