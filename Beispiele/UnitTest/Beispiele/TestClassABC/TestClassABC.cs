using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uebung251;

namespace TestClassABC
{
    [TestClass]
    public class TestClassABC
    {
        [TestMethod]
        public void TestMethodeClassABC()
        {
            ClassB classB = new ClassB();
            ClassA classA = new ClassA(classB);

            classB.functionB();

            classA.functionA();
            classA.functionC();

            Assert.IsNotNull(classA);

            Assert.IsNotNull(classB);

            Assert.IsNotNull(classA.classB);

            Assert.IsNotNull(classA.classD);

            Assert.AreEqual(false, classA.Test);
        }
    }
}
