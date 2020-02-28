using DataProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using TextProcessing;

namespace AnonymusPollKata
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            int casesIteration;
            var studentsToFind = new List<Student>();
            var studentFinder = new StudentFinder();

            do
            {
                if (!int.TryParse(Console.ReadLine(), out casesIteration))
                {
                    throw new Exception("Input has to be a valid digit character.");
                }

                if (casesIteration > 100 || casesIteration < 1)
                {
                    throw new Exception("The number of students to look up has to be between 1 and 100");
                }
            } while (casesIteration > 100 || casesIteration < 1);

            for (int i = 0; i < casesIteration; i++)
            {
                bool canProceed = false;

                do
                {
                    var rawStudentStr = Console.ReadLine();

                    try
                    {
                        studentsToFind.Add(InputParser.ParseStudent(rawStudentStr));
                        canProceed = true;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                } while (!canProceed);
            }

            foreach (var student in studentsToFind)
            {
                var studentsStrList = studentFinder.Find(student);

                if (!studentsStrList.Any())
                {
                    Console.WriteLine("Case #" + studentsToFind.IndexOf(student) + ": NONE");
                }
                else
                {
                    studentsStrList = ResultUtils.SortLexicographically(studentsStrList.ToList());
                    Console.WriteLine("Case #" + studentsToFind.IndexOf(student) + ": " + ResultUtils.FormatStudentToString(studentsStrList));
                }
            }

            Console.ReadKey();
        }
    }
}
