using AnonymusPollKata;
using System.Collections.Generic;
using System.Linq;
using TextProcessing.Interfaces;
using TextProcessing.Wrappers;

namespace DataProcessing
{
    public class StudentFinder
    {
        private readonly ITextFileLoader textFileLoader;
        private static List<Student> studentDicctionary;

        public StudentFinder() : this(new TextFileLoaderWrapper())
        {
            LoadStudents();
        }

        public StudentFinder(ITextFileLoader textFileLoader)
        {
            this.textFileLoader = textFileLoader;
            LoadStudents();
        }

        private void LoadStudents()
        {
            studentDicctionary = textFileLoader.LoadStudentsFromFile();
        }

        private IEnumerable<string> Find(Student studentToFind)
        {
            return from studentDicct in studentDicctionary
                         where studentDicct.Equals(studentToFind)
                         select studentDicct.Name;
        }

        public IDictionary<int, List<string>> FindAll(IEnumerable<Student> studentToFind)
        {
            var result = new Dictionary<int, List<string>>();

            for (int i = 0; i < studentToFind.Count(); i++)
            {
                result.Add(i, Find(studentToFind.ElementAt(i)).ToList());
            }

            return result;
        }
    }
}
