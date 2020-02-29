using AnonymusPollKata;
using System.Collections.Generic;
using System.Linq;

using StudentTextFileLoader = TextProcessing.TextFileLoader<ObjectFactory.StudentFactory, AnonymusPollKata.Student>;

namespace DataProcessing
{
    public class StudentFinder
    {
        private readonly StudentTextFileLoader textFileLoader;
        private static List<Student> studentDictionary;

        public StudentFinder()
        {
            studentDictionary = textFileLoader.LoadObjectsFromFile(StudentRepository.Properties.Resources.Students);
        }

        private IEnumerable<string> Find(Student studentToFind)
        {
            return from studentDict in studentDictionary
                         where studentDict.Equals(studentToFind)
                         select studentDict.Name;
        }

        public IDictionary<int, List<string>> FindAll(IEnumerable<Student> studentToFind)
        {
            var result = new Dictionary<int, List<string>>();

            for (int i = 1; i <= studentToFind.Count(); i++)
            {
                result.Add(i, Find(studentToFind.ElementAt(i - 1)).ToList());
            }

            return result;
        }
    }
}
