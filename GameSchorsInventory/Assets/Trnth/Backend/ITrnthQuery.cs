using UnityEngine;
using System.Collections;

public interface ITrnthQuery<T> {
	ITrnthQuery<T> whenSuccess(System.Action<T> callback);
	ITrnthQuery<T> whenFail(System.Action<string> callback);
}


