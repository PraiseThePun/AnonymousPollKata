using AnonymusPollKata;
using System.Collections.Generic;
using System.Linq;

namespace DataProcessing
{
    public static class ResultUtils
    {
        private static IEnumerable<string> SortLexicographically(IEnumerable<string> names)
        {
            //return from name in names
            //       orderby name.Length descending, name
            //       select name;

            //return names.OrderByDescending(s => s.Length)
            //    .ThenBy(s => s);

            return names.OrderBy(x => x).ThenBy(x => x.Length);
        }

        private static string FormatStudentToString(IEnumerable<string> students)
        {
            var result = string.Empty;

            foreach (var student in students)
            {
                result += students.ElementAt(students.Count() - 1) != student ? student + ", " : student;
            }

            return result;
        }

        public static string FormatStudentResult(IDictionary<int, List<string>> studentDicctionary)
        {
            var result = "";

            foreach (KeyValuePair<int, List<string>> studentEnum in studentDicctionary)
            {
                if (studentEnum.Value.Count == 0)
                {
                    result += "Case #" + studentEnum.Key + ": NONE\n";
                }
                else
                {
                    var sortedRes = SortLexicographically(studentEnum.Value);
                    result += "Case #" + studentEnum.Key + ": " + FormatStudentToString(sortedRes) + "\n";
                }
            }

            return result;
        }
    }
}
