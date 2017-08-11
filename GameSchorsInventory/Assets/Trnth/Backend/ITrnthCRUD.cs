using UnityEngine;
using System.Collections;

public interface ITrnthCRUD<T>{
	ITrnthQuery<T> create();
	ITrnthQuery<T[]> read(System.Func<bool,T> predicate);
	ITrnthQuery<T> update(T data);
	ITrnthQuery<T> delete(T data);
}
