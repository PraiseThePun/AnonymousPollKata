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
