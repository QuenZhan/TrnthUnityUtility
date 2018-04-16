using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TRNTH.Effects
{

    public class AfterImageFx : TrnthMonoBehaviour {
		[SerializeField]Pooling.PoolMananger _pool;
		public float IntervalSeconds=0.1f;
		public SpriteRenderer SpriteRenderer;
		[SerializeField]List<AfterImage> _afterImages;
		public IFacer FaceRotator;
		private void Start() {
			_pool.GetSpawnees(_afterImages);
		}
		float counter;
		private void Update() {
			counter-=Time.deltaTime;
			if(counter>0)return;
			counter=IntervalSeconds;
			var fx=_pool.FifoSpawn(_afterImages);
			var flilpx=SpriteRenderer.flipX;
			if(FaceRotator!=null)flilpx=!FaceRotator.FaceRight;
			fx.Play(this.SpriteRenderer,SpriteRenderer.transform.position,flilpx);
		}
	}
}
