using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TRNTH.SchorsInventory.DeadDatabase{
[CreateAssetMenu]public class TransportMethod : ScriptableObject {
	public string Name;
	public Sprite Icon;
	[Multiline]public string Description;
}

}
