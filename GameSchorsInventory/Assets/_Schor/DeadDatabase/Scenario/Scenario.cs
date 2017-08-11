using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TRNTH.SchorsInventory.DeadDatabase{
	[CreateAssetMenu]public class Scenario : ScriptableObject {
		[SerializeField]Dialogue[] _Dialogues;
		public IReadOnlyList<Dialogue> Dialogues{get{return _Dialogues;}}
	}
	[System.Serializable]public struct Dialogue{
		[Multiline]public string Content;
		public Character Character;
	}
}