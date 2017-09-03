using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
namespace TRNTH{
public class Fx : MonoBehaviour {
		// [SerializeField]Renderer _Renderer;
		ParticleSystem _ParticleSystem;
		Animator _Animator;
		Transform _tranform;
		static readonly AnimatorControllerParameter ParaStart= new AnimatorControllerParameter(){
				type=AnimatorControllerParameterType.Trigger
					,name="Start"
			};
		static readonly AnimatorControllerParameter ParaEnd= new AnimatorControllerParameter(){
				type=AnimatorControllerParameterType.Trigger
					,name="End"
			};
		[SerializeField]AnimatorController _AnimatorController;
		[ContextMenu("AnimatorParementFormat")]
		void AnimatorParementFormat(){
			_AnimatorController.parameters=new AnimatorControllerParameter[]{ParaStart,ParaEnd};
		}
		void Awake(){
			_tranform=transform;
			_Animator=GetComponentInChildren<Animator>();
			_ParticleSystem=GetComponentInChildren<ParticleSystem>();
		}
		public void Launch(Vector3 position){
			_tranform.position=position;
			// if(_Renderer!=null){
			// 	this._Renderer.enabled=true;
			// }
			if(_Animator!=null){
				_Animator.SetTrigger(ParaStart.name);
			}
			if(_ParticleSystem!=null){
				_ParticleSystem.Play(true);
				// var emission=_ParticleSystem.emission;
				// emission.enabled=true;
			}
		}
		public void End(){
			if(_Animator!=null){
				_Animator.SetTrigger(ParaEnd.name);
			}
			if(_ParticleSystem==null)return;
			_ParticleSystem.Stop();
			// var emission=_ParticleSystem.emission;
			// emission.enabled=false;
		}
	}
}