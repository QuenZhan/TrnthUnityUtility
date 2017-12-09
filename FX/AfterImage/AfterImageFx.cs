using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TRNTH.Effects
{

    public class AfterImageFx : TrnthMonoBehaviour {
		[SerializeField]FxPool _pool;
		public float IntervalSeconds=0.1f;
		public SpriteRenderer SpriteRenderer;
		[System.NonSerialized]public FaceRotator FaceRotator;
		private void Start() {
			_pool.UnparentAll();
		}
		float counter;
		private void Update() {
			counter-=Time.deltaTime;
			if(counter>0)return;
			counter=IntervalSeconds;
			var fx=_pool.Spawn();
			fx.Play(this.SpriteRenderer,SpriteRenderer.transform.position,!FaceRotator.FaceRight);
		}
		[System.Serializable]class FxPool:Pooling.ComponentsPool<AfterImage>{

		}
	}
}
