using System.Collections.Generic;

namespace TextLoaderFactory
{
    public class TextFileLoader
    {
		public virtual List<ReadableObject> LoadObjectsFromFile<T>(string fileToText, T parser) where T : ObjectParser
		{
			var result = new List<ReadableObject>();

			foreach (var line in fileToText.Split('\n'))
			{
				result.Add(parser.ReadToObject(line));
			}

			return result;
		}
	}
}
