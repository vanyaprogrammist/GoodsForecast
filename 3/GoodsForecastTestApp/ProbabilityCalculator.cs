using System;

namespace GoodsForecastTestApp
{
    public class ProbabilityCalculator
    {
        private readonly int _blueBallsCount;

        private readonly int _redBallsCount;

        private readonly int _outputBallsCount;

        private double _allOutputCombination;

        private double _blueBallsCombination;

        private double _redBallsCombination;

        public ProbabilityCalculator(int blueBallsCount, int redBallsCount, int outputBallsCount)
        {
            _blueBallsCount = blueBallsCount;
            _redBallsCount = redBallsCount;
            _outputBallsCount = outputBallsCount;
        }

        public ProbabilityCalculator GetOutputCombination()
        {
            int allBallsCount = _redBallsCount + _blueBallsCount;

            if (_outputBallsCount <= 0)
            {
                throw new ApplicationException("Out put balls count can > 0");
            }

            if (_outputBallsCount > allBallsCount)
            {
                throw new ApplicationException("Output balls count can < all balls count");
            }

            _allOutputCombination = CombinationFunc(_outputBallsCount, allBallsCount);

            return this;
        }
        
        public ProbabilityCalculator GetBlueCombination()
        {
            if (_blueBallsCount <= 0)
            {
                throw new ApplicationException("Blue balls count can > 0");
            }

            if (_outputBallsCount > _blueBallsCount)
            {
                throw new ApplicationException("Output balls count can < blue balls count");
            }

            _blueBallsCombination = CombinationFunc(_outputBallsCount, _blueBallsCount);

            return this;
        }

        public ProbabilityCalculator GetRedCombination()
        {
            if (_redBallsCount <= 0)
            {
                throw new ApplicationException("Red balls count can > 0");
            }

            if (_outputBallsCount > _redBallsCount)
            {
                throw new ApplicationException("Output balls count can < red balls count");
            }

            _redBallsCombination = CombinationFunc(_outputBallsCount, _redBallsCount);

            return this;
        }

        public double ResultProbability()
        {
            return (_redBallsCombination / _allOutputCombination) + (_blueBallsCombination / _allOutputCombination); 
        }

        private double CombinationFunc(int count, int from)
            => Factorial(from) / Factorial(from - count) * Factorial(count);

        private double Factorial(int number)
        {
            if (number == 1)
            {
                return 1;
            }

            return number * Factorial(number - 1);
        }
    }
}