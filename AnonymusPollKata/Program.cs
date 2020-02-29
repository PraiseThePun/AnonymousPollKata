using DataProcessing;
using ObjectFactory;
using System;
using System.Collections.Generic;
using TextProcessing;

namespace AnonymusPollKata
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            int casesIteration = 0;
            var studentsToFind = new List<Student>();
            var studentFinder = new StudentFinder();
            var studentFactory = new StudentFactory();

            do
            {
                try
                {
                    casesIteration = InputParser.ParseCasesNumber(Console.ReadLine());
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
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
                        studentsToFind.Add(studentFactory.Parse(rawStudentStr));
                        canProceed = true;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                } while (!canProceed);
            }

            Console.Clear();

            var foundStudents = studentFinder.FindAll(studentsToFind);
            Console.WriteLine(ResultUtils.FormatStudentResult(foundStudents));

            Console.ReadKey();
        }
    }
}
