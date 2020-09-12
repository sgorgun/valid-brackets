using System;
using NUnit.Framework;

namespace ValidBracketsTask.Tests
{
    [TestFixture]
    public class BracketsValidatorTests
    {
        [TestCase("{{   {", ExpectedResult = false)]
        [TestCase("[", ExpectedResult = false)]
        [TestCase("{432   34}Test [Test][Test Test)", ExpectedResult = false)]
        [TestCase("([([   {{ }}  ])])", ExpectedResult = true)]
        [TestCase("{abc  ([b ]a)}", ExpectedResult = true)]
        [TestCase("", ExpectedResult = true)]
        [TestCase("Test Test Test", ExpectedResult = true)]
        [TestCase("{abc   ([a{sas}b]a)}", ExpectedResult = true)]
        [TestCase("ab  c([b] a)}", ExpectedResult = false)]
        [TestCase("{abc(   [a{s  {as}b]a)}   }", ExpectedResult = false)]
        [TestCase("()", ExpectedResult = true)]
        [TestCase("(       )[  ]", ExpectedResult = true)]
        [TestCase("()[]{}", ExpectedResult = true)]
        [TestCase("[]  {}", ExpectedResult = true)]
        [TestCase("{}", ExpectedResult = true)]
        [TestCase("[]", ExpectedResult = true)]
        [TestCase("[{()}]", ExpectedResult = true)]
        [TestCase("(      {[ ]}    )", ExpectedResult = true)]
        [TestCase("(", ExpectedResult = false)]
        [TestCase(")", ExpectedResult = false)]
        [TestCase("[", ExpectedResult = false)]
        [TestCase("]", ExpectedResult = false)]
        [TestCase("{", ExpectedResult = false)]
        [TestCase("}", ExpectedResult = false)]
        [TestCase("}Test", ExpectedResult = false)]
        [TestCase("} ( )Test {", ExpectedResult = false)]
        public bool CheckValidBracketsTests(string input)
            => new BracketsValidator().IsValid(input);

        [Test]
        public void AreValidParentheses_StringIsNull_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new BracketsValidator().IsValid(null),
                "String cannot be null.");
    }
}