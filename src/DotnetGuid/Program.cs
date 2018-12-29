using System;

using McMaster.Extensions.CommandLineUtils;

namespace DotnetGuid
{
    [Command(Name = "dotnet guid", Description = "Creates GUIDs/UUIDs.")]
    [HelpOption]
    public class Program
    {
        public static int Main(string[] args)
        {
            Console.CancelKeyPress += OnCancelKeyPress;

            return CommandLineApplication.Execute<GuidApp>(args);
        }

        private static void OnCancelKeyPress(
            object sender,
            ConsoleCancelEventArgs e)
        {
            Console.ResetColor();
        }
    }
}