using System.Collections.Generic;

namespace TextLoaderFactory
{
    public class TextFileLoader
    {
		public virtual List<ReadableObject> LoadObjectsFromFile<T, U>(string fileToText, U parser)
			where T : ReadableObject
			where U : ObjectParser<T>
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
