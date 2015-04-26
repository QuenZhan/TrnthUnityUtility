using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TRNTH{
public static class TrnthExtensions
{
    public static T find<T>(this IEnumerable<T> list,T value) where T : class
    {
        foreach(T e in list){
        	if(value==(e))return e;
        }
        return default(T);
    }
    public static T choose<T>(this IList<T> list){
    	if(list.Count<1)return default(T);
		return list[Random.Range(0,list.Count)];
    }
    public static void send(this MonoBehaviour monoBehaviour,TrnthHVSCondition condition){
    	if(condition)condition.send();
    }
}   
}