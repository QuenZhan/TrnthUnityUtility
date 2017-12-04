using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TRNTH{
	public class GridSnap : TrnthMonoBehaviour {
		[SerializeField]Vector2 Space;
		Vector2 Size;
		[SerializeField]int Columns=4;
		RectTransform _rectTransform;
		[ContextMenu("Layout")]
		public void Layout(){
			var length=transform.childCount;
			for (int i = 0; i < length; i++)
			{
				var x=i%Columns;
				var y=i/Columns;
				var tra=transform.GetChild(i) as RectTransform;
				tra.anchoredPosition=new Vector2((Size.x+Space.x)*x,-(Size.y+Space.y)*y);
				if(i==0)Size=tra.sizeDelta;
				else tra.sizeDelta=Size;
			}
			var width=(Size.x+Space.x)*Columns-Space.x;
			var height=(Size.y+Space.y)*length/Columns-Space.y;
			if(!_rectTransform)_rectTransform=GetComponent<RectTransform>();
			_rectTransform.sizeDelta=new Vector2(width,height);
		}
	}
}
