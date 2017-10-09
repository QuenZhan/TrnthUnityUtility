using System.Collections;
using System.Collections.Generic;
// using UnityEditor.Animations;
using UnityEngine;
namespace TRNTH{
public class Fx : TrnthMonoBehaviour {
		// [SerializeField]Renderer _Renderer;
		ParticleSystem _ParticleSystem;
		Animator _Animator;
		Transform _tranform;
		const string AnimattionStart="Start";
		const string AnimationEnd="End";
		#if UNITY_EDITOR
		static readonly AnimatorControllerParameter ParaStart= new AnimatorControllerParameter(){
				type=AnimatorControllerParameterType.Trigger
					,name=AnimattionStart
			};
		static readonly AnimatorControllerParameter ParaEnd= new AnimatorControllerParameter(){
				type=AnimatorControllerParameterType.Trigger
					,name=AnimationEnd
			};
		[SerializeField] UnityEditor.Animations.AnimatorController _AnimatorController;
		[ContextMenu("AnimatorParementFormat")]
		void AnimatorParementFormat(){
			_AnimatorController.parameters=new AnimatorControllerParameter[]{ParaStart,ParaEnd};
		}
		#endif
		public override void Awake(){
			base.Awake();
			_tranform=transform;
			_Animator=GetComponentInChildren<Animator>();
			_ParticleSystem=GetComponentInChildren<ParticleSystem>();
		}
		public bool IsPlaying{get;private set;}
		public void Play(){
			IsPlaying=true;
			if(_Animator==null && _ParticleSystem==null){
				gobj.SetActive(true);
				return ;
			}
			if(_Animator!=null){
				_Animator.ResetTrigger(AnimationEnd);
				_Animator.SetTrigger(AnimattionStart);
			}
			if(_ParticleSystem!=null){
				_ParticleSystem.Play(true);
			}
		}
		public void Launch(Vector3 position){
			_tranform.position=position;
			Play();
		}
		public void End(){
			IsPlaying=false;
			if(_Animator==null && _ParticleSystem==null){
				gobj.SetActive(false);
				return ;
			}
			if(_Animator!=null){
				_Animator.ResetTrigger(AnimattionStart);
				_Animator.SetTrigger(AnimationEnd);
			}
			if(_ParticleSystem==null)return;
			_ParticleSystem.Stop(true,ParticleSystemStopBehavior.StopEmitting);
		}
	}
}