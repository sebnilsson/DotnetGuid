namespace DotnetGuid
{
    internal static class DescriptionTexts
    {
        public const string Count = "Number of GUIDs/UUIDs to generate. Defaults to 1.";

        public const string Empty = "Uses empty, zero-value GUIDs/UUIDs only.";

        public const string LowerCase = "Sets GUIDs/UUIDs to use lower-cased letters, where applicable.";

        public const string UpperCase = "Sets GUIDs/UUIDs to use upper-cased letters, where applicable.";

        public const string Format =
            $"Sets the formatting of generated GUIDs/UUIDs\r\n"
            + $"- {nameof(GuidCommand.Settings.GuidFormat.B64)}: Base64 string (ABCDEfghij12345abcdefg)\r\n"
            + $"- {nameof(GuidCommand.Settings.GuidFormat.B64F)}: Base64 full string (ABCDEfghij12345abcdefg==)\r\n"
            + $"- {nameof(GuidCommand.Settings.GuidFormat.N)}: 32 digits (00000000000000000000000000000000)\r\n"
            + $"- {nameof(GuidCommand.Settings.GuidFormat.H)}: 32 digits separated by hyphens (00000000-0000-0000-0000-000000000000)\r\n"
            + $"- {nameof(GuidCommand.Settings.GuidFormat.HB)}: 32 digits separated by hyphens, enclosed in braces ({{00000000-0000-0000-0000-000000000000}})\r\n"
            + $"- {nameof(GuidCommand.Settings.GuidFormat.HP)}: 32 digits separated by hyphens, enclosed in parentheses ((00000000-0000-0000-0000-000000000000))\r\n"
            + $"- {nameof(GuidCommand.Settings.GuidFormat.X)}: Four hexadecimal values enclosed in braces ({{0x00000000,0x0000,0x0000,{{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00}}}})";
    }
}
