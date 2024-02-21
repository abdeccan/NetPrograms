using NUnit.Framework;

namespace TestProject1
{
    public class SampleTest
    {
       

        [SetUp]
        public void Setup()
        {
        }

        [TestCase(50)]
        [TestCase(100)]
        [Test]
        public void PassingTest(int marks)
        {
        }


        [TestCase(30)]
        [TestCase(39)]
        [Test]
        public void FailingTest(int marks)
        {
            
        }
    }
}