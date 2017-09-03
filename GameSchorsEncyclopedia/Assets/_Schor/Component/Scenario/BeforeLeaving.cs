using System;
using System.Collections;
using System.Collections.Generic;
using TRNTH.SchorsInventory.Component;
using TRNTH.SchorsInventory.DeadDatabase;
using UnityEngine;
namespace TRNTH.SchorsInventory{
	public interface IScenarioPlayer{
		void Play(IConversation scenario);
	}
	// public interface IScenario{
	// 	void Start();
	// 	void End();
	// }
	public interface IConversation:IAction {
		string Title{get;}
		IReadOnlyList<Dialogue> Dialogues{get;}
		void End();
	}
    public class Conversation : IConversation
    {
        public string Title {get;set;}

        IReadOnlyList<Dialogue> IConversation.Dialogues {get{return _Dialogues;}}

		readonly List<Dialogue> _Dialogues=new List<Dialogue>();
        public IList<Dialogue> Dialogues{get{return _Dialogues;}}

        public string Name{get{return Title;}}

        public string Description {get;set;}

        public TimeSpan CostTime {get{return new System.TimeSpan(0,2,0);}}

        public virtual void End()
        {
            // throw new NotImplementedException();
        }
    }
}
namespace TRNTH.SchorsInventory.Component{
	// [CreateAssetMenu
	public class BeforeLeaving : ScenarioController {
		public IScenarioPlayer Player{get;private set;}
		[SerializeField]Conversation _AdmissionLetter;
		[SerializeField]Conversation _AdmissionLetterAfterReading;
		[SerializeField]Conversation _tryBackHome;
		[SerializeField]Place _Home;
		[SerializeField]GameObject _map;
		public void ChangePlace(Place place){
			// if(place==_Home){
			// 	_manager.ScenarioNext();
			// }
		}
		RuntimeDatabase.UserData userdata;
		public Conversation Choose(){
			// var userdata=Component.SjiaController.Instance.UserData;
			var memories=userdata.Memories;
			if(userdata.Place==_Home){
				return _tryBackHome;
			}
			if(!memories.Contains(_AdmissionLetter)){
				return _AdmissionLetter;
			}
			else if(!memories.Contains(_AdmissionLetterAfterReading)){
				return _AdmissionLetterAfterReading;
			}
			return null;
		}
		public void End(Conversation scenario){
			if(scenario==_AdmissionLetter){
				_map.SetActive(true);
			}
			// _manager.ScenarioNext();
		}
		[SerializeField]Manager _manager;
		void Start()
		{
			Player=_manager as IScenarioPlayer;			
		}
	[SerializeField]Place _school;
        public void SelectPlace(Place place)
        {
			if(place==_Home){
				Player.Play(_tryBackHome);
			}
			if(place==_school){
				Player.Play(_AdmissionLetterAfterReading);
			}
        }

        public void AfterMainthreadStart()
        {
			// var userdata=SjiaController.Instance.UserData;
			if(!userdata.Memories.Contains(_AdmissionLetter)){
				_map.SetActive(false);
				Player.Play(_AdmissionLetter);
			}
        }
    }
}
