using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Spectre.Console.Cli;

namespace DotnetGuid;

public class GuidCommand : Command<GuidCommandSettings>
{
    protected override int Execute(
        [NotNull] CommandContext context,
        [NotNull] GuidCommandSettings settings,
        CancellationToken cancellationToken)
    {
        var guidGenerator = new GuidGenerator(settings);

        foreach (var guid in guidGenerator.GenerateGuids())
        {
            Console.WriteLine(guid);
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
}
