using System;

namespace DotnetGuid
{
    internal static class GuidFormatterResolver
    {
        public static GuidFormatter GetFormatter(GuidApp app)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            return app switch
            {
                { FormatBase64: true } => GuidFormatter.CreateForBase64(trim: false),
                { FormatBase64Trimmed: true } => GuidFormatter.CreateForBase64(trim: true),
                { Format32Digits: true } => GuidFormatter.CreateForToString("N"),
                { Format32DigitsHyphens: true } => GuidFormatter.CreateForToString("D"),
                { Format32DigitsHyphensBraces: true } => GuidFormatter.CreateForToString("B"),
                { Format32DigitsHyphensParentheses: true } => GuidFormatter.CreateForToString("P"),
                { FormatHexadecimal: true } => GuidFormatter.CreateForToString("X"),
                _ => GuidFormatter.CreateDefault()
            };
        }
    }
}
