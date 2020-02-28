using AnonymusPollKata;
using System;

namespace TextProcessing
{
	public static class InputParser
	{
		public static Student ParseStudent(string rawStudentStr)
		{
			if (!InputValidator.IsValidStudent(rawStudentStr))
			{
				throw new ArgumentException("The student string is not properly formatted");
			}
			else
			{
				var splitText = rawStudentStr.Split(',');

				return new Student(Convert.ToChar(splitText[0]),
					Convert.ToInt32(splitText[1]),
					splitText[2],
					Convert.ToInt32(splitText[3]));
			}
		}

		public static Student ParseStudentWithName(string rawStudentStr)
		{
			var firstComaIndex = rawStudentStr.IndexOf(',');
			var student = ParseStudent(rawStudentStr.Substring(firstComaIndex + 1, rawStudentStr.Length - 1));
			student.Name = rawStudentStr.Substring(0, firstComaIndex);

			return student;
		}
	}
}
