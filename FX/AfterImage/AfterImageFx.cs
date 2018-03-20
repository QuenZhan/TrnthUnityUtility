using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TRNTH.Effects
{

    public class AfterImageFx : TrnthMonoBehaviour {
		[SerializeField]FxPool _pool;
		public float IntervalSeconds=0.1f;
		public SpriteRenderer SpriteRenderer;
		public IFacer FaceRotator;
		private void Start() {
			_pool.UnparentAll();
		}
		float counter;
		private void Update() {
			counter-=Time.deltaTime;
			if(counter>0)return;
			counter=IntervalSeconds;
			var fx=_pool.Spawn();
			var flilpx=SpriteRenderer.flipX;
			if(FaceRotator!=null)flilpx=!FaceRotator.FaceRight;
			fx.Play(this.SpriteRenderer,SpriteRenderer.transform.position,flilpx);
		}
		[System.Serializable]class FxPool:Pooling.ComponentsPool<AfterImage>{

		}
	}
}
