using RPN.Service;

namespace RPN.Test
{
    public class EvaluatorTests
    {
        [Test]
        public void BasicAddition_ReturnsTrue()
        {
            var parser = new Parser();
            var evaluator = new Evaluator();

            parser.Add("2 2 2 + +");

            double result = evaluator.Evaluate(parser.Characters);
            Assert.True(result == 6, "Evaluator should be able to handle basic addition");
        }

        [Test]
        public void BasicSubtraction_ReturnsTrue()
        {
            var parser = new Parser();
            var evaluator = new Evaluator();

            parser.Add("3 24 2 - -");

            double result = evaluator.Evaluate(parser.Characters);
            Assert.True(result == -19, "Evaluator should be able to handle basic subrtaction");
        }

        [Test]
        public void BasicMultipication_ReturnsTrue()
        {
            var parser = new Parser();
            var evaluator = new Evaluator();

            parser.Add("3 4 *");

            double result = evaluator.Evaluate(parser.Characters);
            Assert.True(result == 12, "Evaluator should be able to handle basic multipication");
        }

        [Test]
        public void BasicDivision_ReturnsTrue()
        {
            var parser = new Parser();
            var evaluator = new Evaluator();

            parser.Add("12 4 /");

            double result = evaluator.Evaluate(parser.Characters);
            Assert.True(result == 3, "Evaluator should be able to handle basic division");
        }

        [Test]
        public void MixedOperators_ReturnsTrue()
        {
            var parser = new Parser();
            var evaluator = new Evaluator();

            parser.Add("5 5 5 8 + + -");

            double result = evaluator.Evaluate(parser.Characters);
            Assert.True(result == -13, "Evaluator should be able to handle multiple operators at once");
        }

        [Test]
        public void PersistsAfterOperation_ReturnsTrue()
        {
            var parser = new Parser();
            var evaluator = new Evaluator();

            parser.Add("5 5 5 8 + + -");
            parser.Add(evaluator.Evaluate(parser.Characters).ToString());

            parser.Add("13 +");
            double result = evaluator.Evaluate(parser.Characters);
            Assert.True(result == 0, "Evaluator should be able to persist future values after an operation occurred");
        }

        [Test]
        public void PersistsMultiLine_ReturnsTrue()
        {
            var parser = new Parser();
            var evaluator = new Evaluator();

            parser.Add("5");
            parser.Add("9");
            parser.Add("1");
            parser.Add("-");
            parser.Add(evaluator.Evaluate(parser.Characters).ToString());
            parser.Add("/");

            double result = evaluator.Evaluate(parser.Characters);
            Assert.True(result == 0.625, "Evaluator should be able to persist values attained over multiple lines");
        }
    }
}
