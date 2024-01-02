using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Spectre.Console.Cli;

namespace DotnetGuid
{
    public sealed class GuidCommand : Command<GuidCommand.Settings>
    {
        public override int Execute(
            [NotNull] CommandContext context,
            [NotNull] Settings settings)
        {
            var guidGenerator = new GuidGenerator(settings);

            var sb = new StringBuilder();

            foreach (var guid in guidGenerator.GenerateGuids())
            {
                Console.WriteLine(guid);

                if (settings.CopyToClipboard)
                {
                    sb.AppendLine(guid);
                }
            }

            if (settings.CopyToClipboard)
            {
                var guids = sb.ToString().TrimEnd();
                TextCopy.ClipboardService.SetText(guids);
            }

            OnEnd();

            return 0;
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

        public sealed class Settings : CommandSettings
        {
            [Description(DescriptionTexts.Count)]
            [DefaultValue(1)]
            [CommandArgument(0, "[count]")]
            public int Count { get; init; } = 1;

            [Description(DescriptionTexts.Empty)]
            [CommandOption("-e|--empty")]
            public bool Empty { get; init; }

            [Description(DescriptionTexts.LowerCase)]
            [CommandOption("-l|--lowercase")]
            public bool LowerCase { get; init; }

            [Description(DescriptionTexts.UpperCase)]
            [CommandOption("-u|--uppercase")]
            public bool UpperCase { get; init; }

            [Description(DescriptionTexts.Copy)]
            [CommandOption("-c|--copy")]
            public bool CopyToClipboard { get; init; }

            [Description(DescriptionTexts.Format)]
            [CommandOption("-f|--format")]
            public GuidFormat? Format { get; init; }

            public enum GuidFormat
            {
                B64,
                B64F,
                N,
                H,
                HB,
                HP,
                X
            }
        }
    }
}
