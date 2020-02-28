using AnonymusPollKata;
using System.Collections.Generic;

namespace TextProcessing.Interfaces
{
	public interface ITextFileLoader
	{
		List<Student> LoadStudentsFromFile();
	}
}
