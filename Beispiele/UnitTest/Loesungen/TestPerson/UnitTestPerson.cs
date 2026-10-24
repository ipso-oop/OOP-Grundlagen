using UebungPerson;

namespace TestPerson
{
    [TestClass]
    public class UnitTestPerson
    {
        [TestMethod]
        public void TestPerson()
        {
            Privatkunde kunde = new Privatkunde();

            Gebaeude gebaeude = new Gebaeude();

            Student student = new Student("Roman");

            Vorlesung vorlesung = new Vorlesung(student);

            WaermeSensor waermesensor = new WaermeSensor();

            Assert.IsNotNull(kunde);

            Assert.IsNotNull(gebaeude);

            Assert.IsNotNull(student);

            Assert.IsNotNull(waermesensor);

        }
    }
}