using AnonymusPollKata;
using System;
using System.Text.RegularExpressions;

namespace ObjectFactory
{
	public class StudentFactory : IFactory<Student>
	{
		public Student Parse(string rawString)
		{
			var match = Regex.Match(rawString, @"(M|m|F|f),(\d+),([^,]+),(\d+)");
			if (match.Success)
			{
				return new Student(Convert.ToChar(match.Captures[0]),
					Convert.ToInt32(match.Captures[1]),
					match.Captures[2].ToString(),
					Convert.ToInt32(match.Captures[3]));
			}
			else
			{
				throw new ArgumentException("The student string is not properly formatted");
			}
		}
	}
}
