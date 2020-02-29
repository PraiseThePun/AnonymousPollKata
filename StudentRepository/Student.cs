namespace AnonymusPollKata
{
	public class Student
	{
		public string Name { get; }
		public char Gender { get; }
		public int Age { get; }
		public string Education { get; }
		public int AcademicYear { get; }

		public Student(char gender, int age, string education, int academicYear)
		{
			Gender = gender;
			Age = age;
			Education = education;
			AcademicYear = academicYear;
		}

		public bool Equals(Student toCompare)
		{
			return toCompare.Gender == Gender &&
				toCompare.Age == Age &&
				toCompare.Education == Education &&
				toCompare.AcademicYear == AcademicYear;
		}
	}
}
