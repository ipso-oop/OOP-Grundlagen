using Konto;

namespace TestSparkonto
{
    [TestClass]
    public class UnitTestSparkonto
    {
        [TestMethod]
        public void TestSparkonto()
        {
            Sparkonto konto = new Sparkonto("60-5678-00", 5);
            Assert.IsNotNull(konto);
            Assert.AreEqual("60-5678-00",konto.gibKontoNummer());
            konto.einzahlen(1000);
            Assert.AreEqual(1000, konto.gibKontoStand());
            konto.abheben(500);
            Assert.AreEqual(500,konto.gibKontoStand());
            konto.saldieren();
            Assert.AreEqual(525, konto.gibKontoStand());
        }
    }
}