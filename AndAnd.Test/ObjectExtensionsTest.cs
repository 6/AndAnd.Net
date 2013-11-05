using NUnit.Framework;

namespace AndAnd.Test
{
    [TestFixture]
    public class ObjectExtensionsTest
    {
        public interface ITestInterface
        {
            string TestMethod1();
            string TestMethod2();
        }

        public class TestClass : ITestInterface
        {
            public virtual string TestMethod1()
            {
                return null;
            }

            public virtual string TestMethod2()
            {
                return "non-null string";
            }
        }

        [Test]
        public void NullInterface()
        {
            ITestInterface testInterface = null;
            Assert.That(testInterface.AndAnd().TestMethod1(), Is.Null);
            Assert.That(testInterface.AndAnd().TestMethod2(), Is.Null);
        }

        [Test]
        public void NonNullInterface()
        {
            ITestInterface testInterface = new TestClass();
            Assert.That(testInterface.AndAnd().TestMethod1(), Is.Null);
            Assert.That(testInterface.AndAnd().TestMethod2(), Is.EqualTo("non-null string"));
        }

        [Test]
        public void NullClass()
        {
            TestClass testClass = null;
            Assert.That(testClass.AndAnd().TestMethod1(), Is.Null);
            Assert.That(testClass.AndAnd().TestMethod2(), Is.Null);
        }

        [Test]
        public void NonNullClass()
        {
            TestClass testClass = new TestClass();
            Assert.That(testClass.AndAnd().TestMethod1(), Is.Null);
            Assert.That(testClass.AndAnd().TestMethod2(), Is.EqualTo("non-null string"));
        }
    }
}
