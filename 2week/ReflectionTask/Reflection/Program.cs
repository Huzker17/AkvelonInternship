using System;

namespace Documentation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Documentation of {typeof(VkApi).Name}");

            var specifier = new Specifier<VkApi>();
            var desc = specifier.GetApiDescription();
            var desc2 = specifier.GetApiMethodDescription("Authorize");
            var description = specifier.GetApiMethodDescription(Guid.NewGuid().ToString());
            var methodNames = specifier.GetApiMethodNames();
            var test = specifier.GetApiMethodParamDescription("Authorize", "allowNoname");
            foreach (var methodName in methodNames)
            {
                WriteWithColor($"{methodName}", ConsoleColor.Yellow);

                var methodDescription = specifier.GetApiMethodFullDescription(methodName);

                WriteWithColor($"\t{methodDescription.MethodDescription.Description}", ConsoleColor.DarkGreen);
                Console.WriteLine();

                WriteWithColor($"\tReturn", ConsoleColor.Green);
                WriteParamDescription(methodDescription.ReturnDescription);
                Console.WriteLine();

                WriteWithColor($"\tParameters", ConsoleColor.Green);
                foreach (var paramDescription in methodDescription.ParamDescriptions)
                {
                    WriteWithColor($"\t{paramDescription.ParamDescription.Name}", ConsoleColor.DarkYellow);
                    WriteParamDescription(paramDescription);
                    Console.WriteLine();
                }

                Console.WriteLine();
            }
        }

        private static void WriteParamDescription(ApiParamDescription description)
        {
            if (description == null)
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(description.ParamDescription?.Description))
            {
                WriteWithColor($"\t\t{description.ParamDescription?.Description}", ConsoleColor.DarkGreen);
            }

            WriteWithColor($"\t\tRequired - {description.Required}", ConsoleColor.DarkGreen);

            if (description.MinValue != null)
            {
                WriteWithColor($"\t\tMin - {description.MinValue}", ConsoleColor.DarkGreen);
            }

            if (description.MaxValue != null)
            {
                WriteWithColor($"\t\tMax - {description.MaxValue}", ConsoleColor.DarkGreen);
            }
        }

        private static void WriteWithColor(string line, ConsoleColor color, bool saveOldColor = true)
        {
            var oldColor = Console.ForegroundColor;

            Console.ForegroundColor = color;
            Console.WriteLine(line);

            if (saveOldColor)
            {
                Console.ForegroundColor = oldColor;
            }
        }
    }
}