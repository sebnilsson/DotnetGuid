using System;

namespace DotnetGuid
{
    internal static class GuidFormatResolver
    {
        public static string GetFormat(GuidApp app)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            return app switch
            {
                { Format32Digits: true } => "N",
                { Format32DigitsHyphens: true } => "D",
                { Format32DigitsHyphensBraces: true } => "B",
                { Format32DigitsHyphensParentheses: true } => "P",
                { FormatHexadecimal: true } => "X",
                _ => string.Empty
            };
        }
    }
}