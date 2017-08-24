using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TRNTH.SchorsInventory.DeadDatabase{
	[CreateAssetMenu]public class ItemData : ScriptableObject {
		public string Name;
		public Sprite Icon;
		public string Description;
		AttributeData[] _AvailibleAdjectives;
		public IReadonlyHashSet<AttributeData> AvailibleAdjectives{get{throw new System.NotImplementedException();}}
	}
}