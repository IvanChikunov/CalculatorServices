using calculator_back.Services;

namespace Calculator_back.Tests
{
    public class CalculatorsTest
    {
        [Fact]
        public void CheckCalculators()
        {
            CustomCalculator calculator = new CustomCalculator();
            MathJSCalculator mathjsCalculator = new MathJSCalculator();
            WolframCalculator wolframCalculator = new WolframCalculator();

            string expresionTest = "(65-(3+12*(8-9))+3)";

            Assert.Equal("77", calculator.Calculate(expresionTest));
            Assert.Equal("77", mathjsCalculator.Calculate(expresionTest));
            Assert.Equal("77", wolframCalculator.Calculate(expresionTest));
        }
    }
}