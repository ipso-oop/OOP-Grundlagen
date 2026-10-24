using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uebung251;

namespace UnitTestUebung251
{
    [TestClass]
    public class ClassABC
    {
        [TestMethod]
        public void TestClassA()
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

            Assert.AreEqual(true, classA.Test);

        }
    }
}
