﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipSample.test
{
	public static class MyLinq
	{
		public static IEnumerable<TSource> MyConcat<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
		{
			//var firstEnumerator = first.GetEnumerator();
			//while (firstEnumerator.MoveNext())
			//{
			// yield return firstEnumerator.Current;
			//}
			//var secondEnumerator = second.GetEnumerator();
			//while (secondEnumerator.MoveNext())
			//{
			// yield return secondEnumerator.Current;
			//}
			foreach (var firstItem in first)
			{
				yield return firstItem;
			}
			foreach (var secondItem in second)
			{
				yield return secondItem;
			}
		}

		public static IEnumerable<Tsource> MyReverse<Tsource>(this IEnumerable<Tsource> source)
		{
			return new Stack<Tsource>(source);
			//var myStack = new Stack<Tsource>();
			//var enumerator = source.GetEnumerator();
			//while (enumerator.MoveNext())
			//{
			//	myStack.Push(enumerator.Current);
			//}

			//while (myStack.Count > 0)
			//{
			//	yield return myStack.Pop();
			//}
		}
	}
}
