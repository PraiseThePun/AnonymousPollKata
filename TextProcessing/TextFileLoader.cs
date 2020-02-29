using ObjectFactory;
using System.Collections.Generic;

namespace TextProcessing
{
	public class TextFileLoader<T, U> where T : IFactory<U>
	{
        private readonly T factory;

		public List<U> LoadObjectsFromFile(string fileToText)
		{
			var result = new List<U>();

			foreach (var line in fileToText.Split('\n'))
			{
				result.Add(factory.Parse(line));
			}

			return result;
		}
	}
}
