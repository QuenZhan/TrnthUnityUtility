using UnityEngine;
using System.Collections;

public interface ITrnthCRUDUser<T> : ITrnthCRUD<T> {
	T me{get;} // cached logined user
	ITrnthQuery<T> signup(string username,string password); // create an new user with username and password
	ITrnthQuery<T> login(string username,string password); // login an new user with username and password
	ITrnthQuery<T> logout(); // me will be null after success
}
