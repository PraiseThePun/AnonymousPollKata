using System.Collections.Generic;
using System.Linq;
using TextLoaderFactory;

namespace DataProcessing
{
    public class StudentFinder
    {
        private readonly TextFileLoader textFileLoader;
        private readonly StudentFactory studentFactory;
        private static List<Student> studentDictionary;

        public StudentFinder(string studentsDB)
        {
            textFileLoader = new TextFileLoader();
            studentFactory = new StudentFactory();
            studentDictionary = textFileLoader.LoadObjectsFromFile<Student, StudentFactory>(studentsDB, studentFactory).Cast<Student>().ToList();
        }

        private IEnumerable<string> Find(Student studentToFind)
        {
            return from studentDict in studentDictionary
                         where studentDict.Equals(studentToFind)
                         select studentDict.Name;
        }

        public IDictionary<int, List<string>> FindAll(List<Student> studentToFind)
        {
            var result = new Dictionary<int, List<string>>();

            for (int i = 1; i <= studentToFind.Count; i++)
            {
                result.Add(i, Find(studentToFind[i - 1]).ToList());
            }

            return result;
        }
    }
}
