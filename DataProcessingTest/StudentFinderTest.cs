using System.Collections.Generic;
using System.Linq;
using AnonymusPollKata;
using DataProcessing;
using Moq;
using NUnit.Framework;
using TextProcessing.Interfaces;

namespace DataProcessingTest
{
	[TestFixture]
	public class StudentFinderTest
	{
		private StudentFinder studentFinder;
		private Mock<ITextFileLoader> textFileLoaderMock;

		[SetUp]
		public void SetUp()
		{
			textFileLoaderMock = new Mock<ITextFileLoader>(MockBehavior.Strict);

			var returnStudentsList = new List<Student>()
			{
				new Student()
				{
					Gender = 'F',
					Age = 20,
					Education = "Systems Engineering",
					AcademicYear = 2,
					Name = "Morgan Martinez Moore",
				},
				new Student()
				{
					Gender = 'M',
					Age = 18,
					Education = "Electrical Engineering",
					AcademicYear = 4,
					Name = "Mohammad Green Morales",
				},new Student()
				{
					Gender = 'M',
					Age = 18,
					Education = "Electrical Engineering",
					AcademicYear = 4,
					Name = "Oliver Carter Rivera",
				}
			};

			textFileLoaderMock.Setup(x => x.LoadStudentsFromFile()).Returns(returnStudentsList);
			studentFinder = new StudentFinder(textFileLoaderMock.Object);
		}

		[Test]
		public void ReturnsNullWhenNoCoincidences()
		{
			var studentToFind = new List<Student>() { new Student('M', 21, "Human Resources Management", 3) };
			var expected = Enumerable.Empty<string>();
			var actual = studentFinder.FindAll(studentToFind)[0];

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void ReturnsOneCoincidence()
		{
			const string EXPECTED = "Morgan Martinez Moore";
			var studentToFind = new List<Student>() { new Student('F', 20, "Systems Engineering", 2) };
			var actual = studentFinder.FindAll(studentToFind)[0];

			Assert.AreEqual(EXPECTED, actual.First());
		}

		[Test]
		public void ReturnsMoreThanOneCoincidence()
		{
			List<string> expected = new List<string>() { "Mohammad Green Morales", "Oliver Carter Rivera" };
			var studentsToFind = new List<Student>() { new Student('M', 18, "Electrical Engineering", 4) };
			var actual = studentFinder.FindAll(studentsToFind)[0];

			CollectionAssert.AreEqual(expected, actual);
		}
	}
}
