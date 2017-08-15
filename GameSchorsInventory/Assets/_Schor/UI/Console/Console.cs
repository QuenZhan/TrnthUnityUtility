using System;
using System.Collections;
using System.Collections.Generic;
using TRNTH.Pooling;
using UnityEngine;
namespace TRNTH.SchorsInventory.UI.Component{
	public class Console : MonoBehaviour
	{
		[SerializeField]Transform _Parent;
		readonly Queue<ConsoleRow> _qRows=new Queue<ConsoleRow>();
		const string empty="";
        public void Add(string content0,string content1=empty,string content2=empty){
			if(_qRows.Count<1)Init();
			var tra=_Parent.GetChild(0);
			var row=_qRows.Dequeue();
			row.Contents[0].text=content0;
			row.Contents[1].text=content1;
			row.Contents[2].text=content2;
			row.transform.SetSiblingIndex(9);
			row.PlayAnimation();
			_qRows.Enqueue(row);
		}
		void Init(){
			var length=_Parent.childCount;
			for (int i = 0; i < length; i++)
			{
				var cell=_Parent.GetChild(i).GetComponent<ConsoleRow>();
				_qRows.Enqueue(cell);
			}
		}
	}

}
