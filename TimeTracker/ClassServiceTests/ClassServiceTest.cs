using System;
using NUnit.Framework;
using NSubstitute;

namespace ClassServiceTests
{
    [TestFixture]
    public class ClassServiceTest
    {
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        public void IsReturningModelWithIdIfModelIsFound(int number)
        {
            Assert.That(true, Is.EqualTo(false));
        }
    }
}
