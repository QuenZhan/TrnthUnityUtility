using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TRNTH.SchorsInventory{
	[System.Serializable]public class Item  {
		public DeadDatabase.ItemData Data;
		public Attribute[] Attributes=new Attribute[0];
	}
	[System.Serializable]public class Attribute{
		public DeadDatabase.AttributeData Data;
		public byte Value;
	}
}