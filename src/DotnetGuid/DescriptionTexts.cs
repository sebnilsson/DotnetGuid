namespace DotnetGuid
{
    internal static class DescriptionTexts
    {
        public const string Count = "Defines how may GUIDs/UUIDs to generate. Defaults to 1.";

        public const string Empty = "Defines if the GUIDs/UUIDs should be empty, using zero-values only.";

        public const string LowerCase = "Defines if the GUIDs/UUIDs generated should be lower-cased letters.";

        public const string UpperCase = "Defines if the GUIDs/UUIDs generated should be upper-cased letters.";

        public const string FormatBase64 = "Formatted as Base64 string, with trimmed trailing equal signs:\r\nABCDEfghij12345abcdefg";

        public const string FormatBase64Full = "Formatted as full Base64 string:\r\nABCDEfghij12345abcdefg==";

        public const string Format32Digits = "Formatted as 32 digits:\r\n00000000000000000000000000000000";

        public const string Format32DigitsHyphens = "Formatted as 32 digits separated by hyphens:\r\n00000000-0000-0000-0000-000000000000";

        public const string Format32DigitsHyphensBraces = "Formatted as 32 digits separated by hyphens, enclosed in braces:\r\n{00000000-0000-0000-0000-000000000000}";

        public const string Format32DigitsHyphensParentheses = "Formatted as 32 digits separated by hyphens, enclosed in parentheses:\r\n(00000000-0000-0000-0000-000000000000)";

        public const string FormatHexadecimal = "Formatted as four hexadecimal values enclosed in braces,\r\nwhere the fourth value is a subset of eight hexadecimal values that is also enclosed in braces:\r\n{0x00000000,0x0000,0x0000,{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00}}";
    }
}
