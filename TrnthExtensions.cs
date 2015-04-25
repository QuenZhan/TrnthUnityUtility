using UnityEngine;
using System.Collections;

namespace TRNTH{
public static class TrnthExtensions
{
    public static T find(this IEnumerable<T> list,T value)
    {
        foreach(T e in list){
        	if(value==e)return e;
        }
        return default(T);
    }
}   
}