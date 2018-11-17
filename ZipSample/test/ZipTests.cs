using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ZipSample.test
{
    [TestClass]
    public class ZipTests
    {
        [TestMethod]
        public void pair_3_girls_and_5_boys()
        {
            var girls = Repository.Get3Girls();
            var keys = Repository.Get5Keys();

            var girlAndBoyPairs = MyLinq.MyZip(girls, keys, (firstElement, secondElement) => Tuple.Create(firstElement.Name, secondElement.OwnerBoy.Name)).ToList();
            var expected = new List<Tuple<string, string>>
            {
                Tuple.Create("Jean", "Joey"),
                Tuple.Create("Mary", "Frank"),
                Tuple.Create("Karen", "Bob"),
            };

            expected.ToExpectedObject().ShouldEqual(girlAndBoyPairs);
        }

	    [TestMethod]
	    public void pair_5_girls_and_3_boys()
	    {
		    var girls = Repository.Get5Girls();
		    var keys = Repository.Get3Keys();

		    var girlAndBoyPairs = MyLinq.MyZip(girls, keys, (firstElement, secondElement) => Tuple.Create(firstElement.Name, secondElement.OwnerBoy.Name)).ToList();
		    var expected = new List<Tuple<string, string>>
		    {
			    Tuple.Create("Jean", "Joey"),
			    Tuple.Create("Mary", "Frank"),
			    Tuple.Create("Karen", "Bob"),
		    };

		    expected.ToExpectedObject().ShouldEqual(girlAndBoyPairs);
	    }

	    [TestMethod]
	    public void pair_3_boys_and_5_girls()
	    {
			var girls = Repository.Get5Girls();
			var keys = Repository.Get3Keys();

			var girlAndBoyPairs = MyLinq.MyZip(keys, girls, (firstElement, secondElement) => Tuple.Create(secondElement.Name, firstElement.OwnerBoy.Name)).ToList();
			var expected = new List<Tuple<string, string>>
			{
				Tuple.Create("Jean", "Joey"),
				Tuple.Create("Mary", "Frank"),
				Tuple.Create("Karen", "Bob"),
			};

			expected.ToExpectedObject().ShouldEqual(girlAndBoyPairs);
		}
    }
}