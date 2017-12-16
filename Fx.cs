using System.Collections;
using System.Collections.Generic;
// using UnityEditor.Animations;
using UnityEngine;
namespace TRNTH{
public class Fx : TrnthMonoBehaviour {
		// [SerializeField]Renderer _Renderer;
		ParticleSystem _ParticleSystem;
		Animator _Animator;
		public bool UsingAnimatorParameter{get{return _AnimatorController;}}
		Transform _tranform;
		public const string AnimattionStart="Start";
		public const string AnimationEnd="End";
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
			// UsingAnimatorParameter=_Animator;
			_ParticleSystem=GetComponentInChildren<ParticleSystem>();
		}
		public bool IsPlaying{get;private set;}
		public void Play(){
			if(!this)return;
			IsPlaying=true;
			if(!_Animator && _ParticleSystem==null){
				gameObject.SetActive(true);
				return ;
			}
			if(_Animator!=null ){
				if(UsingAnimatorParameter){
					_Animator.ResetTrigger(AnimationEnd);
					_Animator.SetTrigger(AnimattionStart);
				}
				else{
					gobj.SetActive(false);
					gobj.SetActive(true);
				}
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
			if(!this)return;
			IsPlaying=false;
			if(!_Animator && _ParticleSystem==null){
				gameObject.SetActive(false);
				return ;
			}
			if( _Animator!=null){
				if(UsingAnimatorParameter){
					_Animator.ResetTrigger(AnimattionStart);
					_Animator.SetTrigger(AnimationEnd);
				}
				else{
					gobj.SetActive(false);
				}
			}
			if(_ParticleSystem==null)return;
			_ParticleSystem.Stop(true,ParticleSystemStopBehavior.StopEmitting);
		}
	}
}