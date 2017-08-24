using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TRNTH{
	public interface IReadonlyHashSet<T>  {
		bool Contains(T item);
	}
	public class HashSet<T>:System.Collections.Generic.HashSet<T>,IReadonlyHashSet<T>{

	}
}
