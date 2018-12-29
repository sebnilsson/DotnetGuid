using System;
using System.Diagnostics;

using McMaster.Extensions.CommandLineUtils;

namespace DotnetGuid
{
    public class GuidApp
    {
        [Argument(order: 0, Description = DescriptionTexts.Count)]
        public int Count { get; set; } = 1;

        [Option("-n", CommandOptionType.NoValue, Description = DescriptionTexts.Format32Digits)]
        public bool Format32Digits { get; set; }

        [Option("-d", CommandOptionType.NoValue, Description = DescriptionTexts.Format32DigitsHyphens)]
        public bool Format32DigitsHyphens { get; set; }

        [Option("-b", CommandOptionType.NoValue, Description = DescriptionTexts.Format32DigitsHyphensBraces)]
        public bool Format32DigitsHyphensBraces { get; set; }

        [Option("-p", CommandOptionType.NoValue, Description = DescriptionTexts.Format32DigitsHyphensParentheses)]
        public bool Format32DigitsHyphensParentheses { get; set; }

        [Option("-x", CommandOptionType.NoValue, Description = DescriptionTexts.FormatHexadecimal)]
        public bool FormatHexadecimal { get; set; }

        [Option("-e", CommandOptionType.NoValue, Description = DescriptionTexts.Empty)]
        public bool Empty { get; set; }

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