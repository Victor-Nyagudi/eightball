using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightBallProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var eightball = new EightBall();

            while (true)
            {
                Console.WriteLine("Ask 8-Ball a question.");

                var input = Console.ReadLine();

                var answer = eightball.Ask(input);

                if (input.ToLower() == "add")
                {
                    Console.WriteLine($"\nPlease add a response.\nNumber of responses you can add: {eightball.CustomResponseLimit}");

                    var customResponse = Console.ReadLine();

                    var outcome = eightball.AddResponse(customResponse);

                    Console.WriteLine($"\n{outcome}\n");
                }

                else if (input.ToLower() == "responses")
                {
                    var customResponseCount = eightball.Responses.Count - 10;

                    Console.WriteLine($"\nThere are currently {eightball.Responses.Count - customResponseCount} default responses, " +
                        $"{customResponseCount} custom response(s):\n");

                    foreach (var response in eightball.Responses)
                    {
                        if (eightball.Responses.IndexOf(response) > 9)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                        }

                        Console.WriteLine(response);
                        Console.ResetColor();
                    }

                    Console.WriteLine();
                }

                else if (input.ToLower() == "remove")
                {
                    Console.WriteLine("\nType the number of the response to remove.\nNote: Only custom responses can be removed!\n");

                    foreach (var response in eightball.Responses)
                    {
                        if (eightball.Responses.IndexOf(response) > 9)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                        }

                        Console.WriteLine($"{response} ({eightball.Responses.IndexOf(response)})");
                        Console.ResetColor();
                    }

                    var index = Convert.ToInt32(Console.ReadLine());

                    var outcome = eightball.RemoveResponse(index);

                    Console.WriteLine($"\n{outcome}\n");
                }

                else
                {
                    Console.WriteLine($"\n{answer}\n");
                }
            }
        }
    }
}
