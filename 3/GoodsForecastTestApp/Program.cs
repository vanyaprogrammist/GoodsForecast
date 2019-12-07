using System;
using System.Threading.Channels;

namespace GoodsForecastTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hi. I'm program for test question 3");
                Console.WriteLine("Blue balls count:");

                var blueBallsParse = 
                    int.TryParse(Console.ReadLine(), out int blueBallsCount);

                if (!blueBallsParse)
                {
                    throw new ApplicationException("Blue balls count can be integer");
                }
            
                Console.WriteLine("Red balls count:");

                var redBallsParse = 
                    int.TryParse(Console.ReadLine(), out int redBallsCount);

                if (!redBallsParse)
                {
                    throw new ApplicationException("Red balls can be integer");
                }
                
                //Количество вынимаемых шаров одного цвета
                Console.WriteLine("Output balls count:");

                var outputBallsParse = 
                    int.TryParse(Console.ReadLine(), out int outputBallsCount);

                if (!outputBallsParse)
                {
                    throw new ApplicationException("Output balls can be integer");
                }
            
                var calculator = new ProbabilityCalculator(blueBallsCount,redBallsCount,outputBallsCount);

                var result = calculator
                    .GetOutputCombination()
                    .GetBlueCombination()
                    .GetRedCombination()
                    .ResultProbability();

                Console.WriteLine($"Result probability: {result}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"EXCEPTION: {e.Message}");
            }
        }
    }
}