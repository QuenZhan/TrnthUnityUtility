using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TRNTH{
	public interface IReadonlyHashSet<T>  {
		bool Contains(T item);
		int Count{get;}
	}
	public class HashSet<T>:System.Collections.Generic.HashSet<T>,IReadonlyHashSet<T>{

	}
	// public interface IReadOnlyList<T>{
	// 	T this[int index]{get;}
	// 	int Count{get;}
	// }
	// public class List<T>:System.Collections.Generic.List<T>,IReadOnlyList<T>{}
}
