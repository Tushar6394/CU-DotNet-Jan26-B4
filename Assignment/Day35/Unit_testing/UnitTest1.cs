// unittesting 

using MyLibrary;
namespace MyLibraryTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            // to do before every test case


        }

        [TearDown]
        public void TearDown()
        {
            // to do after every test case
        }

        [Test]
        public void Test1()
        {
            // A Arrange
            MyMath math = new MyMath();
            int expected =22;
            int actual = 0;

            // A Act
            actual = math.GetSum(4, 5, 6, 7);

            // A Assert
            Assert.AreEqual(expected, actual);


            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            // A Arrange
            MyMath math = new MyMath();
            int expected = -3;
            int actual = 0;

            // A Act
            actual = math.GetSum(-1,-2);

            // A Assert
            Assert.AreEqual(expected, actual);


            Assert.Pass();
        }

        [TestCase(2,3,6)]
        [TestCase(1,3,3)]
        [TestCase(4,5,20)]
        public void TestMultiply(int n1, int n2, int expected)
        {
            // A Arrange
            MyMath math = new MyMath();

            int actual = 0;

            // A Act
            actual = math.GetMultiply(n1,n2);

            // A Assert
            Assert.AreEqual(expected, actual);


            Assert.Pass();
        }
    }
}