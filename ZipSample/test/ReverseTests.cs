using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ZipSample.test
{
    [TestClass]
    public class ReverseTests
    {
        [TestMethod]
        public void reverse_string()
        {
            var source = new string[] { "Apple", "Banana", "Cat" };

            var actual = MyReverse(source).ToList();
            var expected = new List<string> { "Cat", "Banana", "Apple" };

            expected.ToExpectedObject().ShouldEqual(actual);
        }

	    public static IEnumerable<T> MyReverse<T>(IEnumerable<T> source)
        {
			//return new Stack<T>(source);
			var myStack = new Stack<T>();
			var enumerator = source.GetEnumerator();
			while (enumerator.MoveNext())
			{
				myStack.Push(enumerator.Current);
			}

			while (myStack.Count > 0)
			{
				yield return myStack.Pop();
			}
		}
    }
}