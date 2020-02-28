using System.Text.RegularExpressions;

namespace TextProcessing
{
	public static class InputValidator
	{
		public static bool IsValidStudent(string rawStudentStr)
		{
			var match = Regex.Match(rawStudentStr, @"\w+(\s\w+){2,}\w+,(M|m|F|f),\d{1,2},\w+(\s\w+)?,[1-5]");

			return match.Success;
		}
	}
}
