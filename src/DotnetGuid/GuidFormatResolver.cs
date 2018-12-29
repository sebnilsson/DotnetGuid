using System;

namespace DotnetGuid
{
    internal static class GuidFormatResolver
    {
        public static string GetFormat(GuidApp app)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            if (app.Format32Digits)
            {
                return "N";
            }
            if (app.Format32DigitsHyphens)
            {
                return "D";
            }
            if (app.Format32DigitsHyphensBraces)
            {
                return "B";
            }
            if (app.Format32DigitsHyphensParentheses)
            {
                return "P";
            }
            if (app.FormatHexadecimal)
            {
                return "X";
            }
            return null;
        }
    }
}