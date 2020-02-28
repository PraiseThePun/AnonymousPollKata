using AnonymusPollKata;
using System.Collections.Generic;
using TextProcessing.Interfaces;

namespace TextProcessing.Wrappers
{
	public class TextFileLoaderWrapper : ITextFileLoader
	{
		public List<Student> LoadStudentsFromFile()
		{
			return TextFileLoader.LoadStudentsFromFile();
		}
	}
}
