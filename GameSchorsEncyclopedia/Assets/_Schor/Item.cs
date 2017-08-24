using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TRNTH.SchorsInventory{
	[System.Serializable]public class Item  {
		public DeadDatabase.ItemData Data;
		[SerializeField]Adjectives[] _Adjectives=new Adjectives[MaxAdjectivesCount];
		public Adjectives[] Adjectives{get{return _Adjectives;}}
		public const int MaxAdjectivesCount=4;
		public byte Count;
	}
	[System.Serializable]public class Adjectives{
		public DeadDatabase.AttributeData Data;
		public byte Value;
		public bool Hidden;
	}
}