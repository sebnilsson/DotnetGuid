using System;
using System.Diagnostics;

using McMaster.Extensions.CommandLineUtils;

namespace DotnetGuid
{
    [Command(Name = "dotnet guid", Description = "Creates GUIDs/UUIDs.")]
    [HelpOption]
    public class Program
    {
        private static readonly Func<Guid> GuidFactory = () => Guid.NewGuid();

        private static readonly Func<Guid> EmptyGuidFactory = () => Guid.Empty;

        public static int Main(string[] args)
        {
            Console.CancelKeyPress += OnCancelKeyPress;

            return CommandLineApplication.Execute<Program>(args);
        }

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
            var factory = !Empty ? GuidFactory : EmptyGuidFactory;

            var format = GetFormat();

            for (int i = 0; i < Count; i++)
            {
                GenerateGuid(factory, format);
            }

            OnEnd();
        }

        private void GenerateGuid(Func<Guid> factory, string format)
        {
            var guid = factory();

            var result = guid.ToString(format);

            result = UpperCase ? result.ToUpperInvariant() : result;

            Console.WriteLine(result);
        }

        private string GetFormat()
        {
            if (Format32Digits)
            {
                return "N";
            }
            if (Format32DigitsHyphens)
            {
                return "D";
            }
            if (Format32DigitsHyphensBraces)
            {
                return "B";
            }
            if (Format32DigitsHyphensParentheses)
            {
                return "P";
            }
            if (FormatHexadecimal)
            {
                return "X";
            }
            return null;
        }

        private static void OnCancelKeyPress(
            object sender,
            ConsoleCancelEventArgs e)
        {
            Console.ResetColor();
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