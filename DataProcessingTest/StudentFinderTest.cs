using System.Collections.Generic;
using System.Linq;
using DataProcessing;
using Moq;
using NUnit.Framework;
using TextLoaderFactory;

namespace DataProcessingTest
{
	[TestFixture]
	public class StudentFinderTest
	{
		private StudentFinder studentFinder;
		private Mock<TextFileLoader> textLoaderMock;
		private StudentFactory studentFactoryMock;

		[SetUp]
		public void SetUp()
		{
			studentFinder = new StudentFinder(FileStore.Properties.Resources.Students);
			studentFactoryMock = new StudentFactory();
			textLoaderMock = new Mock<TextFileLoader>(MockBehavior.Strict);

			var returnStudentsList = new List<ReadableObject>()
			{
				new Student("Morgan Martinez Moore", 'F', 20, "Systems Engineering", 2),
				new Student("Mohammad Green Morales", 'M', 18,"Electrical Engineering",4),
				new Student("Oliver Carter Rivera", 'M', 18, "Electrical Engineering", 4)
			};

			textLoaderMock.Setup(x => x.LoadObjectsFromFile(It.IsAny<string>(), studentFactoryMock)).Returns(returnStudentsList);
		}

		[Test]
		public void ReturnsEmptyListWhenNoCoincidences()
		{
			var studentToFind = new List<Student>() { new Student('M', 21, "Human Resources Management", 3) };
			var expected = Enumerable.Empty<string>();
			var actual = studentFinder.FindAll(studentToFind)[1];

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void ReturnsOneCoincidence()
		{
			const string EXPECTED = "Morgan Martinez Moore";
			var studentToFind = new List<Student>() { new Student('F', 20, "Systems Engineering", 2) };
			var actual = studentFinder.FindAll(studentToFind)[1];

			Assert.AreEqual(EXPECTED, actual[0]);
		}

		[Test]
		public void ReturnsMoreThanOneCoincidence()
		{
			List<string> expected = new List<string>() { "Mohammad Green Morales", "Oliver Carter Rivera" };
			var studentsToFind = new List<Student>() { new Student('M', 18, "Electrical Engineering", 4) };
			var actual = studentFinder.FindAll(studentsToFind)[1];

			CollectionAssert.AreEqual(expected, actual);
		}
	}
}
