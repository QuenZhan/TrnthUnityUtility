
using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;
using System.Collections.Generic;

namespace TRNTH{
	public class AnimatorUtility : EditorWindowBase {

		[MenuItem("TRNTH/AnimatorUtility")]
		private static void ShowWindow() {
			GetWindow<AnimatorUtility>().Show();
		}
		[SerializeField]UnityEditor.Animations.AnimatorController _animatorControll;
		// static void RemoveCrossFade

		void RemoveTransitionCrossfade(){
			foreach (var item in _animatorControll.layers)
			{
				foreach (var childState in item.stateMachine.states)
				{
					foreach (var transition in childState.state.transitions)
					{
						transition.RemoveCrossFade();
					}
				}
			}
		}
		[SerializeField]TransitionGenerator _TransitionGenerator;
		private void OnGUI() {
			PropertyDrawer("_animatorControll",this);
			if(GUILayout.Button("RemoveTransitionCrossfade"))RemoveTransitionCrossfade();
			PropertyDrawer("_TransitionGenerator",this);
			if(GUILayout.Button("Collect freeStates from Selection"))_TransitionGenerator.CollectFreeStates();
			if(GUILayout.Button("ActionTransitionGenerate"))_TransitionGenerator.Generate(_animatorControll);
		}
		void OnInspectorUpdate(){
			if(Selection.activeObject is AnimatorState){
				_TransitionGenerator.destinationState=Selection.activeObject  as AnimatorState;
			}
			var animatorControll=Selection.activeObject as AnimatorController;
			if(animatorControll!=null)_animatorControll=animatorControll;
		}
		[System.Serializable]class TransitionGenerator{
			[SerializeField]int _layer;
			[SerializeField]List<AnimatorState> _freeStates=new List<AnimatorState>();
			public AnimatorState destinationState;
			public void CollectFreeStates(){
				_freeStates.Clear();
				foreach (var item in Selection.objects)
				{
					var state=item as AnimatorState;
					if(state==null)continue;
					_freeStates.Add(state);
				}
				// foreach(var childSTate in  animatorController.layers[_layer].stateMachine.states){
				// 	if(_freeStateNames.Contains( childSTate.state.name))_freeStates.Add(childSTate.state);
				// }
			}
			public void Generate(AnimatorController animatorController){
				// CollectFreeStates(animatorController);
				var path=AssetDatabase.GetAssetPath(animatorController);
				var parameter=animatorController.parameters.Find(t=>{return t.name==destinationState.name;});
				if(parameter!=null)animatorController.RemoveParameter(parameter);
				animatorController.AddParameter(destinationState.name,AnimatorControllerParameterType.Trigger);
				
				var defaultState=animatorController.layers[_layer].stateMachine.defaultState;
				foreach (var state in _freeStates)
				{
					var newTransition=new AnimatorStateTransition();
					newTransition.RemoveCrossFade();
					newTransition.destinationState=destinationState;
					newTransition.AddCondition(AnimatorConditionMode.If,0,destinationState.name);
					newTransition.hasExitTime=false;
					state.AddTransition(newTransition);
					// EditorUtility.SetDirty(state);
					// EditorUtility.SetDirty(newTransition);
					AssetDatabase.AddObjectToAsset(newTransition,path);
				}
				var toIdleTransition=new AnimatorStateTransition();
				toIdleTransition.RemoveCrossFade();
				toIdleTransition.destinationState=defaultState;
				toIdleTransition.hasExitTime=true;
				destinationState.AddTransition(toIdleTransition);
				AssetDatabase.AddObjectToAsset(toIdleTransition,path);
				// EditorUtility.SetDirty(toIdleTransition);
				// EditorUtility.SetDirty(destinationState);
				EditorUtility.SetDirty(animatorController);
			}
		}
	}
	static class AnimationExtension{
		public static void RemoveCrossFade(this AnimatorStateTransition transition){
			transition.exitTime=1;
			transition.duration=0;
			transition.offset=0;
		}	
	}

}