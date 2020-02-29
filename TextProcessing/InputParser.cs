using System;

namespace TextProcessing
{
	public static class InputParser
	{
		public static int ParseCasesNumber(string casesIteration)
		{
			if (!int.TryParse(casesIteration, out int result))
			{
				throw new ArgumentException("Input has to be a valid digit character");
			}
			else if (!IsValidCaseNumber(result))
			{
				throw new ArgumentException("The number of students to look up has to be between 1 and 100");
			}

			return result;
		}

		private static bool IsValidCaseNumber(int number)
		{
			return number <= 100 && number >= 1;
		}
	}
}
