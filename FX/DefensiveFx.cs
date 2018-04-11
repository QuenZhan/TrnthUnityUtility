using UnityEngine;
namespace TRNTH{

	public class DefensiveFx : TrnthMonoBehaviour {
		[SerializeField]Fx _hitEffect;
		[SerializeField]TrnthFxShake _shaker;
		public void Play(Vector3 from,float hitstucktime=0.1f)
		{

			var delta=Position-from;
			delta=delta.normalized+Vector3.up;
			_hitEffect.transform.position=this.Position;
			_hitEffect.transform.LookAt(Position+delta);
			if(_shaker)_shaker.play();
			_hitEffect.Play();
			WhiteOverlay(true);
			if(hitstucktime>0)HitStuck(hitstucktime);
		}
		public bool IsStuck{get{return HitStuckConter>0;}}
		[SerializeField]Animator _Animator;
		float HitStuckConter;
		void HitStuck(float duration=0.1f){
			if(IsStuck)return;
			if(_Animator)_Animator.speed=0;
			HitStuckConter=duration;
		}
		[SerializeField]Material _hitEffectMaterial;
		[System.NonSerialized]Material _originalMaterial;
		[SerializeField]SpriteRenderer SpriteRenderer;
		public void WhiteOverlay(bool toggle){
			if(toggle)this.SpriteRenderer.material=_hitEffectMaterial;
			else this.SpriteRenderer.material=_originalMaterial;
		}

		// Use this for initialization
		void Start () {
			_originalMaterial=this.SpriteRenderer.material;
		}
		
		// Update is called once per frame
		void Update () {
			if(HitStuckConter>0){
				HitStuckConter-=Time.deltaTime;
				if(HitStuckConter<=0){
					HitStuckEnd();
				}
			}
		}
		void HitStuckEnd(){
			if(_Animator){
				_Animator.speed=1;
			}
			SpriteRenderer.material=_originalMaterial;
			HitStuckConter=0;
		}
		}
}