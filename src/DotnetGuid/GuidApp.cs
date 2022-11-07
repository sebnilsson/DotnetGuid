using System;
using System.Diagnostics;

using McMaster.Extensions.CommandLineUtils;

namespace DotnetGuid
{
    [Command(Name = "guid", Description = "Creates GUIDs/UUIDs.")]
    [HelpOption]
    public class GuidApp
    {
        [Argument(order: 0, Description = DescriptionTexts.Count)]
        public int Count { get; set; } = 1;

        [Option("-fb64", CommandOptionType.NoValue, Description = DescriptionTexts.FormatBase64)]
        public bool FormatBase64 { get; set; }

        [Option("-fb64f", CommandOptionType.NoValue, Description = DescriptionTexts.FormatBase64Full)]
        public bool FormatBase64Trimmed { get; set; }

        [Option("-fn", CommandOptionType.NoValue, Description = DescriptionTexts.Format32Digits)]
        public bool Format32Digits { get; set; }

        [Option("-fh", CommandOptionType.NoValue, Description = DescriptionTexts.Format32DigitsHyphens)]
        public bool Format32DigitsHyphens { get; set; }

        [Option("-fhb", CommandOptionType.NoValue, Description = DescriptionTexts.Format32DigitsHyphensBraces)]
        public bool Format32DigitsHyphensBraces { get; set; }

        [Option("-fhp", CommandOptionType.NoValue, Description = DescriptionTexts.Format32DigitsHyphensParentheses)]
        public bool Format32DigitsHyphensParentheses { get; set; }

        [Option("-fx", CommandOptionType.NoValue, Description = DescriptionTexts.FormatHexadecimal)]
        public bool FormatHexadecimal { get; set; }

        [Option("-e", CommandOptionType.NoValue, Description = DescriptionTexts.Empty)]
        public bool Empty { get; set; }

        [Option("-l", CommandOptionType.NoValue, Description = DescriptionTexts.LowerCase)]
        public bool LowerCase { get; set; }

        [Option("-u", CommandOptionType.NoValue, Description = DescriptionTexts.UpperCase)]
        public bool UpperCase { get; set; }

        private void OnExecute()
        {
            var guidGenerator = new GuidGenerator(this);

            foreach (var guid in guidGenerator.GenerateGuids())
            {
                Console.WriteLine(guid);
            }

            OnEnd();
        }

        private static void OnEnd()
        {
            if (Debugger.IsAttached)
            {
                Console.WriteLine();
                Console.WriteLine("Press any key to close application...");
                Console.ReadKey(intercept: true);
            }

            Console.ResetColor();
        }
    }
}
