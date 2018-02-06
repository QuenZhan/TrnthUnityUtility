using System.Collections;
using System.Collections.Generic;
// using UnityEditor.Animations;
using UnityEngine;
namespace TRNTH{
public class Fx : TrnthMonoBehaviour,ISerializationCallbackReceiver {
		ParticleSystem _ParticleSystem;
		Animator _Animator;
		[SerializeField]AudioSource[] _Sounds=new AudioSource[0];
		[SerializeField]AudioSource[] _SoundsLayer2=new AudioSource[0];
		[SerializeField]AudioSource[] _SoundsLayer3=new AudioSource[0];
		[SerializeField]bool _UsingAnimatorParameter;
		public bool UsingAnimatorParameter{get{return _UsingAnimatorParameter;}}
		// Transform _tranform;
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
			// _tranform=transform;
			_Animator=GetComponentInChildren<Animator>();
			_ParticleSystem=GetComponentInChildren<ParticleSystem>();
		}
		public bool IsPlaying{
			get{
				return _isPlaying;
			}
			set{
				if(_isPlaying!=value){
					if(value)Play();
					else End();
				}
				_isPlaying=value;
			}
		}
		[SerializeField]bool _isPlaying=true;
		Vector2 _offest;
		[ContextMenu("Play")]
		public void Play(){
			if(_oldParent){
				tra.position=_oldParent.TransformPoint(_offest);
			}
			_play();
		}
		void _play(){
			if(!this)return;
			_isPlaying=true;
			if(!_Animator && _ParticleSystem==null){
				gameObject.SetActive(true);
			}
			else{
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
			PlaySounds(_Sounds);
			PlaySounds(_SoundsLayer2);
			PlaySounds(_SoundsLayer3);
		}
		void PlaySounds(AudioSource[] sounds){
			if(sounds.Length>0){
				sounds.RandomChooseNonAlloc().Play();
			}
		}
		void StopSounds(AudioSource[] sounds){
			var length=sounds.Length;	
			for (int i = 0; i < length; i++)
			{
				sounds[i].Stop();
			}
		}
		public void Launch(Vector3 position){
			tra.position=position;
			_play();
		}
		[ContextMenu("End")]
		public void End(){
			if(!this)return;
			_isPlaying=false;
			StopSounds(_Sounds);
			StopSounds(_SoundsLayer2);
			StopSounds(_SoundsLayer3);
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
		[SerializeField]bool _StopAutoFind;
		// [ContextMenu("Get AudioSources")]
        public void OnBeforeSerialize()
        {
			#if UNITY_EDITOR
			if(_StopAutoFind)return;
			_StopAutoFind=true;
			_Sounds=GetComponentsInChildren<AudioSource>();
			_UsingAnimatorParameter=_AnimatorController;
			#endif
        }
		Transform _oldParent;
		public void Unparent() {
			_offest=this.tra.localPosition;
			_oldParent=this.tra.parent;
			tra.SetParent(null);
		}

        public void OnAfterDeserialize()
        {
            // throw new System.NotImplementedException();
        }
    }
}