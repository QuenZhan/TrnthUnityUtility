using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TRNTH{
	public interface IAnimationEventListener{
		void Callback();
		void CallbackWithNumber(int index);
	}
}
namespace TRNTH.Components{
	public class AnimationEvent : MonoBehaviour {
		public IAnimationEventListener Delegate;
		void Callback(){
			Delegate.Callback();
		}
		void CallbackWithNumber(int index){
			Delegate.CallbackWithNumber(index);
		}
	}

}
