using AnonymusPollKata;
using System.Collections.Generic;

namespace TextProcessing
{
	public static class TextFileLoader
	{
		public static List<Student> LoadStudentsFromFile()
		{
			var fileToText = Properties.Resources.Students;
			var result = new List<Student>();

			foreach (var line in fileToText.Split('\n'))
			{
				result.Add(InputParser.ParseStudentWithName(line));
			}

			return result;
		}
	}
}
