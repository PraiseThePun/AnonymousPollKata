using System;
using System.Text.RegularExpressions;

namespace TextLoaderFactory
{
    public class StudentFactory : ObjectParser
    {
        public override ReadableObject ReadToObject(string text)
        {
			var match = Regex.Match(text, @"([^,]+),(M|m|F|f),(\d+),([^,]+),(\d+)");

			if (match.Success)
			{
				return new Student(match.Groups[1].Value,
					Convert.ToChar(match.Groups[2].Value),
					Convert.ToInt32(match.Groups[3].Value),
					match.Groups[4].Value,
					Convert.ToInt32(match.Groups[5].Value));
			}
			else
			{
				match = Regex.Match(text, @"(M|m|F|f),(\d+),([^,]+),(\d+)");

				if (match.Success)
				{
					return new Student(Convert.ToChar(match.Groups[1].Value),
						Convert.ToInt32(match.Groups[2].Value),
						match.Groups[3].Value,
						Convert.ToInt32(match.Groups[4].Value));
				}
				else
				{
					throw new ArgumentException("The student string is not properly formatted");
				}
			}
		}
    }
}
