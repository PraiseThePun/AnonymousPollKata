using AnonymusPollKata;
using DataProcessing;
using NUnit.Framework;
using System.Collections.Generic;
namespace DataProcessingTest
{
	[TestFixture]
	public class ResultUtilsTest
	{
		private List<Student> students;

		[SetUp]
		public void SetUp()
		{
			students = new List<Student>() {
				new Student()
				{
					Name = "Morgan Martinez Moore",
					Gender = 'F',
					Age = 20,
					Education = "Systems Engineering",
					AcademicYear = 2
				},
				new Student()
				{
					Name = "Alfie Hernandez Diaz",
					Gender = 'M',
					Age = 20,
					Education = "Manufacturing Engineering",
					AcademicYear = 3
				},
				new Student()
				{
					Name = "Oliver Carter Rivera",
					Gender = 'M',
					Age = 18,
					Education = "Electrical Engineering",
					AcademicYear = 2
				},
			};
		}

		[Test]
		public void FormatStudentsToStringTest()
		{
			var expected = "Case #1: NONE\n" +
				"Case #2: Morgan Martinez Moore\n" +
				"Case #3: Alfie Hernandez Diaz" +
				"Case #4: Mohammad Green Morales,Oliver Carter Rivera" +
				"Case #5: Ellie Brown Reed,Laura Stewart Foster,Nicole Peterson Torres";

			//var actual = ResultUtils.FormatStudentResult(students);

			//Assert.AreEqual(expected, actual);
		}
	}
}
