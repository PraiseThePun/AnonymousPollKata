using NUnit.Framework;
using System;
using TextLoaderFactory;

namespace TextLoaderFactoryTest
{
    [TestFixture]
    public class StudentFactoryTest
    {
        private StudentFactory studentFactory;

        [SetUp]
        public void SetUp()
        {
            studentFactory = new StudentFactory();
        }

        [Test]
        public void ReturnsStudentWithoutName([Values("M,25,Test Education,1")] string studentStr)
        {
            var expected = new Student('M', 25, "Test Education", 1);
            var actual = (Student)studentFactory.ReadToObject(studentStr);

            Assert.IsTrue(expected.Equals(actual));
        }

        [Test]
        public void ReturnsStudentWithName([Values("Test Student,M,25,Test Education,1")] string studentStr)
        {
            var expected = new Student("Test Student", 'M', 25, "Test Education", 1);
            var actual = (Student)studentFactory.ReadToObject(studentStr);

            Assert.IsTrue(expected.Equals(actual));
        }

        [Test]
        public void ThrowsExceptionWhenBadlyFormattedStudent([Values("")] string studentStr)
        {
            var ex = Assert.Throws<ArgumentException>(() => studentFactory.ReadToObject(studentStr));
            Assert.AreEqual("The student string is not properly formatted", ex.Message);
        }
    }
}
