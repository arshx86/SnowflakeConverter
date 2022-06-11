using System;
using System.Globalization;

namespace SnowflakeConverter
{
    internal class Program
    {

        const long DISCORD_EPOCH = 1420070400000;
        static void Main(string[] args)
        {

            // Support ARGS
            if (args is { Length: > 0 })
            {
                if (!long.TryParse(args[0], out long snowflake))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("> Invalid format! please paste an ID.");
                    return;
                }
                long unixMS = ToUnix(snowflake);
                var DateTime = ToDateTime(unixMS);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("---------------------------------------------------------------\n" +
                                  $"& Unix Milli Seconds > {unixMS}\n" +
                                  $"& Date > {DateTime.LocalDateTime}\n" +
                                  $"& Localized Date > {DateTime.LocalDateTime.ToLongDateString()}\n" +
                                  "---------------------------------------------------------------\n");
                return;
            }

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            Console.Title = "SnowflakeConverter";
            Console.WriteLine("> Input Message, Server, User ID (Snowflake)\n");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                string input = Console.ReadLine();
                if (!long.TryParse(input, out long snowflake))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("> Invalid format! please paste an ID.");
                    Console.ReadKey();
                    Main(null);
                }

                long unixMS = ToUnix(snowflake);
                var DateTime = ToDateTime(unixMS);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("---------------------------------------------------------------\n" +
                                  $"& Unix Milli Seconds > {unixMS}\n" +
                                  $"& Date > {DateTime.LocalDateTime}\n" +
                                  $"& Localized Date > {DateTime.LocalDateTime.ToLongDateString()}\n" +
                                  "---------------------------------------------------------------\n");
                Console.ResetColor();
            }

        }

        /// <summary>
        ///  Converts Unix milli seconds into datetime.
        /// </summary>
        /// <param name="unixMilliSeconds">unixMS to convert.</param>
        /// <returns>DateTimeOffset object converted from unixMS.</returns>
        static DateTimeOffset ToDateTime(long unixMilliSeconds)
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(unixMilliSeconds);
        }

        /// <summary>
        ///  Converts snowflake object into unix milli seconds with discord epoch.
        /// </summary>
        /// <param name="Snowflake">Snowflake long to convert.</param>
        /// <returns>UnixMS converted from snowflake object.</returns>
        static long ToUnix(long Snowflake)
        {
            return (Snowflake >> 22) + DISCORD_EPOCH;
        }

    }
}