using AnonymusPollKata;
using DataProcessing;
using NUnit.Framework;
using System.Collections.Generic;
namespace DataProcessingTest
{
	[TestFixture]
	public class ResultUtilsTest
	{
		private IDictionary<int, List<string>> students;

		[SetUp]
		public void SetUp()
		{
			students = new Dictionary<int, List<string>>
			{
				{ 1, new List<string>() },
				{ 2, new List<string>() { "Morgan Martinez Moore" } },
				{ 3, new List<string>() { "Alfie Hernandez Diaz" } },
				{ 4, new List<string>() { "Oliver Carter Rivera", "Mohammad Green Morales" } },
				{ 5, new List<string>() { "Laura Stewart Foster", "Nicole Peterson Torres", "Ellie Brown Reed" } }
			};
		}

		[Test]
		public void FormatStudentsToStringTest()
		{
			const string EXPECTED = "Case #1: NONE\n" +
				"Case #2: Morgan Martinez Moore\n" +
				"Case #3: Alfie Hernandez Diaz\n" +
				"Case #4: Mohammad Green Morales, Oliver Carter Rivera\n" +
				"Case #5: Ellie Brown Reed, Laura Stewart Foster, Nicole Peterson Torres\n";

			var actual = ResultUtils.FormatStudentResult(students);

			Assert.AreEqual(EXPECTED, actual);
		}
	}
}
