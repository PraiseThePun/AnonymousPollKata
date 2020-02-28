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
        private List<Student> studentDicctionary;

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

        public IEnumerable<string> Find(Student studentToFind)
        {
            var result = from studentDicct in studentDicctionary
                         where studentDicct.Equals(studentToFind)
                         select studentDicct.Name;

            return result;
        }
    }
}
