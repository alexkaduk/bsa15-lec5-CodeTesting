using System;
using NUnit.Framework;

namespace BookHelper.Tests
{
    [TestFixture]
    public class PagesRangeTests
    {
        [Test]
        [TestCase(-5, 7)] // Documentation about TestCase attribute: http://www.nunit.org/index.php?p=testCase&r=2.5
        [TestCase(-7, -5)]
        [ExpectedException(typeof(ArgumentException))]
        public void Ctr_When_Negative_pages_passed_Then_throws_exception(int from, int to)
        {
            // Act
            new PagesRange(from, to);

            //Assert
           // Assert.Throws<ArgumentException>(() => new PagesRange(from, to));

        }

        // TODO 1: Write test that checks that "from" should be less or equal than "to". Fix the code if test fails.
        [Test]
        [TestCase(5, 2)] // Documentation about TestCase attribute: http://www.nunit.org/index.php?p=testCase&r=2.5
        [TestCase(5, 5)]
        //[ExpectedException(typeof(ArgumentException))]
        public void Ctr_When_from_greater_or_non_equal_than_to_Then_throws_exception(int from, int to)
        {
            //Assert
            Assert.Throws<ArgumentException>(() => new PagesRange(from, to));
        }

    }
}