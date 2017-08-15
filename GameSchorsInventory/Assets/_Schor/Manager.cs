using System;
using System.Collections;
using System.Collections.Generic;
using TRNTH.SchorsInventory.DeadDatabase;
using TRNTH.SchorsInventory.RuntimeDatabase;
using UnityEngine;
namespace TRNTH.SchorsInventory{
	public interface IManager{
		UserData UserData{get;}
		IScenarioController ScenarioController {get;}
	}
}
namespace 	TRNTH.SchorsInventory.Component{
	public class Manager : MonoBehaviour
	,IManager
	,IScenarioPlayer {
		static public IManager Instance{get;private set;}

        public UserData UserData {get{return _UserData;}}


        IScenarioController IManager.ScenarioController {get{return _scenarioController;}}

        [SerializeField]UserData _UserData;
		public DeadDatabase.Scenario _Scenario;
		[SerializeField]BeforeLeaving _scenarioController;
		[SerializeField]UI.Component.Console _Console;
		[SerializeField]UI.Component.Dialogue _dialouge;
		public void ScenarioNext(){
			if(_Scenario==null){
				_Scenario=_scenarioController.Choose();
			}
			if(_Scenario==null || _UserData.Memories.Contains(_Scenario)){
				_Scenario=null;
				return;
			}
			if(Index>=_Scenario.Dialogues.Count){
				_UserData.Memories.Add(_Scenario);
				_scenarioController.End(_Scenario);
				_Scenario=null;
				this.Index=0;
				_dialouge.gameObject.SetActive(false);
				return;
			}
			var dia=_Scenario.Dialogues[Index++];
			_Console.Add(dia.Character.Name,dia.Content);
			_dialouge.Refresh(dia);
		}
		IEnumerator Start()
		{
			Instance=this;
			yield return null;
			_scenarioController.AfterMainthreadStart();
		}
		

        void IScenarioPlayer.Play(Scenario scenario)
        {
            _Scenario=scenario;
			ScenarioNext();
        }

        int Index;
	}

}
