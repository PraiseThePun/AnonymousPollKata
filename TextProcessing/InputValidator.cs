using System.Text.RegularExpressions;

namespace TextProcessing
{
	public static class InputValidator
	{
		public static bool IsValidStudent(string rawStudentStr)
		{
			var match = Regex.Match(rawStudentStr, @"(M|m|F|f),\d{1,2},\w+(\s\w+){0,},[1-5]");

			return match.Success;
		}
	}
}
