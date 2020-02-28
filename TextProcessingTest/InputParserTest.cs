using AnonymusPollKata;
using NUnit.Framework;
using System;
using System.Collections.Generic;
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

		[Test]
		public void ParseCaseNumberSuceeds([Values("1", "50", "100")] string casesStr)
		{
			var numbers = new List<int>() { 1, 50, 100 };
			CollectionAssert.Contains(numbers, InputParser.ParseCasesNumber(casesStr));
		}

		[Test]
		public void ParseCaseNumberIsOutsideTheValidRange([Values("0", "101")] string casesStr)
		{
			var ex = Assert.Throws<ArgumentException>(() => InputParser.ParseCasesNumber(casesStr));
			Assert.AreEqual(ex.Message, "The number of students to look up has to be between 1 and 100");
		}

		[Test]
		public void ParseCaseNumberIsNotADigitCaracter([Values("a")] string casesStr)
		{
			var ex = Assert.Throws<ArgumentException>(() => InputParser.ParseCasesNumber(casesStr));
			Assert.AreEqual(ex.Message, "Input has to be a valid digit character");
		}
	}
}
