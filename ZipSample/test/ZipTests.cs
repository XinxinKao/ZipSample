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

            var girlAndBoyPairs = MyZip(girls, keys).ToList();
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

		    var girlAndBoyPairs = MyZip(girls, keys).ToList();
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

		    var girlAndBoyPairs = MyZip(keys, girls).ToList();
		    var expected = new List<Tuple<string, string>>
		    {
			    Tuple.Create("Joey", "Jean"),
			    Tuple.Create("Frank", "Mary"),
			    Tuple.Create("Bob", "Karen"),
		    };

		    expected.ToExpectedObject().ShouldEqual(girlAndBoyPairs);
	    }

		private IEnumerable<Tuple<string, string>> MyZip(IEnumerable<Key> keys, IEnumerable<Girl> girls)
		{
			var firstEnumerator = keys.GetEnumerator();
			var secondEnumerator = girls.GetEnumerator();
			while (firstEnumerator.MoveNext() && secondEnumerator.MoveNext())
			{
				yield return Tuple.Create(firstEnumerator.Current.OwnerBoy.Name, secondEnumerator.Current.Name);
			}
		}

		private IEnumerable<Tuple<string, string>> MyZip(IEnumerable<Girl> girls, IEnumerable<Key> keys)
        {
			var firstEnumerator = girls.GetEnumerator();
			var secondEnumerator = keys.GetEnumerator();
			while (firstEnumerator.MoveNext() && secondEnumerator.MoveNext())
			{
				yield return Tuple.Create(firstEnumerator.Current.Name, secondEnumerator.Current.OwnerBoy.Name);
			}
		}
    }
}