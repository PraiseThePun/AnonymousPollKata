using NUnit.Framework;
using TextLoaderFactory;

namespace TextLoaderFactoryTest
{
    public class Tests
    {
        [Test]
        public void ReturnsTrueWhenStudentsAreEqual()
        {
            var student1 = new Student('M', 25, "Test Education", 1);
            var student2 = new Student('M', 25, "Test Education", 1);

            Assert.IsTrue(student1.Equals(student2));
        }

        [Test]
        public void ReturnsFalseWhenStudentsAreNotEqual()
        {
            var student1 = new Student('M', 25, "Test Education", 1);
            var student2 = new Student('F', 25, "Test Education", 1);

            Assert.IsFalse(student1.Equals(student2));
        }
    }
}