using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TRNTH
{
    public class GridSnap : TrnthMonoBehaviour {
		[SerializeField]Vector2 Space;
		Vector2 Size;
		[SerializeField]int _Columns=4;
		public int Columns{get{return _Columns;}}
		RectTransform _rectTransform;
		[ContextMenu("Layout")]
		public void Layout(){
			float length=transform.childCount;
			for (int i = 0; i < length; i++)
			{
				var x=i%_Columns;
				var y=i/_Columns;
				var tra=transform.GetChild(i) as RectTransform;
				tra.anchorMin=new Vector2(0,1);
				tra.anchorMax=new Vector2(0,1);
				tra.pivot=new Vector2(0,1);
				tra.anchoredPosition=new Vector2((Size.x+Space.x)*x,-(Size.y+Space.y)*y);
				if(i==0)Size=tra.sizeDelta;
				else tra.sizeDelta=Size;
			}
			var width=(Size.x+Space.x)*_Columns-Space.x;
			var height=(Size.y+Space.y)*Mathf.Ceil(length/_Columns)-Space.y;
			if(!_rectTransform)_rectTransform=GetComponent<RectTransform>();
			_rectTransform.sizeDelta=new Vector2(width,height);
		}
	}
}
