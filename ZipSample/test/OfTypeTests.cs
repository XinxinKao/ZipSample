using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ZipSample.test
{
    [TestClass]
    public class OfTypeTests
    {
        [TestMethod]
        public void pick_integer_from_ArrayList()
        {
            var arrayList = new ArrayList { 2, "A", 6 };
            var actual = MyLinq.MyOfType<int>(arrayList).ToList();

            var expected = new List<int> { 2, 6 };
            expected.ToExpectedObject().ShouldEqual(actual);
        }
    }
}