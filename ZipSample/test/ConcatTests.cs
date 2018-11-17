using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ZipSample.test
{
	[TestClass]
    public class ConcatTests
    {
        [TestMethod]
        public void concat_integers()
        {
            var first = new int[] {1, 3, 5};
            var second = new int[] {2, 4, 6};

	        var actual = first.MyConcat(second).ToArray();

            var expected = new int[] {1, 3, 5, 2, 4, 6};
            expected.ToExpectedObject().ShouldEqual(actual);
        }

		[TestMethod]
	    public void concat_employee()
		{
			var first = new List<Employee>
			{
				new Employee() {Id = 1, Name = "AAA"},
			};

			var second = new List<Employee>
			{
				new Employee() {Id = 2, Name = "BBB"},
				new Employee() {Id = 3, Name = "CCC"}
			};

			var actual = first.MyConcat(second).ToList();
			var expected = new List<Employee>()
			{
				new Employee() {Id = 1, Name = "AAA"},
				new Employee() {Id = 2, Name = "BBB"},
				new Employee() {Id = 3, Name = "CCC"}
			};
			expected.ToExpectedObject().ShouldEqual(actual);
		}
    }
}