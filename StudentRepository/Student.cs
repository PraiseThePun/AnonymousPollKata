namespace AnonymusPollKata
{
	public class Student
	{
		public string Name { get; set; }
		public char Gender { get; set; }
		public int Age { get; set; }
		public string Education { get; set; }
		public int AcademicYear { get; set; }

		public Student(char gender, int age, string education, int academicYear)
		{
			Gender = gender;
			Age = age;
			Education = education;
			AcademicYear = academicYear;
		}

		public Student()
		{
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
