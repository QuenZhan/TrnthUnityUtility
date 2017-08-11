using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TRNTH.SchorsInventory.DeadDatabase{
	[CreateAssetMenu]public class Character : ScriptableObject {
			public string Name;
			public string Description;
			public Recipe[] Recipes;
			public Color Color;
	}
}