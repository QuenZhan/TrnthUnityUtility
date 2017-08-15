using System;
using System.Collections;
using System.Collections.Generic;
using TRNTH.SchorsInventory.Component;
using TRNTH.SchorsInventory.DeadDatabase;
using UnityEngine;
namespace TRNTH.SchorsInventory{
	public interface IScenarioPlayer{
		void Play(Scenario scenario);
	}
}
namespace TRNTH.SchorsInventory.Component{
	[CreateAssetMenu]public class BeforeLeaving : ScenarioController,IScenarioController {
		public IScenarioPlayer Player{get;private set;}
		[SerializeField]Scenario _AdmissionLetter;
		[SerializeField]Scenario _AdmissionLetterAfterReading;
		[SerializeField]Scenario _tryBackHome;
		[SerializeField]Place _Home;
		[SerializeField]GameObject _map;
		public void ChangePlace(Place place){
			// if(place==_Home){
			// 	_manager.ScenarioNext();
			// }
		}
		public Scenario Choose(){
			var userdata=Component.Manager.Instance.UserData;
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
		public void End(Scenario scenario){
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
			var userdata=Manager.Instance.UserData;
			if(!userdata.Memories.Contains(_AdmissionLetter)){
				_map.SetActive(false);
				Player.Play(_AdmissionLetter);
			}
        }
    }
}
