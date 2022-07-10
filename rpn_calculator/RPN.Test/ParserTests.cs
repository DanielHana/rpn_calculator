using RPN.Service;

namespace RPN.Test
{
    public class ParserTests
    {
        [Test]
        public void IsSingleInteger_InputIs2_ReturnTrue()
        {
            var parser = new Parser();

            parser.Add("2");

            var topCharacter = parser.Characters.Pop();
            Assert.True(Double.Parse(topCharacter) == 2, "Parser should be able to handle single int");
        }

        [Test]
        public void IsSingleDeciaml_InputIs3_ReturnTrue()
        {
            var parser = new Parser();

            parser.Add("3.0");

            var topCharacter = parser.Characters.Pop();
            Assert.True(Double.Parse(topCharacter) == 3.0, "Parser should be able to handle single double");
        }

        [Test]
        public void FilterOutText_ReturnsTrue()
        {
            var parser = new Parser();

            parser.Add("3 aserfdas");

            var topCharacter = parser.Characters.Pop();
            Assert.True(Double.Parse(topCharacter) == 3, "Parser should be able to filter out basic text");
        }

        [Test]
        public void DetectsBasicInfix_ReturnsTrue()
        {
            var parser = new Parser();

            parser.Add("2 + 2");

            Assert.True(parser.Errors.Count > 0, "Parser should add an error if it detects Infix");
        }

        [Test]
        public void DetectsBasicInvalidOperand_ReturnsTrue()
        {
            var parser = new Parser();

            parser.Add("+");

            Assert.True(parser.Errors.Count > 0, "Parser should detect basic lack of operands and add an error");
        }

        [Test]
        public void DetectsNotEnoughOperands_ReturnsTrue()
        {
            var parser = new Parser();

            parser.Add("1 +");

            Assert.True(parser.Errors.Count > 0, "Parser should detect if it cannot perform an operation with the current amount of operands");
        }
    }
}