using System;

namespace FlattenArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var utility = new Utility();
            var flatten = new Flattener(utility);

            while (true)
            {
                Console.WriteLine("Enter array:");

                string line = Console.ReadLine();
                if (line == "exit")
                {
                    break;
                }
                var flattenedOutput = flatten.FlattenJSONString(line);

                if (flattenedOutput.Contains("invalid"))
                    Console.WriteLine("Invalid Array Entered");
                else
                {
                    var output = utility.CommaSeparatedToJSONArray(flattenedOutput);
                    Console.WriteLine(output);
                }
            }

        }
    }
}
