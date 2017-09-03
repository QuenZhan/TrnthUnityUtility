using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TRNTH.SchorsInventory.RuntimeDatabase{
	[System.Serializable]public class Item  {
		public DeadDatabase.ItemData Data;
		[SerializeField]Adjectives[] _Adjectives=new Adjectives[MaxAdjectivesCount];
		public Adjectives[] Adjectives{get{return _Adjectives;}}
		public const int MaxAdjectivesCount=4;
		public byte Count;
		// public string Description{
		// 	get{
		// 		if(string.IsNullOrWhiteSpace(_Description)){
		// 			_Description=string.Format("{0} - {1} :",Data.Name,Data.Description);
		// 			for (int i = 0; i < MaxAdjectivesCount; i++)
		// 			{
		// 				if(_Adjectives[i]==null)continue;
		// 				_Description+=string.Format("{0}:{1}");
		// 			}
		// 		}
		// 	return _Description;
		// 	}
		// }
		// [SerializeField]string _Description;
	}
	[System.Serializable]public class Adjectives{
		public DeadDatabase.AttributeData Data;
		public byte Value;
		// public bool Hidden;
	}
}