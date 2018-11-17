﻿using System;
using System.Collections;
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

		public static IEnumerable<TResult> MyCast<TResult>(this IEnumerable arrayList)
		{
			var enumerator = arrayList.GetEnumerator();
			
			while (enumerator.MoveNext())
			{
				if (enumerator.Current is TResult)
				{
					yield return (TResult)enumerator.Current;
				}
				else
				{
					throw new XinyiException();
				}
			}
		}

		public static IEnumerable<TResult> MyOfType<TResult>(this IEnumerable source)
		{
			var enumerator = source.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (enumerator.Current is TResult current)
				{
					yield return current;
				}
			}
		}

		public static IEnumerable<TResult> MyZip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> selector)
		{
			var firstEnumerator = first.GetEnumerator();
			var secondEnumerator = second.GetEnumerator();
			while (firstEnumerator.MoveNext() && secondEnumerator.MoveNext())
			{
				var firstElement = firstEnumerator.Current;
				var secondElement = secondEnumerator.Current;
				yield return selector(firstElement, secondElement);
			}
		}

		public static IEnumerable<TSource> MyUnion<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
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

		public static IEnumerable<Girl> MyUnion(this IEnumerable<Girl> first, IEnumerable<Girl> second)
		{
			var hashSet = new HashSet<string>(new GirlEqualityComparer());

			var firstEnumerator = first.GetEnumerator();
	        
			while (firstEnumerator.MoveNext())
			{
				var firstElement = firstEnumerator.Current;
				if(hashSet.Add(firstElement.Name))
				{
					yield return firstElement;
				}
			}

			var secondEnumerator = second.GetEnumerator();

			while (secondEnumerator.MoveNext())
			{
				var secondElement = secondEnumerator.Current;
				if (hashSet.Add(secondElement.Name))
				{
					yield return secondElement;
				}
			}
		}
	}

	public class GirlEqualityComparer : IEqualityComparer<Girl>
	{
		public bool Equals(Girl x, Girl y)
		{
			throw new NotImplementedException();
		}

		public int GetHashCode(Girl obj)
		{
			throw new NotImplementedException();
		}
	}
}
