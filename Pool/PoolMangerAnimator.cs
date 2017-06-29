using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using UnityEngine;
namespace TRNTH.Pooling{
	
	public class PoolMangerAnimator : PoolManger<Animator> {
		public ReadOnlyCollection<Animator> Animators{get{return Components;}}
	}
}