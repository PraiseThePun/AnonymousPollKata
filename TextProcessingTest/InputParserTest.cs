using AnonymusPollKata;
using NUnit.Framework;
using System;
using TextProcessing;

namespace TextProcessingTest
{
	[TestFixture]
	public class InputParserTest
	{
		[Test]
		public void ParseStudent([Values("M,21,Human Resources Management,3")] string rawStudenStr)
		{
			var expected = new Student('M', 21, "Human Resources Management", 3);
			var actual = InputParser.ParseStudent(rawStudenStr);

			Assert.IsTrue(expected.Equals(actual));
		}

		[Test]
		public void ParseStudentWithName([Values("Morgan Martinez Moore,F,20,Systems Engineering,2") ] string rawStudentStr)
		{
			var expected = new Student()
			{
				Name = "Morgan Martinez Moore",
				AcademicYear = 2,
				Age = 20,
				Education = "Systems Engineering",
				Gender = 'F'
			};

			var actual = InputParser.ParseStudentWithName(rawStudentStr);

			Assert.IsTrue(expected.Equals(actual));
		}

		[Test]
		public void ParseStudentFailsWhenStudentStringIsNotCorrectlyFormatted([Values("")] string rawStudentStr)
		{
			var ex = Assert.Throws<ArgumentException>(() => InputParser.ParseStudent(rawStudentStr));
			Assert.AreEqual(ex.Message, "The student string is not properly formatted");
		}
	}
}
