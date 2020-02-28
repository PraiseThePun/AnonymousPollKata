using DataProcessing;
using NUnit.Framework;
using System.Collections.Generic;
namespace DataProcessingTest
{
	[TestFixture]
	public class ResultUtilsTest
	{
		private List<string> names;

		[SetUp]
		public void SetUp()
		{
			names = new List<string>() { "Oliver Carter Rivera", "Mohammad Green Morales" };
		}

		[Test]
		public void SortLexicographicallyTest()
		{
			var expected = new List<string>() { "Mohammad Green Morales", "Oliver Carter Rivera" };
			var actual = ResultUtils.SortLexicographically(names);

			CollectionAssert.AreEqual(expected, actual);
		}

		[Test]
		public void StudentToStringTest()
		{

		}
	}
}
