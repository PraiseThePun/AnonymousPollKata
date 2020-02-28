using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextProcessing;

namespace TextProcessingTest
{
	[TestFixture]
	public class InputValidatorTest
	{
		[Test]
		public void ValidateValidStudent(
			[Values("F,20,Systems Engineering,2",
			"M,21,Human Resources Management,3",
			"M,20,Manufacturing Engineering,3")]
		string rawStudentStr)
		{
			Assert.IsTrue(InputValidator.IsValidStudent(rawStudentStr));
		}

		[Test]
		public void StudentIsNotValid(
			[Values("",
			"A,20,Systems Engineering,2",
			"F,20,Systems Engineering,6",
			"F,2,Systems Engineering,2")]
			string rawStudentStr)
		{
			Assert.IsFalse(InputValidator.IsValidStudent(rawStudentStr));
		}
	}
}
