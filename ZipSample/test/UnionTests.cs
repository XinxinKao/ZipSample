﻿using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ZipSample.test
{
    [TestClass]
    public class UnionTests
    {
        [TestMethod]
        public void Union_integers()
        {
            var first = new List<int> { 1, 3, 5 };
            var second = new List<int> { 5, 3, 7, 9 };

            var expected = new List<int> { 1, 3, 5, 7, 9 };

            var actual = MyUnion(first, second).ToList();
            expected.ToExpectedObject().ShouldEqual(actual);
        }

	    public static IEnumerable<TSource> MyUnion<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
	        var hashSet = new HashSet<TSource>();

	        var firstEnumerator = first.GetEnumerator();
	        
	        while (firstEnumerator.MoveNext())
	        {
		        if(hashSet.Add(firstEnumerator.Current))
		        {
			        yield return firstEnumerator.Current;
		        }
	        }

	        var secondEnumerator = second.GetEnumerator();

	        while (secondEnumerator.MoveNext())
	        {
		        if (hashSet.Add(secondEnumerator.Current))
		        {
			        yield return secondEnumerator.Current;
		        }
	        }
        }
    }
}