using System.Collections.Generic;
using System.Linq;

namespace DataProcessing
{
    public static class ResultUtils
    {
        public static List<string> SortLexicographically(List<string> names)
        {
            return names.OrderByDescending(s => s.Length)
                .ThenBy(s => s)
                .ToList();
        }

        public static string FormatStudentToString(IEnumerable<string> students)
        {
            var result = string.Empty;

            foreach (var student in students)
            {
                result += students.ElementAt(students.Count() - 1) != student ? student + ", " : student;
            }

            return result;
        }
    }
}
