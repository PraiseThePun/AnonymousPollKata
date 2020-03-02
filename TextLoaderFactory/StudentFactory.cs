using System;
using System.Text.RegularExpressions;

namespace TextLoaderFactory
{
    public class StudentFactory : ObjectParser<Student>
    {
        public override Student ReadToObject(string text)
        {
			var match = Regex.Match(text, @"(([^,]+),)?(M|m|F|f),(\d+),([^,]+),(\d+)");

			if (match.Success)
			{
				return !string.IsNullOrEmpty(match.Groups[1].Value)
					? new Student(match.Groups[2].Value,
						Convert.ToChar(match.Groups[3].Value),
						Convert.ToInt32(match.Groups[4].Value),
						match.Groups[5].Value,
						Convert.ToInt32(match.Groups[6].Value))
					: new Student(Convert.ToChar(match.Groups[3].Value),
						Convert.ToInt32(match.Groups[4].Value),
						match.Groups[5].Value,
						Convert.ToInt32(match.Groups[6].Value));
			}
			else
			{
				throw new ArgumentException("The student string is not properly formatted");
			}
		}
    }
}
