using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TRNTH.SchorsInventory.DeadDatabase{
	[CreateAssetMenu]public class Recipe : ScriptableObject {
		public string Name;
		public string Description;
		public System.TimeSpan CostTime;
		public byte ComsumingStamina;
		[SerializeField]Ingredient[] _Ingredients;
		public IReadOnlyList<Ingredient> Ingredients{get{return _Ingredients;}}
		public IReadOnlyList<Ingredient> Result{get{return null;}}
	}
	[System.Serializable]public struct Ingredient{
		public ItemData Data;
		public byte Count;
	}
	
}