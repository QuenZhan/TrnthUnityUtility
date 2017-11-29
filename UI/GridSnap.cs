using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TRNTH{
	#if UNITY_EDITOR
	public class GridSnap : TrnthMonoBehaviour {
		[SerializeField]Vector2 Space;
		[SerializeField]Vector2 Size;
		[SerializeField]int Columns=4;
		[ContextMenu("Layout")]
		void Layout(){
			var length=transform.childCount;
			// Size=transform.GetChild(i) ra
			for (int i = 0; i < length; i++)
			{
				var x=i%Columns;
				var y=i/Columns;
				var tra=transform.GetChild(i) as RectTransform;
				tra.anchoredPosition=new Vector2((Size.x+Space.x)*x,-(Size.y+Space.y)*y);
				if(i==0)Size=tra.sizeDelta;
				else tra.sizeDelta=Size;
			}
		}
	}
	#endif
}
