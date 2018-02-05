using System.Collections;
namespace TRNTH
{
    public interface IReadonlyHashSet<T>  {
		bool Contains(T item);
		int Count{get;}
	}
	public class HashSet<T>:System.Collections.Generic.HashSet<T>,IReadonlyHashSet<T>{

	}
	public interface IReadOnlyNonAllocList<T>{
		T this[int index]{get;}
		int Count{get;}
	}
	public interface INonAllocList<T>:IReadOnlyNonAllocList<T>{
		new T this[int index]{get;set;}
	}
}
namespace TRNTH.ContainerExtention
{
}