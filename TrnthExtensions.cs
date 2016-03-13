using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
    public static IList<T> shuffle<T>(this IList<T> list){
        // if(list.Count<1)return list;
        return new List<T>(U.shuffle<T>(list.ToArray()));
        // return list[Random.Range(0,list.Count)];
    }
    public static void send(this MonoBehaviour monoBehaviour,TrnthHVSCondition condition){
    	if(condition)condition.send();
    }
    public static IList<T> CastComponent<T>(this Component component){
        return component.transform.Cast<Transform>().CastComponent<T>();
    }
    public static IList<T> CastComponent<T>(this IEnumerable components){
        var list=new List<T>();
        foreach(Component e in components){
            var c=e.GetComponent<T>();
            if(c!=null)list.Add(c);
        }
        return list;
    }
    // public static IList<T> add
}   
}